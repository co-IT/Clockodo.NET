using Clockodo.NET.DataContracts;

namespace Clockodo.NET.Filter;

public static class TimeEntryGrouper
{
    public static IEnumerable<CustomerEmployeeHourData> GroupByEmployeeAndCustomer(this IEnumerable<TimeEntry> entries)
    {
        return entries
            .GroupBy(g => new
            {
                g.EmployeeName,
                g.CustomerName
            })
            .Select(g => new CustomerEmployeeHourData
            {
                Employee = g.Key.EmployeeName,
                Customer = g.Key.CustomerName,
                Time = g.Sum(e => e.Duration) / 60m
            })
            .OrderByDescending(e => e.Time);
    }
}