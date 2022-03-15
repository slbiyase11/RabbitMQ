using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonga.RabbitMQ.Services
{
    public class MessageService : IMessageService
    {
        private readonly IRabbitMQService _rabbitmqService;

        public MessageService(IRabbitMQService rabbitmqService)
        {
            _rabbitmqService = rabbitmqService;
        }

        public async Task<bool> SendMessage(string message)
        {
            return await Task.Run(() =>
            {
                return _rabbitmqService.SendMessage($"Hello my name is, {message}");
            });           
        }
    }
}
