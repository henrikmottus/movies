# Movies.Api

This is the back-end for the Movies web app. It's built with .NET 6, EntityFramework Core and SQL Server Express.

## Running the application

You should have a SQL Server Express LocalDB default instance running for this application. If yoou wish to use a different database, simply change the connection string in appsettings.Development.json.
Make sure to run the back-end using Kestrel, with the "Movies.Api" profile. This way, there are no extra steps required to connect the front-end to the back-end.