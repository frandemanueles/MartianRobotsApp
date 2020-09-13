using MartianRobotsGame.Models;
using MartianRobotsGame.Services;
using System.Collections.Generic;
using Xunit;

namespace MartianRobotsGame.Tests
{
    public class RobotMoveServiceTests
    {
        //public static IEnumerable<object[]> BBChargesCalculations
        //{
        //    get
        //    {
        //        yield return new object[] { BroadbandChargeExtensions.Build(), 566.28M, 696.5244M };
        //        yield return new object[] { BroadbandChargeExtensions.WithDifferentVAT(BroadbandChargeExtensions.Build()), 946.92M, 1662.4764M };
        //    }
        //}

        //[Theory]
        //[MemberData("BBChargesCalculations")]

        private readonly RobotMoveService _sut;
        public RobotMoveServiceTests()
        {
            //FRRFLLFFRRFLL
            _sut = new RobotMoveService(new List<IMoveCommand> { 
            new MoveForwardCommand(),
            new MoveRightCommand(),
            new MoveRightCommand(),
            new MoveForwardCommand(),
            new MoveLeftCommand(),
            new MoveLeftCommand(),
            new MoveForwardCommand(),
            new MoveForwardCommand(),
            new MoveRightCommand(),
            new MoveRightCommand(),
            new MoveForwardCommand(),
            new MoveLeftCommand(),
            new MoveLeftCommand(),
            });
            _sut.MarsGrid = new MarsGrid(3, 5);
        }

        [Fact]
        public void GivenACoordinate_WhenMovingRight_ShowNewOrientation()
        {
            var expectedPosition = new Position { Orientation = Orientation.N, PositionX = 3, PositionY = 3};
            var position = new Position { Orientation = Orientation.N, PositionX = 3, PositionY = 2 };

            var finalPosition = _sut.GetFinalPosition(position);

            Assert.Equal(expectedPosition.Orientation, finalPosition.Position.Orientation);
        }

        //[Theory]
        //[MemberData("BBChargesCalculations")]
        //public void ShouldCalculateBroadbandCharges(IEnumerable<BroadbandCharge> charges,
        //    decimal totalPaid,
        //    decimal totalPaidIncludingVAT)
        //{
        //    var chargesExtended = _sut.GetExtendedCharges(charges);
        //    Assert.Equal(totals.TotalPaid, totalPaid);
        //}
    }
}
