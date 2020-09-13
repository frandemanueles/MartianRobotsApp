using System.Collections.Generic;

namespace MartianRobotsGame.Services
{
    public interface IMoveConverter
    {
        IEnumerable<IMoveCommand> Convert(string positionMovesString);
    }
    public class MoveConverter : IMoveConverter
    {
        public IEnumerable<IMoveCommand> Convert(string positionMovesString)
        {
            var moveCommands = new List<IMoveCommand>();
            foreach (char c in positionMovesString)
            {
                switch (c)
                {
                    case 'L':
                        moveCommands.Add(new MoveLeftCommand());
                        break;
                    case 'R':
                        moveCommands.Add(new MoveRightCommand());
                        break;
                    case 'F':
                        moveCommands.Add(new MoveForwardCommand());
                        break;
                    default:
                        break;
                }
            }
            return moveCommands;
        }
    }
}
