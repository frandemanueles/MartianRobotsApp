using MartianRobotsGame.Models;

namespace MartianRobotsGame.Services
{
    public interface IMoveCommand
    {
        public Position Move(Position position);
    }
}
