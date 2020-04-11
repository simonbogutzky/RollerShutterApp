/*
 The MIT License (MIT)
 Copyright (c) 2020 Simon Bogutzky
 
 Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Threading.Tasks;
using RollerShutter.NET;
using Serilog;
using Serilog.Events;
using Xunit;
using Xunit.Abstractions;

namespace RollerShutter.XUnit
{
    public class RollerShutterManagerTests
    {
        public RollerShutterManagerTests(ITestOutputHelper output)
        {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.TestOutput(output, LogEventLevel.Information)
                .CreateLogger()
                .ForContext<RollerShutterManagerTests>();
        }

        private readonly RollerShutterManager _manager = new RollerShutterManager("192.168.2.56");
        private readonly ILogger _logger;

        [Fact]
        public async Task GetFirmwareVersion()
        {
            try
            {
                var firmwareVersion = await _manager.GetFirmwareVersion();
                Assert.IsType<string>(firmwareVersion);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Something went wrong:");
                Assert.True(false);
            }
        }

        [Fact]
        public async Task MoveDown()
        {
            try
            {
                var responseOk = await _manager.MoveDown();
                Assert.True(responseOk);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Something went wrong:");
                Assert.True(false);
            }
        }

        [Fact]
        public async Task MoveUp()
        {
            try
            {
                var responseOk = await _manager.MoveUp();
                Assert.True(responseOk);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Something went wrong:");
                Assert.True(false);
            }
        }

        [Fact]
        public async Task Stop()
        {
            try
            {
                var responseOk = await _manager.Stop();
                Assert.True(responseOk);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, "Something went wrong:");
                Assert.True(false);
            }
        }
    }
}