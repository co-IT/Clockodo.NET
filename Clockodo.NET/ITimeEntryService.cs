using System.Collections.Immutable;
using Clockodo.NET.DataContracts;

namespace Clockodo.NET;

public interface ITimeEntryService
{
    Task<IImmutableList<TimeEntry>> GetTimeEntriesAsync(ClockodoPeriod period);

    Task<IImmutableList<RawTimeEntry>> GetRawTimeEntriesAsync(ClockodoPeriod period);
}