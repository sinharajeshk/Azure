using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbqueuereceiver
{
    class Program
    {
        static string ConnectionString = "Endpoint=sb://rajeshservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=jho4DKo96odkKFuz+vxp67nQuFlBR/ctn9XHqALaqnE=";
        static string QueuePath = "sbqueue";


        static void Main(string[] args)
        {
            //Service Bus Queue Receiver
            var queueClient = QueueClient.CreateFromConnectionString(ConnectionString, QueuePath);

            queueClient.OnMessage(msg => ProcessMessage(msg));

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();

            queueClient.Close();
        }

        private static void ProcessMessage(BrokeredMessage msg)
        {
            var text = msg.GetBody<string>();
            Console.WriteLine("\nReceived Messages : " + text);
        }


    }
}
