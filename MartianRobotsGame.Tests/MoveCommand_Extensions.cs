using MartianRobotsGame.Services;
using System.Collections.Generic;

namespace MartianRobotsGame.Tests
{
    public static class MoveCommand_Extensions
    {
        public static List<IMoveCommand> ForwardCommands()
        {
            return new List<IMoveCommand> {
                new MoveForwardCommand(),
                new MoveForwardCommand(),
                new MoveForwardCommand(),
                new MoveRightCommand(),
                new MoveRightCommand()
            };
        }

        public static List<IMoveCommand> ExampleCommandsRobotOne()
        {
            return new List<IMoveCommand> {
            new MoveRightCommand(),
            new MoveForwardCommand(),
            new MoveRightCommand(),
            new MoveForwardCommand(),
            new MoveRightCommand(),
            new MoveForwardCommand(),
            new MoveRightCommand(),
            new MoveForwardCommand(),
            };
        }
        public static List<IMoveCommand> ExampleCommandsRobotTwo()
        {
            return new List<IMoveCommand> {
            new MoveForwardCommand(),
            new MoveRightCommand(),
            new MoveRightCommand(),
            new MoveForwardCommand(),
            new MoveLeftCommand(),
            new MoveLeftCommand(),
            new MoveForwardCommand(),
            new MoveForwardCommand(),
            new MoveRightCommand(),
            new MoveRightCommand(),
            new MoveForwardCommand(),
            new MoveLeftCommand(),
            new MoveLeftCommand(),
            };
        }

        public static List<IMoveCommand> ExampleCommandsRobotThree()
        {
            return new List<IMoveCommand> {
            new MoveLeftCommand(),
            new MoveLeftCommand(),
            new MoveForwardCommand(),
            new MoveForwardCommand(),
            new MoveForwardCommand(),
            new MoveLeftCommand(),
            new MoveForwardCommand(),
            new MoveLeftCommand(),
            new MoveForwardCommand(),
            new MoveLeftCommand(),
            };
        }
    }
}
