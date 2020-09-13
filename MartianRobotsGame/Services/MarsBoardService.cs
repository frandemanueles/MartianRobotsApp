using MartianRobotsGame.Models;
using System.Collections.Generic;

namespace MartianRobotsGame.Services
{
    public class MarsBoardService
    {
        private readonly IMoveConverter _moveConverter;
        public MarsGrid MarsGrid { get; set; }
        public IEnumerable<PositionMove> PositionMoves { get; set; }

        private readonly RobotMoveService _robotMoveService;
        public IMoveConverter MoveConverter;
        public MarsBoardService(RobotMoveService robotMoveService, IMoveConverter moveConverter)
        {
            _robotMoveService = robotMoveService;
            _moveConverter = moveConverter;
        }

        public MarsBoardService()
        {
        }

        public IEnumerable<FinalPosition> GetOutput(MarsGrid marsGrid, IEnumerable<PositionMove> positionMoves)
        {
            var finalPositions = new List<FinalPosition>();
            
            foreach (var positionMove in positionMoves)
            {
                var robotMoveService = new RobotMoveService(positionMove.Movements);
                var finalPosition = robotMoveService.GetFinalPosition(positionMove.InitialPosition);
                finalPositions.Add(finalPosition);
            }
            return finalPositions;
        }
    }
}
