using MartianRobotsGame.Models;

namespace MartianRobotsGame.Services
{
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
}
