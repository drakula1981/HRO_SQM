using ScottPlot;
using ScottPlot.Plottables;
using System.IO;
using System.IO.Ports;
using WindowsApp.Model;

namespace WindowsApp {
    public partial class frmMain : Form {
        private readonly HttpClient httpClient;
        private readonly SemaphoreSlim semaphore = new(10); // Limite à 10 requêtes
        private string DeviceHostName { get; set; }
        private string DeviceComPort { get; set; }

        private DataLogger TempStreamer;
        private DataLogger HumStreamer;
        private DataLogger PressStreamer;
        private DataLogger SQMStreamer;

        private DeviceStatus? DeviceStatus { get; set; }
        private WeatherDatas? WeatherDatas { get; set; }
        private CloudCoverDatas? CloudCoverDatas { get; set; }
        private SkyBrightnessDatas? SkyBrightnessDatas { get; set; }


        public frmMain() {
            InitializeComponent();
            InitializeCharts();
            tRetrieveDatas.Tick += async (s, e) => await UpdateDatas();
            httpClient = new() {
                Timeout = TimeSpan.FromSeconds(5)
            };

            cbComPorts.DataSource = SerialPort.GetPortNames();
            btnConnectComPort.Enabled = cbComPorts.Items.Count > 0;
        }

        private void InitializeCharts() {
            TempStreamer = fpTempHumPress.Plot.Add.DataLogger();
            HumStreamer = fpTempHumPress.Plot.Add.DataLogger();
            PressStreamer = fpTempHumPress.Plot.Add.DataLogger();
            SQMStreamer = fpSQM.Plot.Add.DataLogger();

            fpTempHumPress.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.DateTimeAutomatic();
            fpTempHumPress.Plot.Axes.DateTimeTicksBottom();
            fpTempHumPress.Plot.Axes.AutoScale();
            /*fpTempHumPress.Plot.Axes.Add(TempStreamer, label: "Température", color: System.Drawing.Color.Red);
            fpTempHumPress.Plot.Add(HumStreamer, label: "Humidité", color: System.Drawing.Color.Blue);
            fpTempHumPress.Plot.Add(PressStreamer, label: "Pression", color: System.Drawing.Color.Green);*/
            fpSQM.Plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.DateTimeAutomatic();
            fpSQM.Plot.Axes.DateTimeTicksBottom();
            fpSQM.Plot.Axes.AutoScale();

            fpTempHumPress.Refresh();
            fpSQM.Refresh();
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
                DeviceStatus? deviceStatus = new(CommunicationType.WiFi, ip);
                var stt = await deviceStatus.GetDeviceStatusDatasAsync();
                if (stt != null && !string.IsNullOrEmpty(stt.DeviceID)) {
                    return new KeyValuePair<string, string>(stt.DeviceID, ip);
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
            DeviceHostName = txtConfigHost.Text;
            DeviceStatus = new(CommunicationType.WiFi, DeviceHostName);
            var result = await DeviceStatus.GetDeviceStatusDatasAsync();
            if (result == null || result.SensorStatus == null) {
                tsLblResult.Text = "Échec de la connexion à l'appareil.";
                return;
            }

            lblConfigDeviceNameText.Text = result.DeviceName ?? "Nom inconnu";
            lblConfigDeviceIdText.Text = result.DeviceID ?? "ID inconnu";
            lblConfigDeviceWifiText.Text = result.WifiStatus ?? "Statut WiFi inconnu";

            ipbConfigSensorSttCloud.ForeColor = result.SensorStatus.CloudSensorStatus?.Equals("Connected") == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblConfigSensorSttCloudTxt.Text = result.SensorStatus.CloudSensorStatus ?? "Statut inconnu";
            lblConfigSensorSttCloudTxt.ForeColor = result.SensorStatus.CloudSensorStatus?.Equals("Connected") == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            ipbConfigSensorSttEnv.ForeColor = result.SensorStatus.EnvironmentSensorStatus?.Equals("Connected") == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblConfigSensorSttEnvTxt.Text = result.SensorStatus.EnvironmentSensorStatus ?? "Statut inconnu";
            lblConfigSensorSttEnvTxt.ForeColor = result.SensorStatus.EnvironmentSensorStatus?.Equals("Connected") == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            ipbConfigSensorSttSqm.ForeColor = result.SensorStatus.SkyLuminositySensorStatus?.Equals("Connected") == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblConfigSensorSttSqmTxt.Text = result.SensorStatus.SkyLuminositySensorStatus ?? "Statut inconnu";
            lblConfigSensorSttSqmTxt.ForeColor = result.SensorStatus.SkyLuminositySensorStatus?.Equals("Connected") == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            tsLblResult.Text = "Connecté !";

            btnConfigConnectHost.Enabled = false;
            CloudCoverDatas = new(CommunicationType.WiFi, DeviceHostName);
            WeatherDatas = new(CommunicationType.WiFi, DeviceHostName);
            SkyBrightnessDatas = new(CommunicationType.WiFi, DeviceHostName);
            tRetrieveDatas.Start();
        }


        private async void btnConnectComPort_Click(object sender, EventArgs e) {
            DeviceComPort = cbComPorts.SelectedItem.ToString();
            DeviceStatus = new(CommunicationType.USB, DeviceComPort);
            var result = await DeviceStatus.GetDeviceStatusDatasAsync();
            if (result == null || result.SensorStatus == null) {
                tsLblResult.Text = "Échec de la connexion à l'appareil.";
                return;
            }

            lblConfigDeviceNameText.Text = result.DeviceName ?? "Nom inconnu";
            lblConfigDeviceIdText.Text = result.DeviceID ?? "ID inconnu";
            lblConfigDeviceWifiText.Text = result.WifiStatus ?? "Statut WiFi inconnu";

            ipbConfigSensorSttCloud.ForeColor = result.SensorStatus.CloudSensorStatus?.Equals("Connected") == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblConfigSensorSttCloudTxt.Text = result.SensorStatus.CloudSensorStatus ?? "Statut inconnu";
            lblConfigSensorSttCloudTxt.ForeColor = result.SensorStatus.CloudSensorStatus?.Equals("Connected") == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            ipbConfigSensorSttEnv.ForeColor = result.SensorStatus.EnvironmentSensorStatus?.Equals("Connected") == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblConfigSensorSttEnvTxt.Text = result.SensorStatus.EnvironmentSensorStatus ?? "Statut inconnu";
            lblConfigSensorSttEnvTxt.ForeColor = result.SensorStatus.EnvironmentSensorStatus?.Equals("Connected") == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            ipbConfigSensorSttSqm.ForeColor = result.SensorStatus.SkyLuminositySensorStatus?.Equals("Connected") == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;
            lblConfigSensorSttSqmTxt.Text = result.SensorStatus.SkyLuminositySensorStatus ?? "Statut inconnu";
            lblConfigSensorSttSqmTxt.ForeColor = result.SensorStatus.SkyLuminositySensorStatus?.Equals("Connected") == true ? System.Drawing.Color.Green : System.Drawing.Color.Red;

            tsLblResult.Text = "Connecté !";

            btnConfigConnectHost.Enabled = false;
            CloudCoverDatas = new(CommunicationType.USB, DeviceComPort);
            WeatherDatas = new(CommunicationType.USB, DeviceComPort);
            SkyBrightnessDatas = new(CommunicationType.USB, DeviceComPort);
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
            tsLblResult.Text = "Récupération des données...";
            if(CloudCoverDatas == null || WeatherDatas == null || SkyBrightnessDatas == null) {
                tsLblResult.Text = "Erreur : Appareil non connecté.";
                return;
            }
            CloudCoverDatas? cdatas = await CloudCoverDatas.GetCloudCoverDatasAsync();
            if (cdatas == null) {
                tsLblResult.Text = "Erreur : Impossible de récupérer les données de couverture nuageuse.";
                return;
            }

            await Task.Delay(1000);
            WeatherDatas? wdatas = await WeatherDatas.GetWeatherDatasAsync();
            if (wdatas == null) {
                tsLblResult.Text = "Erreur : Impossible de récupérer les données météorologiques.";
                return;
            }

            await Task.Delay(1000);
            SkyBrightnessDatas? sdatas = await SkyBrightnessDatas.GetSkyBrightnessDatasAsync();
            if (sdatas == null) {
                tsLblResult.Text = "Erreur : Impossible de récupérer les données de luminosité du ciel.";
                return;
            }

            lblTempData.Text = $"{wdatas.Temperature:n2}";
            lblHumData.Text = $"{wdatas.Humidity:n0}";
            lblPressData.Text = $"{wdatas.Pressure:n0}";
            lblSkyTempData.Text = $"{cdatas.SkyTemperature:n2}";
            lblCloudCoverData.Text = $"{cdatas.PercentCoverture:n0}";

            if (cdatas.PercentCoverture <= 10) {
                ipbCloudCover.ForeColor = System.Drawing.Color.Green;
                ipbCloudCover.IconChar = FontAwesome.Sharp.IconChar.Moon;
            } else if (cdatas.PercentCoverture > 10 && cdatas.PercentCoverture <= 50) {
                ipbCloudCover.ForeColor = System.Drawing.Color.Orange;
                ipbCloudCover.IconChar = FontAwesome.Sharp.IconChar.CloudMoon;
            } else {
                ipbCloudCover.ForeColor = System.Drawing.Color.Red;
                ipbCloudCover.IconChar = FontAwesome.Sharp.IconChar.Cloud;
            }

            lblSqmDatas.Text = $"{sdatas.Mpsas:n2}";
            lblFullLumDatas.Text = $"{sdatas.FullLuminosity:n0}";
            lblIrDatas.Text = $"{sdatas.InfraredLuminosity:n0}";
            lblVisibleDatas.Text = $"{sdatas.VisibleLuminosity:n0}";
            lblDmpsasDatas.Text = $"{sdatas.Dmpsas:n2}";
            lblExpDatas.Text = $"{sdatas.IntegrationValue:n0}/{sdatas.GainValue:n0}/{sdatas.Niter:n0}";
            lblBortleClassDatas.Text = $"{sdatas.BortleClass}";

            var currentTime = DateTime.Now;

            SQMStreamer.Add(new Coordinates(currentTime.ToOADate(), sdatas.Mpsas));
            TempStreamer.Add(new Coordinates(currentTime.ToOADate(), wdatas.Temperature));
            HumStreamer.Add(new Coordinates(currentTime.ToOADate(), wdatas.Humidity));
            PressStreamer.Add(new Coordinates(currentTime.ToOADate(), wdatas.Pressure));

            if (SQMStreamer.Data.Coordinates.Count > 18000)
                SQMStreamer.Data.Coordinates.RemoveAt(0);
            if (TempStreamer.Data.Coordinates.Count > 18000)
                TempStreamer.Data.Coordinates.RemoveAt(0);
            if (HumStreamer.Data.Coordinates.Count > 18000)
                HumStreamer.Data.Coordinates.RemoveAt(0);
            if (PressStreamer.Data.Coordinates.Count > 18000)
                PressStreamer.Data.Coordinates.RemoveAt(0);

            fpTempHumPress.Refresh();
            fpSQM.Refresh();
        }

        private void nudRefreshFreq_ValueChanged(object sender, EventArgs e) {
            tRetrieveDatas.Stop();
            tRetrieveDatas.Interval = (int)nudRefreshFreq.Value * 1000;
            tRetrieveDatas.Start();
        }

    }
}
