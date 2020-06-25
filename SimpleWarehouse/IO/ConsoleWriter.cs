using System;
using SimpleWarehouse.Interfaces;

namespace SimpleWarehouse.IO
{
    public class ConsoleWriter : IOutputWriter
    {
        public void Log(string message)
        {
            WriteLine(message);
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj + "");
        }
    }
}