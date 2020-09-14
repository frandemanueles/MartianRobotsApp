using MartianRobotsGame.Models;

namespace MartianRobotsGame.Services
{
    public class MoveForwardCommand : IMoveCommand
    {
        public Position Move(Position initialPosition)
        {
            var position = new Position { Orientation = initialPosition .Orientation, PositionX = initialPosition.PositionX, PositionY = initialPosition.PositionY};
            switch (position.Orientation)
            {
                case Orientation.N:
                    position.PositionY += 1;
                    break;
                case Orientation.E:
                    position.PositionX += 1;
                    break;
                case Orientation.S:
                    position.PositionY -= 1;
                    break;
                case Orientation.W:
                    position.PositionY += 1;
                    break;
            }
            return position;
        }
    }
}
