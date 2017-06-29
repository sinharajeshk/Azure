using Microsoft.ServiceBus.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sbqueuesender
{
    class Program
    {
        static string ConnectionString = "Endpoint=sb://rajeshservicebus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=jho4DKo96odkKFuz+vxp67nQuFlBR/ctn9XHqALaqnE=";
        static string QueuePath = "sbqueue";

        static void Main(string[] args)
        {
            //Service Bus Queue Sender
            var queueClient = QueueClient.CreateFromConnectionString(ConnectionString, QueuePath);
            for (int i = 0; i < 10; i++)
            {
                var message = new BrokeredMessage("Sender's Message ==> " + i);


                //      message.SessionId = “test”;


                queueClient.Send(message);
                Console.Write("\nSent Message : = " + i);
            }

            Console.WriteLine("Press Enter to Exit...");
            Console.ReadLine();
            queueClient.Close();
        }
    }
}