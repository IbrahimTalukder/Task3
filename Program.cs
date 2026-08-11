var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Task 3 is running");

app.MapGet("/lcm", (int? x, int? y) =>
{
    if (x == null || y == null || x <= 0 || y <= 0)
    {
        return "NaN";
    }

    int a = x.Value;
    int b = y.Value;

    int gcd(int m, int n)
    {
        while (n != 0)
        {
            int temp = n;
            n = m % n;
            m = temp;
        }
        return m;
    }

    int lcm = Math.Abs(a * b) / gcd(a, b);

    return lcm.ToString();
});

app.Run();