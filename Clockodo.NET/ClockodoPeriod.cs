using CSharpFunctionalExtensions;

namespace Clockodo.NET;

public class ClockodoPeriod
{
    private ClockodoPeriod(DateTime start, DateTime end)
    {
        Start = start;
        End = end;
    }

    private DateTime Start { get; }
    private DateTime End { get; }

    public static Result<ClockodoPeriod> Create(DateTime start, DateTime end)
    {
        if (start > end)
            return Result.Failure<ClockodoPeriod>("Das Ende kann nicht nach dem Anfang liegen");

        if (start == end)
            return Result.Failure<ClockodoPeriod>("Das Ende kann nicht auf dem Anfang liegen");

        return Result.Success(
            new ClockodoPeriod(start, end)
        );
    }

    public static Result<ClockodoPeriod> Create(DateOnly start, DateOnly end)
    {
        if (start > end)
            return Result.Failure<ClockodoPeriod>("Das Ende kann nicht nach dem Anfang liegen");

        if (start == end)
            return Result.Failure<ClockodoPeriod>("Das Ende kann nicht auf dem Anfang liegen");

        var startTime = new TimeOnly(0, 0, 0);
        var endTime = new TimeOnly(23, 59, 59);

        var clockodoPeriod = new ClockodoPeriod(
            start.ToDateTime(startTime),
            end.ToDateTime(endTime)
        );

        return Result.Success(clockodoPeriod);
    }

    internal string GetStartAsString()
    {
        return Start.ToString("yyyy-MM-dd'T'hh:mm:ss'Z'");
    }

    internal string GetEndAsString()
    {
        return End.ToString("yyyy-MM-dd'T'hh:mm:ss'Z'");
    }
}