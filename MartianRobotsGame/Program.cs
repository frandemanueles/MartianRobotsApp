using MartianRobotsGame.Models;
using MartianRobotsGame.Services;
using System;
using System.Collections.Generic;

namespace MartianRobotsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //5 3
            //1 1 E
            //RFRFRFRF
            TypeRobotMoves();
        }

        private static void TypeRobotMoves()
        {
            string maxCoordinateX, maxCoordinateY;
            var marsGrid = BuildMarsGrid(out maxCoordinateX, out maxCoordinateY);

            Console.Write("Press <Enter> to exit... ");

            var positionMoves = new List<PositionMove>();
            int martianNumber = 1;

            Console.WriteLine($"Type position X of the Martian {martianNumber} and press enter");
            string positionX = Console.ReadLine();
            Console.WriteLine($"Type position Y of the Martian {martianNumber} press enter");
            string positionY = Console.ReadLine();
            Console.WriteLine($"Type Orientation N, S, E, W of the Martian {martianNumber} press enter");
            string orientation = Console.ReadLine();
            
            var robotPosition = new Position { Orientation = (Orientation)Enum.Parse(typeof(Orientation), orientation, true) };

            Console.WriteLine($"Type set of robot moves R, L, F of the Martian {martianNumber} press enter");
            string moves = Console.ReadLine();
            
            var moveCommands = new MoveConverter().Convert(moves);
            
            var positionMove = new PositionMove { InitialPosition = robotPosition, Movements = moveCommands };
            positionMoves.Add(positionMove);
            
            var finalPositions = new MarsBoardService().GetOutput(marsGrid, positionMoves);
            Console.WriteLine($"Moves: {moves}");
            

            martianNumber++;

            Console.WriteLine($"FINAL  OUTPUT:");
            Console.WriteLine("--------------------------------------------");
            foreach (var finalPosition in finalPositions)
            {
                Console.WriteLine(finalPosition.ToString());
            }

        }

        private static MarsGrid BuildMarsGrid(out string maxCoordinateX, out string maxCoordinateY)
        {
            Console.WriteLine("Type a number with the maximum X coordinate");
            maxCoordinateX = Console.ReadLine();
            Console.WriteLine("Type a number with the maximum Y coordinate");
            maxCoordinateY = Console.ReadLine();
            return new MarsGrid(int.Parse(maxCoordinateX), int.Parse(maxCoordinateY));
        }
    }
}
