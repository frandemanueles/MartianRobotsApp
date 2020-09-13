namespace MartianRobotsGame.Models
{
    public class MarsGrid
    {
        public const int MaxCoordinate = 50;

        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public MarsGrid(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}
