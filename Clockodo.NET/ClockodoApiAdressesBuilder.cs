using System.Web;

namespace Clockodo.NET;

internal static class ClockodoApiAdressesBuilder
{
    private static readonly string BaseAdress = @"https://my.clockodo.com/api";
    private static readonly string AllEntries = "v2/entries";

    public static string AllEntriesUri(ClockodoPeriod period, int page, bool enhancedList = false)
    {
        var queryParameters = HttpUtility.ParseQueryString(string.Empty);
        queryParameters["time_since"] = period.GetStartAsString();
        queryParameters["time_until"] = period.GetEndAsString();
        queryParameters["enhanced_list"] = enhancedList ? "true" : "false";
        queryParameters["page"] = page.ToString();

        return $"{BaseAdress}/{AllEntries}?{queryParameters}";
    }
}