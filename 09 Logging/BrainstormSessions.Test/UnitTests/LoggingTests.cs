using BrainstormSessions.Api;
using BrainstormSessions.Controllers;
using BrainstormSessions.Core.Interfaces;
using BrainstormSessions.Core.Model;
using FluentAssertions;
using Moq;
using Serilog;
using Serilog.Sinks.TestCorrelator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BrainstormSessions.Test.UnitTests
{
    public class LoggingTests : IDisposable
    {
        private readonly ILogger _logger;

        public LoggingTests()
        {
            _logger = new LoggerConfiguration().WriteTo.Sink(new TestCorrelatorSink()).CreateLogger();
        }

        public void Dispose()
        {
        }

        [Fact]
        public async Task HomeController_Index_LogInfoMessages()
        {
            using (TestCorrelator.CreateContext())
            {
                // Arrange
                var mockRepo = new Mock<IBrainstormSessionRepository>();
                mockRepo.Setup(repo => repo.ListAsync())
                    .ReturnsAsync(GetTestSessions());
                var controller = new HomeController(mockRepo.Object, _logger);

                // Act
                var result = await controller.Index();

                // Assert
                TestCorrelator.GetLogEventsFromCurrentContext().Should().ContainSingle();
            }
        }

        [Fact]
        public async Task HomeController_IndexPost_LogWarningMessage_WhenModelStateIsInvalid()
        {
            using (TestCorrelator.CreateContext())
            {
                // Arrange
                var mockRepo = new Mock<IBrainstormSessionRepository>();
                mockRepo.Setup(repo => repo.ListAsync())
                    .ReturnsAsync(GetTestSessions());
                var controller = new HomeController(mockRepo.Object, _logger);
                controller.ModelState.AddModelError("SessionName", "Required");
                var newSession = new HomeController.NewSessionModel();

                // Act
                var result = await controller.Index(newSession);

                // Assert
                TestCorrelator.GetLogEventsFromCurrentContext().Should().ContainSingle("Required");
            }
        }

        [Fact]
        public async Task IdeasController_CreateActionResult_LogErrorMessage_WhenModelStateIsInvalid()
        {
            using (TestCorrelator.CreateContext())
            {
                // Arrange & Act
                var mockRepo = new Mock<IBrainstormSessionRepository>();
                var controller = new IdeasController(mockRepo.Object, _logger);
                controller.ModelState.AddModelError("error", "some error");

                // Act
                var result = await controller.CreateActionResult(model: null);

                // Assert
                TestCorrelator.GetLogEventsFromCurrentContext().Should().ContainSingle();
            }
        }

        [Fact]
        public async Task SessionController_Index_LogDebugMessages()
        {
            using (TestCorrelator.CreateContext())
            {
                // Arrange
                int testSessionId = 1;
                var mockRepo = new Mock<IBrainstormSessionRepository>();
                mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                    .ReturnsAsync(GetTestSessions().FirstOrDefault(
                        s => s.Id == testSessionId));
                var controller = new SessionController(mockRepo.Object, _logger);

                // Act
                var result = await controller.Index(testSessionId);

                //// Assert
                TestCorrelator.GetLogEventsFromCurrentContext().Should().ContainSingle();
            }
        }

        private List<BrainstormSession> GetTestSessions()
        {
            var sessions = new List<BrainstormSession>();
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Test One"
            });
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 1),
                Id = 2,
                Name = "Test Two"
            });
            return sessions;
        }

    }
}
