using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GraphingAlgorithmsUI.Helpers
{
    public class JsonParser
    {
        readonly JsonSerializerSettings _jsonSerializerSettings;

        public T ReadJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public string ConvertToJson<T>(T Data)
        {
            return JsonConvert.SerializeObject(Data);
        }

        public JsonParser()
        {
            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto
            };
        }
    }
}