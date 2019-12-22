using hive_interview.Controllers;
using hive_interview.Data;
using hive_interview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using Xunit;

namespace hive_interview.tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsAViewResult_WithAListOfLocations()
        {
            // Arrange
            var mockRepo = new LocationTestRepository();
            ConfigModel config = new ConfigModel() { LimitLocationRows = 10 };
            IOptions<ConfigModel> options = Options.Create(config);
            var controller = new HomeController(options, mockRepo);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(
                viewResult.ViewData.Model);
            Assert.Equal(4, model.Locations.Count);
        }

        [Fact]
        public void Index_ReturnsAViewResult_WithCorrectLimitLocationRowsConfigSetting()
        {
            // Arrange
            var mockRepo = new LocationTestRepository();
            ConfigModel config = new ConfigModel() { LimitLocationRows = 10 };
            IOptions<ConfigModel> options = Options.Create(config);
            var controller = new HomeController(options, mockRepo);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(
                viewResult.ViewData.Model);
            Assert.Equal(10, model.LimitLocationRows);
        }
    }
}
