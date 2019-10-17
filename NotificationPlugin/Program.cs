using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace NotificationPlugin
{

    class Program
    {
        static HttpClient client = new HttpClient(); //initializing client

        static int flag = 0;

        static void ShowNotifications(List<Notification> notifications)
        {
            foreach (Notification ntf in notifications)
            {
                Console.WriteLine($"Type: {ntf.tip}\tMessage: " +
                $"{ntf.message}\tScope: {ntf.scope}");
            }
          
        }

        static async Task<List<Notification>> GetNotificationsAsync(string path)
        {
            List<Notification> notifications = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                notifications = await response.Content.ReadAsAsync<List<Notification>>();
            }
            return notifications;
        }

        static void Main(string[] args)
        {
          
            while (true)
            {
                Thread.Sleep(10 * 1000);
                Console.WriteLine("*** pulling new notifications *** ");
                RunAsync().GetAwaiter().GetResult();
                flag = 1;
            }


        }

        static async Task RunAsync()
        {

            if (flag == 0) {
                client.BaseAddress = new Uri("http://localhost:25586/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            }

         

            try
            { 
               
                List<Notification> notifications = await GetNotificationsAsync("api/device/notifications/1");
                ShowNotifications(notifications);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
