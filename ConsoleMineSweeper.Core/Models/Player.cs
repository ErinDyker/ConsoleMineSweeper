using System;
namespace ConsoleMineSweeper.Core.Models
{
    public class Player
    {
       public int Lives { get; set; }
       public Coordinate CurrentPosition { get; set; }
    }
}
