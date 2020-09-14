
using MartianRobotsGame.Models;

namespace MartianRobotsGame.Services
{
    public class MoveRightCommand : IMoveCommand
    {
        public Position Move(Position initialPosition)
        {
            var position = new Position { Orientation = initialPosition.Orientation, PositionX = initialPosition.PositionX, PositionY = initialPosition.PositionY };
            switch (position.Orientation)
            {
                case Orientation.N:
                    position.Orientation = Orientation.E;
                    break;
                case Orientation.E:
                    position.Orientation = Orientation.S;
                    break;
                case Orientation.S:
                    position.Orientation = Orientation.W;
                    break;
                case Orientation.W:
                    position.Orientation = Orientation.N;
                    break;
            }
            return position;
        }
    }
}
