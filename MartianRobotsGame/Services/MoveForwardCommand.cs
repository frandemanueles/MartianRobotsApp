using MartianRobotsGame.Models;

namespace MartianRobotsGame.Services
{
    public class MoveForwardCommand : IMoveCommand
    {
        public Position Move(Position position)
        {
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
