namespace MartianRobotsGame.Models
{
    public class MarsGrid
    {
        public const int MaxCoordinate = 50;

        public int MaxPositionX { get; set; }
        public int MaxPositionY { get; set; }

        public MarsGrid(int positionX, int positionY)
        {
            MaxPositionX = positionX;
            MaxPositionY = positionY;
        }

        public bool IsValid()
        {
            return (MaxPositionX <= MaxCoordinate && MaxPositionY <= MaxCoordinate);
        }
    }
}
