using MartianRobotsGame.Models;
using MartianRobotsGame.Services;
using System.Collections.Generic;
using Xunit;
using System.Linq;

namespace MartianRobotsGame.Tests
{
    public class MarsBoardServiceTests
    {
        private readonly MarsGrid _marsGrid;
        public MarsBoardServiceTests()
        {
            _marsGrid = new MarsGrid(5, 3);
        }

        [Fact]
        public void GivenASetOfRobot_And_Movements_ShowOutput()
        {
            var movements = new List<PositionMove>();
            movements.Add(new PositionMove
            {
                InitialPosition = new Position { PositionX = 1, PositionY = 1, Orientation = Orientation.E },
                Movements = MoveCommand_Extensions.ExampleCommandsRobotOne()
            });
            movements.Add(new PositionMove
            {
                InitialPosition = new Position { PositionX = 3, PositionY = 2, Orientation = Orientation.N },
                Movements = MoveCommand_Extensions.ExampleCommandsRobotTwo()
            });
            movements.Add(new PositionMove
            {
                InitialPosition = new Position { PositionX = 0, PositionY = 3, Orientation = Orientation.W },
                Movements = MoveCommand_Extensions.ExampleCommandsRobotThree()
            });


            var sut = new MarsBoardService();
            
            var result = sut.GetOutput(_marsGrid, movements);

            Assert.True(result.ToList().Count == 3);
            Assert.Collection(result,
                                    item => Assert.Equal(1, item.Position.PositionX),
                                    item => Assert.True(item.IsLost),
                                    item => Assert.Equal(2, item.Position.PositionX));

        }
    }
}
