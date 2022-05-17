using System;
namespace ConsoleMineSweeper.Core.Models
{
    public class Coordinate
    {
        public string XPosition { get; set; }
        public int YPosition { get; set; }
        public string LocationString => XPosition + YPosition.ToString();
    }
}
