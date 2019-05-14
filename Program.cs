using Microsoft.Azure.EventHubs;
using System.Text;
using System.Threading.Tasks;
using System;

namespace appDev
{
    class Program
    {

        private static EventHubClient eventHubClient;
        private const string EventHubConnectionString = "Endpoint=sb://apptestevthub.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Sz2HKOIWf85t62/34O/laxt3V2oUiP2HcLn2tcLIb58=";
        private const string EventHubName = "apptestevthub";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var eventConnectionBuilder = new EventHubsConnectionStringBuilder(EventHubConnectionString)
            {
                EntityPath = EventHubName
            };
        
            eventHubClient = new EventHubClient.CreateFromConnectionString(EventHubConnectionString);

            await SendMessage(100);

        }

        private async Task SendMessage(int count) { 

           var message = "sending message content "  + DateTime.Now.ToShortDateString();
           await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(message)));
        }
    }
}
