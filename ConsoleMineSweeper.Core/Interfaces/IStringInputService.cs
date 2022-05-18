using System;
namespace ConsoleMineSweeper.Core.Interfaces
{
    public interface IStringInputService
    {
        void WriteString(string toWrite);
        string GetStringInput();
    }
}
