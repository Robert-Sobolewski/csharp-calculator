using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using CalculatorAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPITest
{
    [TestFixture]
    public class CalculatorControllerTests
    {
        private CalculatorController controller;
        private Mock<ILogger<CalculatorController>> loggerMock;
        private Mock<IConfiguration> configurationMock;

        [SetUp]
        public void Setup()
        {
            configurationMock = new Mock<IConfiguration>();
            loggerMock = new Mock<ILogger<CalculatorController>>();

            // create controller instance with mock
            controller = new CalculatorController(configurationMock.Object, loggerMock.Object);
        }

        [Test]
        [TestCase(1,2,3)]
        [TestCase(2,3,5)]
        public void Add_ShouldReturnSumOfTwoNumbers(double a, double b, double expected)
        {
            var result = controller.Add(a, b) as OkObjectResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, 2, -1)]
        [TestCase(2, 3, -1)]
        public void Substract_ShouldReturnSubstactOfTwoNumbers(double a, double b, double expected)
        {
            var result = controller.Substract(a, b) as OkObjectResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(1, 2, 2)]
        [TestCase(2, 3, 6)]
        [TestCase(-2,3,-6)]
        public void Multiply_ShouldReturnMultiplyOfTwoNumbers(double a, double b, double expected)
        {
            var result = controller.Multiply(a, b) as OkObjectResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.EqualTo(expected));
        }


        [Test]
        [TestCase(1, 2, 0.5)]
        [TestCase(24, 4, 6)]
        [TestCase(1,0,Double.PositiveInfinity)]
        public void Divide_ShouldReturnDivideOfTwoNumbers(double a, double b, double expected)
        {
            var result = controller.Divide(a, b) as OkObjectResult;
            // Assert
            Assert.IsNotNull(result);
            Assert.That(result.StatusCode, Is.EqualTo(200));
            Assert.That(result.Value, Is.EqualTo(expected));
        }


    }
}