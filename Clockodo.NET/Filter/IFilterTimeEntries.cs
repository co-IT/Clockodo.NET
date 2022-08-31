using Clockodo.NET.DataContracts;

namespace Clockodo.NET.Filter;

public interface IFilterTimeEntries
{
    IEnumerable<TimeEntry> Filter(IEnumerable<TimeEntry> source);
}