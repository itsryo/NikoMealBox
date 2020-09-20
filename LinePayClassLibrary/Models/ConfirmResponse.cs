using Newtonsoft.Json;

namespace LinePayClassLibrary.Models
{
    /// <summary>
    /// Payment ConfirmAPI Response
    /// </summary>
    public class ConfirmResponse : ResponseBase
    {
        [JsonProperty("info")]
        public ConfirmInfo Info { get; set; }
    }
}
