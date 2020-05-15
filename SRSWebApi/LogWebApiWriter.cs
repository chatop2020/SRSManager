using System;
using System.IO;

namespace SRSWebApi
{
    public static class LogWebApiWriter
    {
        public static object lockLogFile = new object();

        public static void WriteWebApiLog(string message, string info = "", ConsoleColor color = ConsoleColor.Gray)
        {
            if (color != ConsoleColor.Gray)
            {
                Console.ForegroundColor = color;
            }

            DateTime now = DateTime.Now;
            string logPath = Path.Combine(Environment.CurrentDirectory, "logs", $@"webapilog_Y{now.Year}M{now.Month}D{now.Day}.log");
            string saveLogTxt = "[" + DateTime.Now.ToString() + "]\t" + message + "\t" + info + "\r\n";
            Console.WriteLine(saveLogTxt.Trim());
            if (color != ConsoleColor.Gray)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            lock (lockLogFile)
            {
                File.AppendAllText(logPath, saveLogTxt);
            }
        }
    }
}