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