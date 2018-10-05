using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.NotificationHubs;


namespace ThesisNotificationsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //SendNotificationAsync();
        }
        private static async void SendNotificationAsync()
        {
            NotificationHubClient hub = NotificationHubClient
                .CreateClientFromConnectionString("Endpoint=sb://fitness30.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=AgLQYes5cAlieEvcJLlGYxt2wLDGbJh5vksTmAZqZNc=", "Fitness30");
            var toast = @"<toast><visual><binding template=""ToastText01""><text id=""1"">Testing Fitness30 Notifications!</text></binding></visual></toast>";
            await hub.SendWindowsNativeNotificationAsync(toast);
        }
    }
}
