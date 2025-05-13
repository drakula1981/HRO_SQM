using Newtonsoft.Json;

namespace WindowsApp.Model {
    internal class WeatherDatas : ModelBase<WeatherDatas> {
        //{"timestamp":"2025-05-05 21:24:50","temperature":21.71,"pressure":999,"humidity":12,"altitude":123.98}
        private static readonly HttpClient HttpClient = new() {
            Timeout = TimeSpan.FromSeconds(20)
            };
        [JsonProperty("timestamp")] public DateTime TimeStamp { get; private set; }
        [JsonProperty("temperature")] public float Temperature { get; private set; }
        [JsonProperty("humidity")] public float Humidity { get; private set; }
        [JsonProperty("pressure")] public int Pressure { get; private set; }
        [JsonProperty("altitude")] public float Altitude { get; private set; }
        public async static Task<WeatherDatas?> GetWeatherDatasAsync(string host) {
            try {
                var response = await HttpClient.GetAsync($"http://{host}/Weather");
                if (response.IsSuccessStatusCode) {
                    return Deserialize(await response.Content.ReadAsStringAsync());
                }
            } catch {
                // Ignorer les erreurs
            }
            return null;
        }
    }
}
