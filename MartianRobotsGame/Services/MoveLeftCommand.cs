using MartianRobotsGame.Models;

namespace MartianRobotsGame.Services
{
    public class MoveLeftCommand : IMoveCommand
    {
        public Position Move(Position initialPosition)
        {
            var position = new Position { Orientation = initialPosition.Orientation, PositionX = initialPosition.PositionX, PositionY = initialPosition.PositionY };
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
