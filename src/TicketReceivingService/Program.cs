var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseHttpsRedirection();

app.MapPost("/ticket", (Ticket ticket) =>
{
    Console.WriteLine($"Ticket received: {ticket}");

    return ticket;
});

app.Run();