using MartianRobotsGame.Models;

namespace MartianRobotsGame.Services
{
    public class MoveLeftCommand : IMoveCommand
    {
        public Position Move(Position position)
        {
            switch (position.Orientation)
            {
                case Orientation.N:
                    position.Orientation = Orientation.W;
                    break;
                case Orientation.E:
                    position.Orientation = Orientation.N;
                    break;
                case Orientation.S:
                    position.Orientation = Orientation.E;
                    break;
                case Orientation.W:
                    position.Orientation = Orientation.S;
                    break;
            }
            return position;
        }
    }

}
