using Newtonsoft.Json;

namespace WindowsApp.Model {
    internal class CloudCoverDatas : CommunicationModelBase<CloudCoverDatas> {
        //{"timestamp":"2025-05-05 22:19:53","ambient":24.63,"sky":10.44999,"cloudCoverture":100}
        // Constructeur par défaut requis pour la désérialisation JSON
        public CloudCoverDatas() : base() { }
        public CloudCoverDatas(CommunicationType commType, string hostName) : base(commType, hostName) { }
        [JsonProperty("timestamp")] public DateTime TimeStamp { get; private set; }
        [JsonProperty("ambient")] public float AmbientTemperature { get; private set; }
        [JsonProperty("sky")] public float SkyTemperature { get; private set; }
        [JsonProperty("cloudCoverture")] public int PercentCoverture { get; private set; }
        public async Task<CloudCoverDatas?> GetCloudCoverDatasAsync() {
            try {
                // Appel de la méthode GetAsync pour récupérer les données JSON depuis l'API
                // et désérialisation en un objet CloudCoverDatas
                var jsonData = await GetAsync("/CloudCover");
                if (jsonData == null) return null;
                return Deserialize(jsonData);
            } catch {
                // Ignorer les erreurs
            }
            return null;
        }
    }
}
