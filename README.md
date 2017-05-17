# APIExcercise

To run from the command line you will:  
 1. Make sure you have the .NET Core command line interface installed.
  - Found here (https://docs.microsoft.com/en-us/dotnet/articles/core/tools/)
 2. Open command line and navigate to the folder that contains the APIExercise.csproj file.
 3. Execute the following 

> dotnet restore

The following will run the service under port 80
> dotnet run

The following will allow you to run the service under any port
> dotnet run --server.urls "http://localhost:5100;http://localhost:5101;http://*:5102"
