using System.Text.Json;

namespace HandlingExtinguishers.WebApi.Helpers
{
    public class JsonHelper
    {
        private static JsonSerializerOptions _jsonSerializerOptions;
        public static JsonSerializerOptions GetSerializerOptions()
        {
            if (_jsonSerializerOptions != null)
            {
                _jsonSerializerOptions = new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Always,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
            }
            return _jsonSerializerOptions;
        }

    }
}
