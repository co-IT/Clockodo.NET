namespace Clockodo.NET.DataContracts;

public class RawTimeEntry
{
    [JsonProperty("id")] public int StoreId { get; set; }
    [JsonProperty("customers_id")] public int CustomerId { get; set; }
    [JsonProperty("projects_id")] public int? ProjectId { get; set; }
    [JsonProperty("users_id")] public int EmployeeId { get; set; }
    [JsonProperty("billable")] public bool Billable { get; set; }
    [JsonProperty("texts_id")] public int? TextId { get; set; }
    [JsonProperty("texts")] public string? Text { get; set; }
    [JsonProperty("time_since")] public string TimeSince { get; set; }
    [JsonProperty("time_until")] public string? TimeUntil { get; set; }
    [JsonProperty("time_insert")] public string TimeInsert { get; set; }
    [JsonProperty("time_last_change")] public string TimeLastChange { get; set; }
    [JsonProperty("customers_name")] public string CustomerName { get; set; }
    [JsonProperty("projects_name")] public string ProjectsName { get; set; }
    [JsonProperty("users_name")] public string UserName { get; set; }
    [JsonProperty("revenue")] public decimal Revenue { get; set; }
    [JsonProperty("type")] public int Type { get; set; }
    [JsonProperty("services_id")] public int ServiceId { get; set; }
    [JsonProperty("duration")] public int? Duration { get; set; }

    [JsonProperty("time_last_change_work_time")]
    public string TimeLastChangeWorkTime { get; set; }

    [JsonProperty("time_clocked_since")] public string TimeClockedSince { get; set; }
    [JsonProperty("clocked")] public bool Clocked { get; set; }
    [JsonProperty("clocked_offline")] public bool ClockedOffline { get; set; }
    [JsonProperty("hourly_rate")] public decimal HourlyRate { get; set; }
    [JsonProperty("services_name")] public string ServiceName { get; set; }
}