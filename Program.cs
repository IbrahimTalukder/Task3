using System.Numerics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Task 3 is running");

app.MapGet("/{email}", (string email, string? x, string? y) =>
{
    Console.WriteLine($"Request received: email={email}, x={x}, y={y}, time={DateTime.UtcNow}");

    bool validX = BigInteger.TryParse(x, out BigInteger a) && a >= 1;
    bool validY = BigInteger.TryParse(y, out BigInteger b) && b >= 1;

    if (!validX || !validY)
    {
        Console.WriteLine("Returning NaN");
        return Results.Text("NaN", "text/plain");
    }

    BigInteger gcdVal = BigInteger.GreatestCommonDivisor(a, b);
    BigInteger lcmVal = BigInteger.Abs(a / gcdVal * b);

    Console.WriteLine($"Returning result: {lcmVal}");
    return Results.Text(lcmVal.ToString(), "text/plain");
});

app.Run();