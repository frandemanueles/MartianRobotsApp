using MartianRobotsGame.Models;

namespace MartianRobotsGame.    
{
    public interface IMoveCommand
    {
        public Position Move(Position position);
    }
}
