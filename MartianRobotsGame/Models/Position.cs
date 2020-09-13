namespace MartianRobotsGame.Models
{
    public class Position
    {
        public Orientation Orientation { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }

    public class FinalPosition
    {
        public bool IsLost { get; set; }
        public Position Position { get; set; }

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
