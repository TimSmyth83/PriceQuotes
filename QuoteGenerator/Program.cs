using Microsoft.AspNetCore.SignalR.Client;
using PriceQuotes.Common;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;




        
        Console.WriteLine("Please specify the URL of SignalR Hub");

        var url = Console.ReadLine();

        var hubConnection = new HubConnectionBuilder()
                                 .WithUrl(url)
                                 .Build();
        Random rnd = new Random();
        

        int timekey1 = 0;
        int timekey2 = 0;
        var message = string.Empty;

        try
        {
            await hubConnection.StartAsync();

            while (true)
            {
                if (long.IsEvenInteger(rnd.NextInt64()))
                {
                    //message = "K1 " + "t" + key1 + " " + rnd.NextDouble();
                    var price = new Price
                    {
                        key = "k1",
                        value = new PriceValue { time = "t" + timekey1, value = rnd.NextDouble() }
                    };
                    message = JsonSerializer.Serialize(price);
                    timekey1++;
                    await Task.Delay(500);
                }
                else
                {
                    //message = "K2 " + "t" + timekey2 + " " + rnd.NextDouble();
                    var price = new Price
                    {
                        key = "k2",
                        value = new PriceValue { time = "t" + timekey2, value = rnd.NextDouble() }
                    };
                    message = JsonSerializer.Serialize(price);
                    timekey2++;
                    await Task.Delay(500);
                }

                Console.WriteLine(message);

                await hubConnection.SendAsync("BroadcastMessage", message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return;
        }
    

