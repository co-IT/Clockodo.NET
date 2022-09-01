namespace Clockodo.NET.DataContracts;

public class TimeEntry
{
    internal TimeEntry(RawTimeEntry rawTimeEntry)
    {
        Start = DateTime.Parse(rawTimeEntry.TimeSince);
        End = DateTime.Parse(rawTimeEntry.TimeUntil);
        Duration = rawTimeEntry.Duration ?? 0;
        CustomerName = rawTimeEntry.CustomerName;
        ProjectName = rawTimeEntry.ProjectsName;
        EmployeeName = rawTimeEntry.UserName;
        Revenue = rawTimeEntry.Revenue;
        ServicesName = rawTimeEntry.ServiceName;
    }

    public DateTime Start { get; }
    public DateTime End { get; }
    public int Duration { get; }

    public string CustomerName { get; }
    public string ProjectName { get; }
    public string EmployeeName { get; }
    public decimal Revenue { get; }
    public string ServicesName { get; }
}