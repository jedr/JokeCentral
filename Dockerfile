FROM mcr.microsoft.com/dotnet/sdk:7.0.202 AS build
WORKDIR /source

COPY JokeCentral.sln ./
COPY JokeCentral/*.csproj JokeCentral/
COPY JokeCentral.Api/*.csproj JokeCentral.Api/
COPY JokeCentral.Tests/*.csproj JokeCentral.Tests/
COPY OpenTelemetryExtensions/*.csproj OpenTelemetryExtensions/
RUN dotnet restore JokeCentral.sln

COPY JokeCentral/ JokeCentral/
COPY JokeCentral.Api/ JokeCentral.Api/
COPY JokeCentral.Tests/ JokeCentral.Tests/
COPY OpenTelemetryExtensions/ OpenTelemetryExtensions/
RUN dotnet build -c Release --no-restore

FROM build as test
ENTRYPOINT ["dotnet", "test", "-c", "Release", "--no-restore", "--no-build"]

FROM build AS publish
RUN dotnet publish JokeCentral -c Release --no-build -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0.3
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JokeCentral.dll"]
