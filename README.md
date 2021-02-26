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

You should also see traces in the app's console.

```console
Activity.Id:          00-42e7b9e6ee08d640ae9f8983f35f6383-ed6cfd1200481d44-01
Activity.ParentId:    00-42e7b9e6ee08d640ae9f8983f35f6383-948b4dc7a080db41-01
Activity.DisplayName: /jokes/random
Activity.Kind:        Client
Activity.StartTime:   2020-10-13T11:16:03.0554829Z
Activity.Duration:    00:00:00.3821901
Activity.TagObjects:
    http.method: GET
    http.host: api.chucknorris.io
    http.url: https://api.chucknorris.io/jokes/random
    http.status_code: 200
    otel.status_code: Ok

Activity.Id:          00-42e7b9e6ee08d640ae9f8983f35f6383-948b4dc7a080db41-01
Activity.DisplayName: /
Activity.Kind:        Server
Activity.StartTime:   2020-10-13T11:16:03.0544616Z
Activity.Duration:    00:00:00.3878141
Activity.TagObjects:
    http.host: localhost:5001
    http.method: GET
    http.path: /
    http.url: https://localhost:5001/
    http.user_agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36
    http.status_code: 200
    otel.status_code: Ok
```
