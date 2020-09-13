using MartianRobotsGame.Models;

namespace MartianRobotsGame.Services
{
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

}
