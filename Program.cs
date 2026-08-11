var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Task 3 is running");

app.MapGet("/{email}", (string email, string? x, string? y) =>
{
    Console.WriteLine($"Request received: email={email}, x={x}, y={y}, time={DateTime.UtcNow}");

    bool validX = long.TryParse(x, out long a) && a >= 1;
    bool validY = long.TryParse(y, out long b) && b >= 1;

    if (!validX || !validY)
    {
        Console.WriteLine("Returning NaN");
        return Results.Text("NaN", "text/plain");
    }

    long gcdVal = Gcd(a, b);
    long lcmVal = Math.Abs(a * b) / gcdVal;

    Console.WriteLine($"Returning result: {lcmVal}");
    return Results.Text(lcmVal.ToString(), "text/plain");
});

long Gcd(long m, long n)
{
    while (n != 0)
    {
        long temp = n;
        n = m % n;
        m = temp;
    }
    return m;
}

app.Run();