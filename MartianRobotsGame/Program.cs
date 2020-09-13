using MartianRobotsGame.Models;
using MartianRobotsGame.Services;
using System;

namespace MartianRobotsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //lost robots leave a robot "scent" that prohibits future robots from dropping off the world at the same grid point.
            //The scent is left at the last grid position the robot occupied before disappearing over the edge. 
            // An instruction to move "off" the world from a grid point from which a robot has been previously lost is simply ignored by the current robot.
            //5 3
            //1 1 E
            //RFRFRFRF
            Console.WriteLine("Type a number with the maximum X coordinate");
            string maxCoordinateX = Console.ReadLine();
            Console.WriteLine("Type a number with the maximum Y coordinate");
            string maxCoordinateY = Console.ReadLine();

            var marsGrid = new MarsGrid(int.Parse(maxCoordinateX), int.Parse(maxCoordinateY));

            Console.WriteLine("Type coord");

            Console.WriteLine($"Initial coordinates {maxCoordinateX} {maxCoordinateY}");

        }
    }
}
