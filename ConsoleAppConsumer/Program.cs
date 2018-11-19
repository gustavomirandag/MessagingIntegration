using ConsoleAppConsumer.DTOs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            const string queueName = "tickets";


            //Storage Account
            var storageAccount = CloudStorageAccount.Parse("COLOQUE AQUI SUA STRING DE CONEXÃO");

            //Queue Client
            var queueClient = storageAccount.CreateCloudQueueClient();

            //Queue
            var queue = queueClient.GetQueueReference(queueName);

            string messageText;
            do
            {
                var message = queue.GetMessage();
                messageText = message.AsString;
                try
                {
                    var product = Newtonsoft.Json.JsonConvert.DeserializeObject<Product>(messageText);
                    Console.WriteLine($"{product.Title} - {product.Price}");
                }
                catch (Exception ex) { Console.WriteLine(messageText); };
                System.Threading.Thread.Sleep(1000);
            } while (messageText != "quit");
        }
    }
}
