using System;
using ConsoleMineSweeper.Core.Interfaces;

namespace ConsoleMineSweeper.Core.Services
{
    public class StringInputService : IStringInputService
    {
        public string GetStringInput()
        {
            return Console.ReadLine();
        }

        public void WriteString(string toWrite)
        {
            Console.WriteLine(toWrite);
        }
    }
}
