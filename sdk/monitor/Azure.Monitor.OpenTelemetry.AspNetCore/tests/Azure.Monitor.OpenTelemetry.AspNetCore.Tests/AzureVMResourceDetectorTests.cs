// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using OpenTelemetry.Resources.Azure;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.AspNetCore.Tests
{
    public class AzureVMResourceDetectorTests
    {
        [Fact]
        public void DoesNotDetectServiceInstanceId()
        {
            // The exporter uses 'service.instance.id' for Cloud Role Instance and falls back to the host name when it's not set.
            Assert.DoesNotContain("service.instance.id", AzureVMResourceDetector.ExpectedAzureAmsFields);
        }
    }
}
