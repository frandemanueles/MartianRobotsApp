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

        public RobotMoveService(IEnumerable<IMoveCommand> movements,
            IEnumerable<Position> scents,
            MarsGrid marsGrid)
        {
            _movements = movements;
            _scents = scents;
            MarsGrid = marsGrid;
        }

        public FinalPosition GetFinalPosition(Position currentPosition)
        {
            if (!currentPosition.IsValid(this.MarsGrid))
                throw new Exception($"Position X: {currentPosition.PositionX} Y: {currentPosition.PositionY} is invalid");
            
            var currentPositionExtended = new FinalPosition(currentPosition);
            var nextPosition = new FinalPosition(currentPosition);
            
            foreach (var movement in _movements)
            {                
                nextPosition.Position = movement.Move(currentPositionExtended.Position);
                if (IsInNewLostPosition(nextPosition, currentPositionExtended))
                {
                    nextPosition.IsLost = true;
                    nextPosition.Scent = currentPositionExtended.Position;
                    return nextPosition;
                }

                if (IsInAPreviousLostPosition(currentPositionExtended, nextPosition))
                    nextPosition.Position = currentPositionExtended.Position;
                else
                    currentPositionExtended.Position = nextPosition.Position;
            }
            nextPosition.IsLost = IsRobotOffMars(this.MarsGrid, nextPosition.Position);
            return nextPosition;
        }

        private bool IsInAPreviousLostPosition(FinalPosition currentPosition, FinalPosition nextPosition)
        {
            return IsRobotOffMars(this.MarsGrid, nextPosition.Position) && ExistsScentForPosition(currentPosition);
        }

        private bool IsInNewLostPosition(FinalPosition currentPosition, FinalPosition nextPosition)
        {
            return IsRobotOffMars(this.MarsGrid, nextPosition.Position) && !ExistsScentForPosition(currentPosition);
        }

        private bool ExistsScentForPosition(FinalPosition currentPositionExtended)
        {
            return _scents != null &&
                _scents.Count() > 0 &&
                _scents.ToList().Any(s => (s.PositionX == currentPositionExtended.Position.PositionX &&
                s.PositionY == currentPositionExtended.Position.PositionY));
        }

        private bool IsRobotOffMars(MarsGrid marsGrid, Position position)
        {
            return (position.PositionX >= marsGrid.MaxPositionX || position.PositionY >= marsGrid.MaxPositionY);
        }
    }
}
