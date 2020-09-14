using MartianRobotsGame.Models;
using System;
using System.Collections.Generic;

namespace MartianRobotsGame.Services
{
    public class MarsBoardService
    {
        public MarsBoardService()
        {
        }

        public IEnumerable<FinalPosition> GetOutput(MarsGrid marsGrid, IEnumerable<PositionMove> positionMoves)
        {
            var finalPositions = new List<FinalPosition>();
            var scents = new List<Position>();
            try
            {
                foreach (var positionMove in positionMoves)
                {
                    if (!positionMove.InitialPosition.IsValid(marsGrid))
                        throw new Exception($"Position X: {positionMove.InitialPosition.PositionX} Y: {positionMove.InitialPosition.PositionY} is invalid");

                    var robotMoveService = new RobotMoveService(positionMove.Movements, scents, marsGrid);                
                    var finalPosition = robotMoveService.GetFinalPosition(positionMove.InitialPosition);
                    if (finalPosition.IsLost)
                        scents.Add(finalPosition.Scent);
                    finalPositions.Add(finalPosition);
                }
                return finalPositions;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
