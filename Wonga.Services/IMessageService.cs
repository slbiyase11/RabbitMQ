using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wonga.RabbitMQ.Services
{
    public interface IMessageService
    {
        Task<bool> SendMessage(string message);
    }
}
