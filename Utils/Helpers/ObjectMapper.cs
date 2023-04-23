using Newtonsoft.Json;
namespace WebAPI.Utils.Helpers
{
    public class ObjectMapper
    {
        private string json;
        public static T? ToModel<T>(string json) => JsonConvert.DeserializeObject<T>(value: json);
        public static string? ToString<T>(T obj) { return null; }
        public static T? ToObject<T,U>(U obj) {
            string json = JsonConvert.SerializeObject(obj);
            T? res = JsonConvert.DeserializeObject<T>(json);
            return res;
        }
    }
}