using Newtonsoft.Json;

namespace Clockodo.NET.DataContracts
{
    internal class TimeEntryWrapper
    {
        [JsonProperty("paging")] public TimeEntryPaging Paging { get; set; }
        [JsonProperty("entries")] public RawTimeEntry[] Entries { get; set; }
    }
}
