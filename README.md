# README

## environments

- What I want to do : 
  - Applying opentelemetry to Uvicorn/FastAPI, 
  - and see structured Logs in Aspire Dashboard

- Symptoms
  - In Aspire Dashboard Console prints Error
```
2025-02-08T15:34:51 Usage: uvicorn [OPTIONS] APP
2025-02-08T15:34:51 Try 'uvicorn --help' for help.
2025-02-08T15:34:51
2025-02-08T15:34:51 Error: No such option: --traces_exporter
```
  - When .venv has `opentelemetry-instrument`
  - `UvicornAppHostingExtension.cs` add following arguments automatically
  - However, `uvicorn` does not support those options
```
private static void AddOpenTelemetryArguments(CommandLineArgsCallbackContext context)
{
    context.Args.Add("--traces_exporter");
    context.Args.Add("otlp");

    context.Args.Add("--logs_exporter");
    context.Args.Add("console,otlp");

    context.Args.Add("--metrics_exporter");
    context.Args.Add("otlp");
}
```

## Getting Started
- Environments
  - python 3.12
  - dotnet 9
  - mac M1

- Python virtual environments setting
```
cd src/Python.FastAPI
python3.12 -m venv .venv
. .venv/bin/activate
pip install -r requirements.txt
```

- Run Aspire.AppHost
```
cd src
dotnet run --project Aspire.AppHost/Aspire.AppHost.csproj
```
