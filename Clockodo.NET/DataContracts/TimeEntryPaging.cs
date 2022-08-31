namespace Clockodo.NET.DataContracts
{
    internal class TimeEntryPaging
    {
        [JsonProperty("items_per_page")] public long ItemsPerPage { get; set; }

        [JsonProperty("current_page")] public long CurrentPage { get; set; }

        [JsonProperty("count_pages")] public long CountPages { get; set; }

        [JsonProperty("count_items")] public long CountItems { get; set; }
    }
}
