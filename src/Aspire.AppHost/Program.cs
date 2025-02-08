using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

var portValueStr = Environment.GetEnvironmentVariable("UVICORN_PORT");
var portValueInt = int.TryParse(portValueStr, out int portParsed) ? portParsed : 8111;

// Python Hosting is Experimental and may change in the future
#pragma warning disable ASPIREHOSTINGPYTHON001
var uvicornApp = builder.AddUvicornApp(
        name: "python",                        // Name of the Python project
        projectDirectory: "../Python.FastAPI", // Path to the Python project
        appName: "app:app",                    // {FILE_NAME}:{APP_VARIABLE_NAME}
        args: new[] { 
            "--reload"
        }
    )
    .WithHttpEndpoint(
        targetPort: portValueInt,      // tatgetPort : Port the resource is listening on
        port: portValueInt + 1         // port : Port that will be exposed to the outside
    );
#pragma warning restore ASPIREHOSTINGPYTHON001

builder.Build().Run();
