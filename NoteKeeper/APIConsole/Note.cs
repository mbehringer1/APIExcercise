using Newtonsoft.Json;

namespace APIConsole
{
    public class Note
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }
}
