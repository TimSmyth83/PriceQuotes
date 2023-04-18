
using Microsoft.AspNetCore.SignalR.Client;
using PriceQuotes.Common;
using System.Text.Json;




var url = "https://localhost:7208/quoteHub";

var hubConnection = new HubConnectionBuilder()
                         .WithUrl(url)
                         .Build();
string jsonString = string.Empty;
var context = new DatabaseContext();

//hubConnection.On<string>("ReceiveMessage",
//   message => Console.WriteLine($"SignalR Hub Message: {message}"));

hubConnection.On<string>("ReceiveMessage",
    message => jsonString = message);

//var LastPrice =
//                JsonSerializer.Deserialize<Price>(jsonString)!;

//Console.WriteLine("key = " + LastPrice.key + " " + "time = " + LastPrice.value.time + " " + "value = " + LastPrice.value.value);


try
{
    await hubConnection.StartAsync();
    Price? LastPrice;

    while (true)
    {
        //  Console.WriteLine(jsonString);
        try
        {
            if (!string.IsNullOrEmpty(jsonString))
            {
                LastPrice = JsonSerializer.Deserialize<Price>(jsonString)!;
                Console.WriteLine($"The key is {LastPrice.key}");
                context.Add<Price>(LastPrice);
                context.SaveChanges();
            }
            //    //var message = string.Empty;

            //    //Console.WriteLine("Please specify the action:");
            //    //Console.WriteLine("0 - broadcast to all");
            //    //Console.WriteLine("exit - Exit the program");

            //    //var action = Console.ReadLine();

            //    //Console.WriteLine("Please specify the message:");
            //    //message = Console.ReadLine();

            //    //if (action == "exit")
            //    //    break;

            //    //  await hubConnection.SendAsync("BroadcastMessage");
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


//String str;
//SqlConnection myConn = new SqlConnection("Server=JIMS;Integrated security=SSPI;database=master");

//str = "CREATE DATABASE MyDatabase";
//SqlCommand myCommand = new SqlCommand(str, myConn);
//try
//{
//    myConn.Open();
//    myCommand.ExecuteNonQuery();
//    Console.WriteLine("DataBase is Created Successfully");
//}
//catch (System.Exception ex)
//{
//    Console.WriteLine("DataBase creation failed");
//    Console.WriteLine(ex.Message);
//}
//finally
//{
//    if (myConn.State == ConnectionState.Open)
//    {
//        myConn.Close();
//    }
//}

//str = "CREATE TABLE Prices\r\n( \r\n   [Key] VARCHAR(2),\r\n   [Time] VARCHAR(2),\r\n   \r\n)";
// myCommand = new SqlCommand(str, myConn);
//try
//{
//    myConn.Open();
//    myCommand.ExecuteNonQuery();
//    Console.WriteLine("Table is Created Successfully");
//}
//catch (System.Exception ex)
//{
//    Console.WriteLine("Table creation failed");
//    Console.WriteLine(ex.Message);
//}
//finally
//{
//    if (myConn.State == ConnectionState.Open)
//    {
//        myConn.Close();
//    }
//}