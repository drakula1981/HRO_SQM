using Newtonsoft.Json;

namespace WindowsApp.Model {
    internal class SkyBrightnessDatas : CommunicationModelBase<SkyBrightnessDatas> {
        //{"timestamp":"2025-05-12 19:07:16","fullLuminosity":1.837699e8,"infraredLuminosity":20687,"visibleLuminosity":1,"mpsas":23.78197,"dmpsas":1.086,"integrationValue":600,"gainValue":148,"niter":1,"lux":0}

        // Constructeur par défaut requis pour la désérialisation JSON
        public SkyBrightnessDatas() : base() { }
        public SkyBrightnessDatas(CommunicationType commType, string hostName) : base(commType, hostName) { }
        [JsonProperty("timestamp")] public DateTime TimeStamp { get; private set; }
        [JsonProperty("fullLuminosity")] public float FullLuminosity { get; private set; }
        [JsonProperty("infraredLuminosity")] public float InfraredLuminosity { get; private set; }
        [JsonProperty("visibleLuminosity")] public float VisibleLuminosity { get; private set; }
        [JsonProperty("mpsas")] public float Mpsas { get; private set; }
        [JsonProperty("dmpsas")] public float Dmpsas { get; private set; }
        [JsonProperty("integrationValue")] public int IntegrationValue { get; private set; }
        [JsonProperty("gainValue")] public int GainValue { get; private set; }
        [JsonProperty("niter")] public int Niter { get; private set; }
        [JsonProperty("lux")] public float Lux { get; private set; }
        [JsonIgnore] public int BortleClass {
            get {
                if (Mpsas > 21.99) return 1;
                if (Mpsas > 21.89 && Mpsas <= 21.99) return 2;
                if (Mpsas > 21.69 && Mpsas <= 21.89) return 3;
                if (Mpsas > 20.49 && Mpsas <= 21.69) return 4;
                if (Mpsas > 19.50 && Mpsas <= 20.49) return 5;
                if (Mpsas > 18.94 && Mpsas <= 19.50) return 6;
                if (Mpsas > 18.38 && Mpsas <= 18.94) return 7;
                if (Mpsas > 18.00 && Mpsas <= 18.38) return 8;
                return 9;
            }
        }
        public async Task<SkyBrightnessDatas?> GetSkyBrightnessDatasAsync() {
            try {
                // Appel de l'API pour obtenir les données de luminosité du ciel
                // et désérialisation en un objet SkyBrightnessDatas
                var jsonData = await GetAsync("/SkyBrightness");
                if (jsonData == null) return null;
                return Deserialize(jsonData);
            } catch {
                // Ignorer les erreurs
            }
            return null;
        }
    }
}
