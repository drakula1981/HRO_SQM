using Newtonsoft.Json;

namespace WindowsApp.Model {
    internal class WeatherDatas : CommunicationModelBase<WeatherDatas> {
        //{"timestamp":"2025-05-05 21:24:50","temperature":21.71,"pressure":999,"humidity":12,"altitude":123.98}
        // Constructeur par défaut requis pour la désérialisation JSON
        public WeatherDatas() : base() { }
        public WeatherDatas(CommunicationType commType, string hostName) : base(commType, hostName) { }
        [JsonProperty("timestamp")] public DateTime TimeStamp { get; private set; }
        [JsonProperty("temperature")] public float Temperature { get; private set; }
        [JsonProperty("humidity")] public float Humidity { get; private set; }
        [JsonProperty("pressure")] public int Pressure { get; private set; }
        [JsonProperty("altitude")] public float Altitude { get; private set; }
        public async Task<WeatherDatas?> GetWeatherDatasAsync() {
            try {
                // Appel de l'API pour obtenir les données météo
                // et désérialisation en un objet WeatherDatas
                var jsonData = await GetAsync("/Weather");
                if (jsonData == null) return null;
                return Deserialize(jsonData);
            } catch {
                // Ignorer les erreurs
            }
            return null;
        }
    }
}
