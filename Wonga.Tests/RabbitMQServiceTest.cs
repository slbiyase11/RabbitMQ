using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wonga.RabbitMQ.Services;

namespace Wonga.RabbitMQ.Tests
{
    [TestClass]
    public class RabbitMQServiceTest
    {
        private IRabbitMQService _rabbitMQService;
        private IServiceProvider _serviceProvider;
        [TestInitialize]
        public void Initialize()
        {
            _serviceProvider = ServicesProvider.GetServiceProvider();
            _rabbitMQService = _serviceProvider.GetService<IRabbitMQService>();
        }
        [TestMethod]
        public void SendMessageTest()
        {
            var message = " Hello my name is, Wonga";
            var result = _rabbitMQService.SendMessage(message);

            Assert.IsTrue(result);
        }
    }
}
