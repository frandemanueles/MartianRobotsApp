using MartianRobotsGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobotsGame.Services
{
    public class RobotMoveService
    {
        private readonly IEnumerable<IMoveCommand> _movements;
        private readonly IEnumerable<Position> _scents;
        public MarsGrid MarsGrid { get; set; }

        public RobotMoveService(IEnumerable<IMoveCommand> movements)
        {
            _movements = movements;            
        }

        public RobotMoveService(IEnumerable<IMoveCommand> movements, IEnumerable<Position> scents)
        {
            _movements = movements;
            _scents = scents;
        }

        public FinalPosition GetFinalPosition(Position currentPosition)
        {
            var currentPositionExtended = new FinalPosition(currentPosition);
            var nextPosition = new FinalPosition(currentPosition);
            
            foreach (var movement in _movements)
            {
                if (!IsInAPreviousLostPosition(currentPositionExtended))
                {
                    nextPosition.Position = movement.Move(nextPosition.Position);
                    currentPositionExtended = nextPosition;
                }
                else
                    nextPosition = currentPositionExtended;
            }
            nextPosition.IsLost = IsRobotOffMars(this.MarsGrid, nextPosition.Position);
            return nextPosition;
        }

        private bool IsInAPreviousLostPosition(FinalPosition currentPositionExtended)
        {
            return IsRobotOffMars(this.MarsGrid, currentPositionExtended.Position) &&
                _scents != null &&
                _scents.Count() > 0 && 
                _scents.ToList().Any(s => s == currentPositionExtended.Position);
        }

        private bool IsRobotLost(MarsGrid marsGrid)
        {
            throw new NotImplementedException();
        }

        private bool IsRobotOffMars(MarsGrid marsGrid, Position position)
        {
            return (position.PositionX >= marsGrid.PositionX || position.PositionX >= marsGrid.PositionY);
        }
    }
}
