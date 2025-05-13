using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp.Model {
    internal class SkyBrightnessDatas : ModelBase<SkyBrightnessDatas> {
        private static readonly HttpClient HttpClient = new() {
            Timeout = TimeSpan.FromSeconds(5)
        };
        //{"timestamp":"2025-05-12 19:07:16","fullLuminosity":1.837699e8,"infraredLuminosity":20687,"visibleLuminosity":1,"mpsas":23.78197,"dmpsas":1.086,"integrationValue":600,"gainValue":148,"niter":1,"lux":0}
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
              /*- Un SQM de 21,99+ correspond à un ciel de classe 1 (ciel extrêmement noir).
                - Un SQM de 21,89-21,99 correspond à un ciel de classe 2.
                - Un SQM de 21,69-21,89 correspond à un ciel de classe 3.
                - Un SQM de 21,50-21,69 correspond à un ciel de classe 4.
                - Un SQM de 21,30-21,50 correspond à un ciel de classe 5.
                - Un SQM de 20,99-21,30 correspond à un ciel de classe 6.
                - Un SQM de 20,49-20,99 correspond à un ciel de classe 7.
                - Un SQM de 19,50-20,49 correspond à un ciel de classe 8.
                - Un SQM de <19,50 correspond à un ciel de classe 9 (ciel urbain fortement pollué).
              */

                if (Mpsas > 21.99) return 1;
                if (Mpsas > 21.89 && Mpsas <= 21.99) return 2;
                if (Mpsas > 21.69 && Mpsas <= 21.89) return 3;
                if (Mpsas > 21.50 && Mpsas <= 21.69) return 4;
                if (Mpsas > 21.30 && Mpsas <= 21.50) return 5;
                if (Mpsas > 20.99 && Mpsas <= 21.30) return 6;
                if (Mpsas > 20.49 && Mpsas <= 20.99) return 7;
                if (Mpsas > 19.50 && Mpsas <= 20.49) return 8;
                return 9;
            }
        }
        public async static Task<SkyBrightnessDatas?> GetSkyBrightnessDatasAsync(string host) {
            try {
                var response = await HttpClient.GetAsync($"http://{host}/SkyBrightness");
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
