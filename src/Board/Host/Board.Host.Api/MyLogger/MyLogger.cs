namespace Board.Host.Api.MyLogger
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MyLogger<T> : ILogger<T>
    {

        public IDisposable BeginScope<TState>(TState state)
        {
            return default!;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            Console.WriteLine($"[{DateTime.Now}] {logLevel} EVENT = {eventId} {formatter(state, exception)} ");
        }
    }
}
