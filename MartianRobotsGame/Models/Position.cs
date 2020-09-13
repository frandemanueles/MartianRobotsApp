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
        public Position LastPosition { get; set; }

        public bool IsRobotLoss(MarsGrid marsGrid, Position position)
        {
            return position.PositionX >= marsGrid.PositionX || position.PositionX >= marsGrid.PositionY;
        }

        public override string ToString()
        {
            return $"{LastPosition.Orientation} {LastPosition.PositionX} {LastPosition.PositionY}  {(this.IsLost ? "LOSS" : string.Empty)}";
        }
    }
}
