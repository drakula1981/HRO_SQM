using Newtonsoft.Json;

namespace WindowsApp.Model {
    internal class CloudCoverDatas : ModelBase<CloudCoverDatas> {
        private static readonly HttpClient HttpClient = new() {
            Timeout = TimeSpan.FromSeconds(5)
        };
        //{"timestamp":"2025-05-05 22:19:53","ambient":24.63,"sky":10.44999,"cloudCoverture":100}
        [JsonProperty("timestamp")] public DateTime TimeStamp { get; private set; }
        [JsonProperty("ambient")] public float AmbientTemperature { get; private set; }
        [JsonProperty("sky")] public float SkyTemperature { get; private set; }
        [JsonProperty("cloudCoverture")] public int PercentCoverture { get; private set; }
        public async static Task<CloudCoverDatas?> GetCloudCoverDatasAsync(string host) {
            try {
                var response = await HttpClient.GetAsync($"http://{host}/CloudCover");
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
