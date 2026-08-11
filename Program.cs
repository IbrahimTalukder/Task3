using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Task 3 is running");

app.MapGet("/ibrahimtalukder039_gmail_com", (int? x, int? y) =>
{
    if (x == null || y == null || x <= 0 || y <= 0)
    {
        return "NaN";
    }

    int a = x.Value;
    int b = y.Value;

    int GCD(int m, int n)
    {
        while (n != 0)
        {
            int temp = n;
            n = m % n;
            m = temp;
        }

        return m;
    }

    int lcm = Math.Abs(a * b) / GCD(a, b);

    return lcm.ToString();
});

app.Run();