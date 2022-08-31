using Clockodo.NET.DataContracts;

namespace Clockodo.NET.Filter;

public class EmployeeFilter : IFilterTimeEntries
{
    private readonly string _employeeName;

    public EmployeeFilter(string employeeName)
    {
        _employeeName = employeeName;
    }

    public IEnumerable<TimeEntry> Filter(IEnumerable<TimeEntry> source)
    {
        return source.Where(entry => entry.EmployeeName.Equals(_employeeName, StringComparison.OrdinalIgnoreCase));
    }
}