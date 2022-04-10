using System.Text.Json;

namespace HandlingExtinguishers.WebApi.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class JsonHelper
    {
        private static JsonSerializerOptions _jsonSerializerOptions;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
