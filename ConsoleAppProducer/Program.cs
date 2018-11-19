using ConsoleAppProducer.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProducer
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

            //Create Queue if it doesn't exist
            queue.CreateIfNotExists();

            //string messageText;

            for (int i=0; i<99999; i++)
            {
                //Product
                Random rand = new Random();
                Product product = new Product();
                product.Id = Guid.NewGuid();
                product.Title = "Product " + rand.Next();
                product.Price = rand.Next();
                var message = new CloudQueueMessage(Newtonsoft.Json.JsonConvert.SerializeObject(product));
                queue.AddMessage(message);
            }

            //do
            //{
            //    Console.WriteLine("Type something to enqueue");
            //    messageText = Console.ReadLine();
            //    var message = new CloudQueueMessage(messageText);
            //    queue.AddMessage(message);
            //} while (messageText != "quit");
        }
    }
}
