using Azure.Messaging.ServiceBus;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("/ticket", async (Ticket ticket) =>
{
    Console.WriteLine($"Ticket received: {ticket}");

    // Publish the ticket to Azure Service Bus
    ServiceBusClient client = new ServiceBusClient(builder.Configuration["ServiceBus:ConnectionString"]);

    ServiceBusSender sender = client.CreateSender("tickets-queue");
    try
    {
        await sender.SendMessageAsync(new ServiceBusMessage(JsonSerializer.Serialize(ticket)));
        Console.WriteLine($"Ticket message has been published to the queue.");
    }
    catch
    {
        Console.WriteLine("Error occured while sending the message to the queue!");
        throw;
    }
    finally
    {
        await sender.DisposeAsync();
        await client.DisposeAsync();
    }

    return ticket;
});

app.Run();