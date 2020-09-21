using Newtonsoft.Json;

namespace LinePayClassLibrary.Models
{
    /// <summary>
    /// Preapproved Payment Response
    /// </summary>
    public class PreApprovedPayResponse : ResponseBase
    {
        [JsonProperty("info")]
        public PreApprovedPayInfo Info { get; set; }
    }
}
