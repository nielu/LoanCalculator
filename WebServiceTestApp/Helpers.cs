using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTestApp
{
    public static class Helpers
    {
        public static LogLevel TestResult = LogLevel.PASS;

        public static void LogMessage(string message, LogLevel level = LogLevel.INFO)
        {
            switch (level)
            {
                case LogLevel.EXCEPTION:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case LogLevel.FAIL:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.WARN:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogLevel.PASS:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                default:
                    break;
            }

            Console.WriteLine($"{DateTime.Now} {level} {message}");
            Console.ResetColor();

            if (level > TestResult)
                TestResult = level;
        }

    }

    public enum LogLevel
    {
        INFO = 0,
        PASS,
        WARN,
        FAIL,
        EXCEPTION
    }
}
