using Newtonsoft.Json;
using System.Text.Json;

namespace WindowsApp.Model {

    internal class SensorStatus : ModelBase<SensorStatus> {
        [JsonProperty("MLX90614")] public string? CloudSensorStatus { get; set; }
        [JsonProperty("BME280")] public string? EnvironmentSensorStatus { get; set; }
        [JsonProperty("TSL2591")] public string? SkyLuminositySensorStatus { get; set; }
    }
    internal class DeviceStatus : CommunicationModelBase<SensorStatus> {
        // {"deviceName":"HRO SQM Meter v1.0","deviceID":"HRO-SQM-0001","wifiStatus":"Connected","sensors":{"MLX90614":"Connected","BME280":"Connected","TSL2591":"Connected"}}
        public DeviceStatus() : base() { }
        public DeviceStatus(CommunicationType commType, string hostName) : base(commType, hostName) { }
        [JsonProperty("deviceName")] public string? DeviceName { get; set; }  //HRO SQM Meter v1.0;
        [JsonProperty("deviceID")] public string? DeviceID { get; set; } // Identifiant unique
        [JsonProperty("wifiStatus")] public string? WifiStatus { get; set; } //= WiFi.status() == WL_CONNECTED? "Connected" : "Disconnected";
        [JsonProperty("sensors")] public SensorStatus? SensorStatus { get; set; }

        public async Task<DeviceStatus?> GetDeviceStatusDatasAsync() {
            try {
                return JsonConvert.DeserializeObject<DeviceStatus>(await GetAsync($"/Device/status"));
            } catch {
                // Ignorer les erreurs
            }
            return null;
        }
    }
}
