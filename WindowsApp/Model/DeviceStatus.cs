﻿using Newtonsoft.Json;
using System.Text.Json;

namespace WindowsApp.Model {

    internal class SensorStatus : ModelBase<SensorStatus> {
        [JsonProperty("MLX90614")] public string? CloudSensorStatus { get; set; }
        [JsonProperty("BME280")] public string? EnvironmentSensorStatus { get; set; }
        [JsonProperty("TSL2591")] public string? SkyLuminositySensorStatus { get; set; }
        [JsonProperty("MAX17048")] public string? MAX17048BatterySensorStatus { get; set; }
        [JsonProperty("LC709203F")] public string? LC709203FBatterySensorStatus { get; set; }
        [JsonIgnore] public string? BatterySensorStatus => !string.IsNullOrEmpty(MAX17048BatterySensorStatus) ? MAX17048BatterySensorStatus : LC709203FBatterySensorStatus;

    }
    internal class DeviceStatus : ModelBase<DeviceStatus> {
        [JsonProperty("deviceName")] public string? DeviceName { get; set; }  //HRO SQM Meter v1.0;
        [JsonProperty("deviceID")] public string? DeviceID { get; set; } // Identifiant unique
        [JsonProperty("wifiStatus")] public string? WifiStatus { get; set; } //= WiFi.status() == WL_CONNECTED? "Connected" : "Disconnected";
        [JsonProperty("sensors")] public SensorStatus? SensorStatus { get; set; }
    }
}
