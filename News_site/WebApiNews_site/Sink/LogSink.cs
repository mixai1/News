using Serilog.Core;
using Serilog.Events;
using System;

namespace WebApiNews_site.Sink
{
    public class LogSink : ILogEventSink
    {
        private readonly IFormatProvider _formatProvider;

        public LogSink(IFormatProvider formatProvider)
        {
            _formatProvider = formatProvider;
        }
        public void Emit(LogEvent logEvent)
        {
            var message = logEvent.RenderMessage(_formatProvider);
            var logLevel = logEvent.Level;

            Console.WriteLine($"{DateTime.Now} [{logLevel.ToString().ToUpperInvariant()}] {message}");
        }
    }
}
