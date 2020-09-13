
using MartianRobotsGame.Models;

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
}
