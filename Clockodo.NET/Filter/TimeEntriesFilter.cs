using Clockodo.NET.DataContracts;

namespace Clockodo.NET.Filter;

public static class TimeEntriesFilter
{
    public static IEnumerable<TimeEntry> ApplyAllFilters(this IEnumerable<TimeEntry> source,
        IEnumerable<IFilterTimeEntries> filters)
    {
        var filteredEntries = source;

        foreach (var filter in filters) filteredEntries = filter.Filter(filteredEntries);

        return filteredEntries;
    }
}