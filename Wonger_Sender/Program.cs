using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Wonga.Model;
using Wonga.RabbitMQ.Services;

namespace Wonger_Sender
{
    class Program
    {        
        public static async Task Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
             .AddSingleton<IMessageService, MessageService>()
             .AddSingleton<IRabbitMQService, RabbitMQService>()
             .BuildServiceProvider();

            var messageService = serviceProvider.GetService<IMessageService>();

            Console.WriteLine("Please enter your name:");
            string userName = Console.ReadLine();

            while (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("name cannot be blank!");
                userName = Console.ReadLine();
            }

            var message = " Hello my name is, " + userName;
            var response = await messageService.SendMessage(userName);

            if (response == true)            
                Console.WriteLine(" Sent {0}", message);            
            else            
                Console.WriteLine(" Message not sent {0}", message);               
                
            
            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}
