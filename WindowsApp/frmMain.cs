using WindowsApp.Model;

namespace WindowsApp {
    public partial class frmMain : Form {
        private readonly HttpClient httpClient;
        private readonly SemaphoreSlim semaphore = new(10); // Limite à 10 requêtes
        private string DeviceUrl { get; set; }

        public frmMain() {
            InitializeComponent();
            tRetrieveDatas.Tick += async (s, e) => await UpdateDatas();
            httpClient = new() {
                Timeout = TimeSpan.FromSeconds(5)
            };

        }

        private async Task<string> GetDeviceStatusAsync() {
            try {
                var response = await httpClient.GetAsync($"{DeviceUrl}/device/status");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            } catch (Exception ex) {
                return $"Error: {ex.Message}";
            }
        }

        private async Task<List<KeyValuePair<string, string>>> ScanNetworkAsync() {
            var devices = new List<KeyValuePair<string, string>>();
            var localIP = GetLocalIPAddress();
            var baseIP = localIP[..(localIP.LastIndexOf('.') + 1)];

            var tasks = new List<Task<KeyValuePair<string, string>?>>();

            for (int i = 1; i <= 254; i++) {
                var ip = baseIP + i.ToString();
                tasks.Add(CheckDeviceAsync(ip)); // Ajouter les tâches à la liste
            }

            var results = await Task.WhenAll(tasks); // Exécuter toutes les tâches en parallèle

            // Ajouter les résultats valides à la liste des devices
            foreach (var result in results) {
                if (result.HasValue) {
                    devices.Add(result.Value);
                }
            }

            return devices;
        }

        private async Task<KeyValuePair<string, string>?> CheckDeviceAsync(string ip) {
            await semaphore.WaitAsync(); // Attendre qu'une place soit disponible
            try {
                var response = await httpClient.GetAsync($"http://{ip}/device/status");
                if (response.IsSuccessStatusCode) {
                    var content = DeviceStatus.Deserialize(await response.Content.ReadAsStringAsync());
                    return new KeyValuePair<string, string>(content?.DeviceName ?? "Unknown", ip);
                }
            } catch {
                // Ignorer les erreurs
            } finally {
                semaphore.Release(); // Libérer la place
            }

            return null; // Retourner null si l'appareil n'est pas accessible
        }

        private string GetLocalIPAddress() {
            var host = System.Net.Dns.GetHostName();
            var ipEntry = System.Net.Dns.GetHostEntry(host);
            foreach (var ip in ipEntry.AddressList) {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                    return ip.ToString();
                }
            }
            tsLblResult.Text = "Adresse IP locale introuvable !";
            return string.Empty;
        }

        private async void btnConfigScan_Click(object sender, EventArgs e) {
            tcConfig.UseWaitCursor = true;
            tsLblResult.Text = "Recherche des appareils...";
            var devices = await ScanNetworkAsync();
            if (devices.Any()) {
                lbConfigHostsList.DataSource = devices;
            } else {
                tsLblResult.Text = "Aucun appareil n'a été trouvé sur le réseau.";
            }
            tcConfig.UseWaitCursor = false;
        }

        private async void btnConfigConnectHost_Click(object sender, EventArgs e) {
            DeviceUrl = $"http://{txtConfigHost.Text}";
            var result = DeviceStatus.Deserialize(await GetDeviceStatusAsync());
            lblConfigDeviceNameText.Text = result?.DeviceName;
            lblConfigDeviceIdText.Text = result?.DeviceID;
            lblConfigDeviceWifiText.Text = result?.WifiStatus;

            ipbConfigSensorSttCloud.ForeColor = (bool)!result?.SensorStatus?.CloudSensorStatus?.Equals("Connected") ? Color.Red : Color.Green;
            lblConfigSensorSttCloudTxt.Text = result?.SensorStatus?.CloudSensorStatus;
            lblConfigSensorSttCloudTxt.ForeColor = (bool)!result?.SensorStatus?.CloudSensorStatus?.Equals("Connected") ? Color.Red : Color.Green;

            ipbConfigSensorSttEnv.ForeColor = (bool)!result?.SensorStatus?.EnvironmentSensorStatus?.Equals("Connected") ? Color.Red : Color.Green;
            lblConfigSensorSttEnvTxt.Text = result?.SensorStatus?.EnvironmentSensorStatus;
            lblConfigSensorSttEnvTxt.ForeColor = (bool)!result?.SensorStatus?.EnvironmentSensorStatus?.Equals("Connected") ? Color.Red : Color.Green;

            ipbConfigSensorSttSqm.ForeColor = (bool)!result?.SensorStatus?.SkyLuminositySensorStatus?.Equals("Connected") ? Color.Red : Color.Green;
            lblConfigSensorSttSqmTxt.Text = result?.SensorStatus?.SkyLuminositySensorStatus;
            lblConfigSensorSttSqmTxt.ForeColor = (bool)!result?.SensorStatus?.SkyLuminositySensorStatus?.Equals("Connected") ? Color.Red : Color.Green;

            ipbConfigSensorSttBatt.ForeColor = (bool)!result?.SensorStatus?.BatterySensorStatus?.Equals("Connected") ? Color.Red : Color.Green;
            tsLblResult.Text = "Connecté !";
            tRetrieveDatas.Start();
        }

        private void lbConfigHostsList_SelectedIndexChanged(object sender, EventArgs e) {
            txtConfigHost.Text = $"{lbConfigHostsList.SelectedValue}";
            btnConfigConnectHost.Enabled = true;
        }

        private void txtConfigHost_TextChanged(object sender, EventArgs e) {
            btnConfigConnectHost.Enabled = txtConfigHost.Text.Split('.').Length == 4;
        }

        private void bwEnvironmentDatas_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e) {
        }

        private async Task UpdateDatas() {
            var cdatas = await CloudCoverDatas.GetCloudCoverDatasAsync(txtConfigHost.Text);
            var wdatas = await WeatherDatas.GetWeatherDatasAsync(txtConfigHost.Text);

            lblTempData.Text = $"{wdatas?.Temperature:n2}";
            lblHumData.Text = $"{wdatas?.Humidity:n0}";
            lblPressData.Text = $"{wdatas?.Pressure:n0}";
        }
    }
}
