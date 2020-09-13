using MartianRobotsGame.Models;
using System.Collections.Generic;

namespace MartianRobotsGame.Services
{
    public class MarsBoardService
    {
        public MarsGrid MarsGrid { get; set; }
        public IEnumerable<PositionMove> PositionMoves { get; set; }
    
        //5 3
        //1 1 E
        //RFRFRFRF
        //3 2 N
        //FRRFLLFFRRFLL
        //0 3 W
        //LLFFFLFLFL

        private readonly RobotMoveService _robotMoveService;

        public MarsBoardService(RobotMoveService robotMoveService)
        {
            _robotMoveService = robotMoveService;
        }

        public IEnumerable<FinalPosition> GetOutput(MarsGrid marsGrid, IEnumerable<PositionMove> positionMoves)
        {
            var finalPositions = new List<FinalPosition>();
            
            foreach (var positionMove in positionMoves)
            {
                var robotMoveService = new RobotMoveService(positionMove.Movements);
                var position = robotMoveService.GetFinalPosition(positionMove.InitialPosition);
                var finalPosition = new FinalPosition
                {
                    LastPosition = position
                };
                finalPosition.IsLost = finalPosition.IsRobotLoss(marsGrid, position);
                finalPositions.Add(finalPosition);
            }
            return finalPositions;
        }
    }
}
