# Movies

This is the Movies app.

## FE

The front-end, in the movies-client folder, runs on Vue and Foundation. It was created using Node version 18.12.1. It is possible it'll work on older Node versions, but I can't promise that.

## BE

The back-end was built with .NET 6, EntityFramework Core and SQL Server Express.

## Running the FE

Open a terminal in the same folder as this README, and run "npm run dev".
Open the url from the terminal. Make sure the back-end is also running, otherwise the application won't work.
The application expects the back-end to use port 7285. If you are running the back-end on a different port, change it in .\helpers\http.js

## Running the BE

You should have a SQL Server Express LocalDB default instance running for this application. If yoou wish to use a different database, simply change the connection string in appsettings.Development.json.
Make sure to run the back-end using Kestrel, with the "Movies.Api" profile. This way, the 7285 port is chosen and there should be no extra steps required to connect the front-end to the back-end.
