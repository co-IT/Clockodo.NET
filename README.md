# Clockodo.NET
.NET library for the time and attendance tracking software Clockodo

# Features
Clockodo.NET does currently support the following Clockodo API functionality:

- Time Entries Endpoint
- Grouping and filtering of time entries

# Getting Started
To use this library you have to generate an API Key. Log into Clockodo and click on the profile icon in the top right. Then click on `My Data` and scroll down to `API-Key`. Click on `Generate API-Key` and copy it.

# Usage
First you have to create a new instance of ClockodoService with your API token and additional information like this:
```csharp
var clockodoCredentials = new Credentials(
  "your-account-email@adress.de",
  "your-api-token",
  "application-name", // You can choose any name you like
  "contact-email"     // Does not have to be the account E-Mail
);

var clockodoService = new ClockodoService(clockodoCredentials);
```
The application name and contact E-mail can be whatever you like. They dont have to be connected to your account or setup in clockodo. Clockodo uses it for `Client-Identification`.

## Getting all time entries

### Creating a Period
To get all time entries you first have to choose which period you want to query the time entries from.

The `ClockodoPeriod` class only allows for the creation of valid periods. The end date cannot be earlier than the start for example. It returns an object of the type `Result`.

```csharp
var periodStart = new DateTime(2021, 01, 01);
var periodEnd = new DateTime(2021, 05, 31);

var periodResult = ClockodoPeriod.Create(periodStart, periodEnd);

if (periodResult.IsFailure)
{
    Console.WriteLine(periodResult.Error);
    return;
}

var period = periodResult.Value;
```

### TimeEntry and RawTimeEntry
Then you can either use the `GetRawTimeEntriesAsync` or `GetTimeEntriesAsync` function provided by the `ClockodoService` instance.

The difference between the `RawTimeEntry` and the `TimeEntry` class is that the `TimeEntry` class already parses dates and conducts null checks, while the `RawTimeEntry` class only contains primitive times that might also be nullable.

```csharp
// Raw data with priimitive types
var rawTimeEntries = await clockodoService.GetRawTimeEntriesAsync(period);

// Parsed objects
var timeEntries = await clockodoService.GetTimeEntriesAsync(period);
```

### Filters
Clockodo.NET also provides filter functionality for instances of `TimeEntry`. 

There is an `EmployeeFilter` and a `YearFilter`. Those filters can also be combined as needed. 

In the following example we want to get a list of all time entries `John` made in the year `2021`:

```csharp
var filters = new List<IFilterTimeEntries>
{
  new EmployeeFilter(employee),
  new YearFilter(year)
};

var filteredEntries = timeEntries.ApplyAllFilters(filters);       
```

### Grouping
You can also group time entries by employee and customer. This will aggregate the time entries each employee has created for a each customer he worked with.

```csharp
var groupedEntries = timeEntries.GroupByEmployeeAndCustomer();
```
