using MartianRobotsGame.Models;
using System.Collections.Generic;

namespace MartianRobotsGame.Services
{
    public class RobotMoveService
    {
        private readonly IEnumerable<IMoveCommand> _movements;
        public RobotMoveService( IEnumerable<IMoveCommand> movements)
        {
            _movements = movements;            
        }

        public Position GetFinalPosition(Position initialPosition)
        {
            var position = new Position { Orientation = initialPosition.Orientation, PositionX = initialPosition.PositionX, PositionY = initialPosition.PositionY };
            foreach (var movement in _movements)
            {
                position = movement.Move(initialPosition);
            }
            return position;
        }
    }
}
