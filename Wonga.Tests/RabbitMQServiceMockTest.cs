using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonga.RabbitMQ.Services;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Wonga.RabbitMQ.Tests
{
    [TestClass]
    public class RabbitMQServiceMockTest
    {
        private IServiceProvider _serviceProvider;
        [TestInitialize]
        public void Initialize()
        {
            _serviceProvider = ServicesProvider.GetServiceProvider();
        }
        [TestMethod]
        public void SendMessageTest()
        {
            var message = " Hello my name is, Wonga";

            Mock<IRabbitMQService> rabbitService = new Mock<IRabbitMQService>();
            rabbitService.Setup(x => x.SendMessage(message)).Returns(true);

            var result = rabbitService.Object.SendMessage(message);
            Assert.IsTrue(result);
        }
    }
}

