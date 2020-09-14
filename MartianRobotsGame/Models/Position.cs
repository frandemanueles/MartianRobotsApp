﻿using System;

namespace MartianRobotsGame.Models
{
    public class Position
    {
        public Orientation Orientation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public bool IsValid(MarsGrid marsGrid)
        {
            return (PositionX >= 0 &&
                PositionX < marsGrid.MaxPositionX && 
                PositionY >= 0 && 
                PositionY < marsGrid.MaxPositionY &&
                Enum.IsDefined(typeof(Orientation), this.Orientation));
        }
    }

    public class FinalPosition
    {
        public bool IsLost { get; set; }
        public Position Position { get; set; }
        public Position Scent { get; set; }

        public FinalPosition()
        {

        }
        public FinalPosition(Position position)
        {
            this.Position = position;
            this.IsLost = false;
        }
        
        public override string ToString()
        {
            return $"{Position.Orientation} {Position.PositionX} {Position.PositionY}  {(this.IsLost ? "LOST" : string.Empty)}";
        }
    }
}
