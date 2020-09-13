using MartianRobotsGame.Models;
using MartianRobotsGame.Services;
using System.Collections.Generic;

namespace MartianRobotsGame.Services
{
    public class MoveRightCommand : IMoveCommand
    {
        public Position Move(Position position)
        {
            switch (position.Orientation)
            {
                case Orientation.North:
                    position.Orientation = Orientation.East;
                    break;
                case Orientation.East:
                    position.Orientation = Orientation.South;
                    break;
                case Orientation.South:
                    position.Orientation = Orientation.West;
                    break;
                case Orientation.West:
                    position.Orientation = Orientation.North;
                    break;
            }
            return position;
        }
    }

    public class MoveLeftCommand : IMoveCommand
    {
        public Position Move(Position position)
        {
            switch (position.Orientation)
            {
                case Orientation.North:
                    position.Orientation = Orientation.West;
                    break;
                case Orientation.East:
                    position.Orientation = Orientation.North;
                    break;
                case Orientation.South:
                    position.Orientation = Orientation.East;
                    break;
                case Orientation.West:
                    position.Orientation = Orientation.South;
                    break;
            }
            return position;
        }
    }

    public class MoveForwardCommand : IMoveCommand
    {
        public Position Move(Position position)
        {
            switch (position.Orientation)
            {
                case Orientation.North:
                    position.PositionY += 1;
                    break;
                case Orientation.East:
                    position.PositionX += 1;
                    break;
                case Orientation.South:
                    position.PositionY -= 1;
                    break;
                case Orientation.West:
                    position.PositionY += 1;
                    break;
            }
            return position;
        }
    }


    public class RobotMoveService
    {
        private readonly IEnumerable<IMoveCommand> _movements;
        private readonly Position _initialPosition;
        public RobotMoveService( IEnumerable<IMoveCommand> movements)
        {
            _movements = movements;            
        }

        public Position GetFinalPosition(Position initialPosition)
        {
            var position = new Position { Orientation = initialPosition.Orientation, PositionX = initialPosition.PositionX, PositionY = initialPosition.PositionY };
            foreach (var movement in _movements)
            {
                position = movement.Move(initialPosition);
            }
            return position;
        }
    }
}
