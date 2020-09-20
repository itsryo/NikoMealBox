using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace LinePayClassLibrary.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Currency
    {
        USD,
        JPY,
        TWD,
        THB
    }
}
