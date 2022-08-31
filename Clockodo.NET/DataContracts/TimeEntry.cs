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

    public TimeEntry()
    {
        
    }

    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public int Duration { get; set; }

    public string CustomerName { get; set; }
    public string ProjectName { get; set; }
    public string EmployeeName { get; set; }
    public decimal Revenue { get; set; }
    public string ServicesName { get; set; }
}