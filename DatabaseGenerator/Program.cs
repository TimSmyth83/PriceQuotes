
using Microsoft.AspNetCore.SignalR.Client;
using PriceQuotes.Common;
using System.Text.Json;




var url = "https://localhost:7208/quoteHub";
var hubConnection = new HubConnectionBuilder()
                         .WithUrl(url)
                         .Build();
string jsonString = string.Empty;
var context = new DatabaseContext();


hubConnection.On<string>("ReceiveMessage",
    message => jsonString = message);
try
{
    await hubConnection.StartAsync();
    Price? LastPrice;

    while (true)
    {

        try
        {
            if (!string.IsNullOrEmpty(jsonString))
            {
                LastPrice = JsonSerializer.Deserialize<Price>(jsonString)!;
                Console.WriteLine($"The key is {LastPrice.key}");
                context.Add<Price>(LastPrice);
                context.SaveChanges();
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($" Deserialize Message = {ex.Message}");
            Console.WriteLine(jsonString);
            Console.ReadKey();
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Failed to connect {ex.Message}");
    //Console.WriteLine("Press any key to exit...");
    //Console.ReadKey();
    return;
}


