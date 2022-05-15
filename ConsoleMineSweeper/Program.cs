using System;
using System.Threading.Tasks;
using ConsoleMineSweeper.Core.Interfaces;
using ConsoleMineSweeper.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleMineSweeper
{
    public class Program
    {

        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args);

            host.Services.GetService<BaseGame>().Initialise();

        }

        public static IHost CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
           .ConfigureServices((_, services) =>
           {
               services.AddTransient<IMineCreatorService, MineCreatorService>()
                       .AddTransient<IMovementController, MovementController>()
                       .AddTransient<BaseGame>();
           }).Build();
    }
}





//one side to the other movement
//x number of lives, lose one when you hit a mine
//final score with the number of steps to reach the other side
//simple command interface
//end position shown eg C2
//number of lives left shown
//