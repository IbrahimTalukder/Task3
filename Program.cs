var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Task 3 is running");

app.MapGet("/{email}", (string email, string? x, string? y) =>
{
    if (x == null || y == null)
    {
        return Results.Text("NaN", "text/plain");
    }                   
    bool validX = long.TryParse(x, out long a) && a >= 1;
    bool validY = long.TryParse(y, out long b) && b >= 1;

    if (!validX || !validY)
    {
        return Results.Text("NaN", "text/plain");
    }

    long gcdVal = Gcd(a, b);
    long lcmVal = Math.Abs(a * b) / gcdVal;

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