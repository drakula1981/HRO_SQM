using Newtonsoft.Json;

namespace WindowsApp.Model {
    internal abstract class ModelBase<T> {

        public static T? Deserialize(string json) => JsonConvert.DeserializeObject<T>(json);
        public static string Serialize(T? deviceStatus) => JsonConvert.SerializeObject(deviceStatus);
    }
}
