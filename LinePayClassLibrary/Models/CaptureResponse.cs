using Newtonsoft.Json;

namespace LinePayClassLibrary.Models
{
    /// <summary>
    /// Capture Response
    /// </summary>
    public class CaptureResponse : ResponseBase
    {
        /// <summary>
        /// Capture Information
        /// </summary>
        [JsonProperty("info")]
        public CaptureInfo Info { get; set; }
    }
}
