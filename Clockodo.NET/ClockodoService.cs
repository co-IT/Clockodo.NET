using System.Collections.Immutable;
using Clockodo.NET.DataContracts;
using Clockodo.NET.Filter;

namespace Clockodo.NET;

public class ClockodoService : ITimeEntryService
{
    private readonly JsonSerializerSettings _jsonSettings;
    private readonly HttpClient _client;

    public ClockodoService(Credentials credentials)
    {
        _jsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        _client = new HttpClient
        {
            DefaultRequestHeaders =
            {
                {"Accept", "application/json"},
                {"X-ClockodoApiUser", credentials.EmailAddress},
                {"X-ClockodoApiKey", credentials.ApiToken},
                {"X-Clockodo-External-Application", $"{credentials.ApplicationName};{credentials.ContactEmail}"}
            }
        };
    }

    public async Task<IImmutableList<TimeEntry>> GetTimeEntriesAsync(ClockodoPeriod period)
    {
        var rawEntries = await GetRawTimeEntriesAsync(period);

        var runningEntryFilter = new RunningEntryFilter();
        var finishedRawEntries = runningEntryFilter.Filter(rawEntries);

        var combinedEntries = finishedRawEntries
            .Select(rawEntry => new TimeEntry(rawEntry))
            .ToList();

        return combinedEntries.ToImmutableList();
    }

    public async Task<IImmutableList<RawTimeEntry>> GetRawTimeEntriesAsync(ClockodoPeriod period)
    {
        var allTimeEntries = new List<RawTimeEntry>();
        TimeEntryWrapper allEntriesOfPage;
        var page = 1;

        do
        {
            var uri = ClockodoApiAdressesBuilder.AllEntriesUri(period, page, true);

            allEntriesOfPage = await GetAllAsync<TimeEntryWrapper>(uri);
            allTimeEntries.AddRange(allEntriesOfPage.Entries);

            page++;
        } while (allEntriesOfPage.Paging.CountPages >= page);

        return allTimeEntries.ToImmutableList();
    }

    private async Task<T> GetAllAsync<T>(string route)
    {
        var response = await _client.GetAsync(route);
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var deserialized = JsonConvert.DeserializeObject<T>(content, _jsonSettings);
        return deserialized ?? default;
    }
}