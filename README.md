# Azure SDK for .NET

This is Faithlife's fork of [Azure SDK for .NET](https://github.com/Azure/azure-sdk-for-net).
For more information about the packages, see the upstream documentation.

## Branches

This repo contains the following branches:

* [monitor](https://github.com/Faithlife/azure-sdk-for-net/tree/monitor/sdk/monitor) - Azure.Monitor.OpenTelemetry.AspNetCore and Azure.Monitor.OpenTelemetry.Exporter

## Building Monitor

Clone the repo.
In the repo root, run `dotnet build build.proj /p:Scope=monitor` to install dependencies and build the project.

You can then open `sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter.slnx` in Visual Studio to work on the code.

To create packages, in the `sdk/monitor` folder run:

```
 dotnet pack -c Release -p:SkipDevBuildNumber=true -p:HasReleaseVersion=false -p:VersionSuffix=faithlife.1
 ```

 You will need to update [OpenTelemetry CHANGELOG](sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/CHANGELOG.md) and [Exporter CHANGELOG](sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/CHANGELOG.md) first with an entry for the new version.
 The packages will be created in `artifacts/packages/Release`.
