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
            TypeRobotMoves();
        }

        private static void TypeRobotMoves()
        {
            string maxCoordinateX, maxCoordinateY;
            var marsGrid = BuildMarsGrid(out maxCoordinateX, out maxCoordinateY);

            var positionMoves = new List<PositionMove>();
            int robotNumber = 1;
            string defaultOrientation = "N";

            while (true)
            {
                var robotPosition = new Position();
                do
                {
                    Console.WriteLine($"Type position X of the Robot {robotNumber} and press enter");
                    string positionX = Console.ReadLine();
                    Console.WriteLine($"Type position Y of the Robot {robotNumber} and press enter");
                    string positionY = Console.ReadLine();
                    Console.WriteLine($"Type Orientation N, S, E, W of the Robot {robotNumber} press enter");
                    string orientation = Console.ReadLine();

                    robotPosition.PositionX = int.Parse(positionX);
                    robotPosition.PositionY = int.Parse(positionY);

                    if (!Enum.IsDefined(typeof(Orientation), orientation))
                        orientation = defaultOrientation;
                    robotPosition.Orientation = (Orientation)Enum.Parse(typeof(Orientation), orientation, true);

                } while (!robotPosition.IsValid(marsGrid));

                Console.WriteLine($"Type set of robot moves R L or F (for example FFRLFFL) of the Robot {robotNumber} and press enter");
                string moves = Console.ReadLine();

                var moveCommands = new MoveConverter().Convert(moves);
                positionMoves.Add(new PositionMove { InitialPosition = robotPosition, Movements = moveCommands });

                Console.WriteLine($"Moves: {moves}");

                robotNumber++;

                Console.WriteLine($"More robots?? Press any key. If you want to finish press ESC");
                
                ConsoleKeyInfo info = Console.ReadKey();
                if (info.Key == ConsoleKey.Escape)
                    break;
                Console.WriteLine("--------------------------------------------");
            }

            var finalPositions = new MarsBoardService().GetOutput(marsGrid, positionMoves);

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
