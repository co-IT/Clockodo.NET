using Clockodo.NET.DataContracts;

namespace Clockodo.NET.Filter;

internal class RunningEntryFilter
{
    public IEnumerable<RawTimeEntry> Filter(IEnumerable<RawTimeEntry> source)
    {
        return source.Where(rawEntry => !string.IsNullOrWhiteSpace(rawEntry.TimeUntil));
    }
}