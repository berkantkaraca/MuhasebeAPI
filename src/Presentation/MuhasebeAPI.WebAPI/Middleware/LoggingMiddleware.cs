namespace MuhasebeAPI.WebAPI.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;
    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        string content = $"İstek atılan metod => {context.Request.Method}\nYol(URL) => {context.Request.Path.Value}\n{Environment.NewLine}";

        try
        {
            File.AppendAllText("Log.txt", content);
            await _next.Invoke(context);
            //Console.WriteLine($"İşletim Sistemi ve Versiyon => {Environment.OSVersion}");
        }
        catch (Exception exeption)
        {
            content += $"\nOluşan Hata => {exeption.Message}{Environment.NewLine}";
            File.AppendAllText("Log.txt", content);
        }
    }
}
