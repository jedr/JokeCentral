# Joke Central

An exercise to write an ASP.NET Core app instrumented with OpenTelemetry tracing.

## Running locally

### Running in Docker

This should work with both Linux and Windows containers.

```sh
docker build -t joke-central .
docker run --rm -it --publish 5000:80 joke-central
```

Go to <http://localhost:5000>. You should see a line of text containing a joke.

To only run tests in Docker, run:

```sh
docker build --target test -t joke-central-test .
docker run --rm -it joke-central-test
```

### Running on bare metal

This should run on either Windows, Linux or MacOS.

Requirements:

- .NET SDK 5.0 - see install instructions: <https://docs.microsoft.com/en-us/dotnet/core/install/>

To build:

```sh
dotnet build
```

To test:

```sh
dotnet test
```

To run, first go to the ASP.NET Core app's directory `JokeCentral`:

```sh
cd JokeCentral
dotnet run
```

Go to <http://localhost:5000>. You should see a line of text containing a joke.

You should also see traces and logs in the app's console similar to the example below.

As you can see, the log can be correlated with the traces via its TraceId.

```console
Activity.Id:          00-537b7082b5631d49acb223f3926fccdf-8e386e2e1c4ccb4a-01
Activity.ParentId:    00-537b7082b5631d49acb223f3926fccdf-32255babfe608046-01
Activity.DisplayName: /jokes/random
Activity.Kind:        Client
Activity.StartTime:   2021-03-03T22:07:56.3009862Z
Activity.Duration:    00:00:00.3696803
Activity.TagObjects:
    http.method: GET
    http.host: api.chucknorris.io
    http.url: https://api.chucknorris.io/jokes/random
    http.status_code: 200
    otel.status_code: UNSET
Resource associated with Activity:
    service.name: unknown_service:JokeCentral

LogRecord.TraceId:            537b7082b5631d49acb223f3926fccdf
LogRecord.SpanId:             32255babfe608046
LogRecord.Timestamp:          2021-03-03T22:07:56.6800324Z
LogRecord.EventId:            0
LogRecord.CategoryName:       JokeCentral.Controllers.ApiController
LogRecord.LogLevel:           Information
LogRecord.TraceFlags:         Recorded
LogRecord.State:              Joke: When Chuck Norris shaves the razor blades get cut.

Activity.Id:          00-537b7082b5631d49acb223f3926fccdf-32255babfe608046-01
Activity.DisplayName: /
Activity.Kind:        Server
Activity.StartTime:   2021-03-03T22:07:56.2461798Z
Activity.Duration:    00:00:00.4431696
Activity.TagObjects:
    http.host: localhost:5000
    http.method: GET
    http.path: /
    http.url: http://localhost:5000/
    http.user_agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:86.0) Gecko/20100101 Firefox/86.0
    http.status_code: 200
    otel.status_code: UNSET
Resource associated with Activity:
    service.name: unknown_service:JokeCentral
```
