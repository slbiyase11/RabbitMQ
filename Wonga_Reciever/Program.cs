using System;
using Wonga.RabbitMQ.Services;

namespace Wonga_Reciever
{
    class Program
    {
        public static void Main(string[] args)
        {
            IRabbitMQService _RabbitMQService = new RabbitMQService();
            Console.WriteLine("Listening.........");
            var response = _RabbitMQService.GetMessage();
            if (!string.IsNullOrEmpty(response))
            {
                int position = response.LastIndexOf(',');
                var name = response.Substring(position+1);
                Console.WriteLine("Hello ", name + "I am your father!");
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(" ERROR!");
            }

        }
    }
}
