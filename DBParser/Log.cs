using System.Diagnostics;
using System.IO;

namespace Iswenzz.AION.DBParser
{
    public static class Log
    {
        public static void Config(FileStream path)
        {
            Trace.Listeners.Clear();

            ConsoleTraceListener console = new ConsoleTraceListener(false);
            TextWriterTraceListener file = new TextWriterTraceListener(path);
            file.Name = "Console Log";
            file.TraceOutputOptions = TraceOptions.DateTime;

            Trace.Listeners.Add(console);
            Trace.Listeners.Add(file);
            Trace.AutoFlush = true;
        }
    }
}
