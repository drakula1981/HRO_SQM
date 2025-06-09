using Newtonsoft.Json;
using System.IO.Ports;

namespace WindowsApp.Model {
    public enum CommunicationType {
        WiFi,
        USB
    }
    internal abstract class CommunicationModelBase<T> : ModelBase<T> {
        [JsonIgnore]
        protected HttpClient? HttpClient { get; private set; }
        [JsonIgnore]
        protected SerialPort? SerialPort { get; private set; }

        protected CommunicationModelBase() { }

        protected CommunicationModelBase(CommunicationType commType, string hostName) {
            if (string.IsNullOrEmpty(hostName)) {
                throw new ArgumentException("Host name cannot be null or empty.", nameof(hostName));
            }
            if (commType == CommunicationType.WiFi) {
                HttpClient = new() {
                    BaseAddress = new Uri($"http://{hostName}/"),
                    Timeout = TimeSpan.FromSeconds(10)
                };
                HttpClient.DefaultRequestHeaders.Add("User-Agent", "WindowsApp/1.0");
            } else if (commType == CommunicationType.USB) {
                SerialPort = new(hostName, 115200, Parity.None, 8, StopBits.One) {
                    ReadTimeout = 20000, // Timeout for read operations  
                    WriteTimeout = 500, // Timeout for write operations
                    Handshake = Handshake.None,
                    DtrEnable = true,
                    RtsEnable = true
                };
            }
        }

        protected async Task<string?> GetAsync(string endpoint) {
            if (HttpClient != null) {
                try {
                    var response = await HttpClient.GetAsync(endpoint);
                    if (response.IsSuccessStatusCode) {
                        return await response.Content.ReadAsStringAsync();
                    }
                } catch {
                    // Ignore errors
                }
            } else if (SerialPort != null) {
                try {
                    SerialPort.Open();
                    SerialPort.DiscardInBuffer(); // Clear any existing data in the buffer
                    SerialPort.DiscardOutBuffer(); // Clear any existing data in the output buffer
                    if (SerialPort.IsOpen) {
                        SerialPort.WriteLine(endpoint);
                        await Task.Delay(100); // Wait for the device to respond
                        return await Task.Run(() => SerialPort.ReadLine());
                    }
                    return null;
                } catch {
                    // Ignore errors
                } finally {
                    if (SerialPort.IsOpen) {
                        SerialPort.Close();
                    }
                }
            }
            return null;
        }
    }

    internal abstract class ModelBase<T> {
        public static T? Deserialize(string? json) => !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<T>(json) : default;
        public static string Serialize(T? deviceStatus) => JsonConvert.SerializeObject(deviceStatus);
    }
}
