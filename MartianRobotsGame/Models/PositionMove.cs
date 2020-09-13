using MartianRobotsGame.Services;
using System.Collections.Generic;

namespace MartianRobotsGame.Models
{
    public class PositionMove
    {
        public IEnumerable<IMoveCommand> Movements { get; set; }
        public Position InitialPosition { get; set; }
    }
}
