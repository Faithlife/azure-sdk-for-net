// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Trace;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class UseAzureMonitorExporterSamplerTests
    {
        private const string ConnStr = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        [Fact]
        public void UseAzureMonitorExporterDoesNotSetSampler()
        {
            var services = new ServiceCollection();
            services.AddOpenTelemetry()
                .UseAzureMonitorExporter(o =>
                {
                    o.ConnectionString = ConnStr;
                    o.EnableLiveMetrics = false;
                    o.EnableStatsbeat = false;
                });

            using var serviceProvider = services.BuildServiceProvider();
            var tracerProvider = serviceProvider.GetRequiredService<TracerProvider>();

            // Sampling is handled at the Application Insights ingestion layer, so the OpenTelemetry SDK default sampler should be used.
            var samplerProperty = tracerProvider.GetType().GetProperty("Sampler", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            Assert.NotNull(samplerProperty);
            Assert.IsType<ParentBasedSampler>(samplerProperty!.GetValue(tracerProvider));
        }
    }
}
