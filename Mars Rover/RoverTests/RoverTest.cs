using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace RoverTests
{
    [TestClass]
    public class RoverTest
    {
        [TestMethod]
        public void RoverInitilizeAtOneOneFacingEast()
        {
            var rover = new Rover(1, 1, "E");

            Assert.AreEqual(1, rover.XCoordinate);
            Assert.AreEqual(1, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.East, rover.Direction);
        }

        [TestMethod]
        public void RoverInitilizeAtTenEightFacingSouth()
        {
            var rover = new Rover(10, 8, "S");

            Assert.AreEqual(10, rover.XCoordinate);
            Assert.AreEqual(8, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.South, rover.Direction);
        }

        [TestMethod]
        public void SendTwoCommands()
        {
            var rover = new Rover(10, 8, "S");
            var inputArray = new char[] { 'f', 'b' };
            rover.SendCommands(inputArray);

            Assert.AreEqual('f', rover.CommandArray[0]);
            Assert.AreEqual('b', rover.CommandArray[1]);
        }

        [TestMethod]
        public void SendTwoCommandsAddTwoMore()
        {
            var rover = new Rover(10, 8, "S");
            var inputArrayOne = new char[] { 'f', 'b' };
            var inputArrayTwo = new char[] { 'l', 'r' };
            rover.SendCommands(inputArrayOne);
            rover.SendCommands(inputArrayTwo);

            Assert.AreEqual('f', rover.CommandArray[0]);
            Assert.AreEqual('b', rover.CommandArray[1]);
            Assert.AreEqual('l', rover.CommandArray[2]);
            Assert.AreEqual('r', rover.CommandArray[3]);
        }

        [TestMethod]
        public void PlaceRoverAtZeroZeroNorthAndMoveForeward()
        {
            var rover = new Rover(0, 0, "N");
            var inputArrayOne = new char[] { 'f' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(0, rover.XCoordinate);
            Assert.AreEqual(1, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.North, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtOneOneNorthAndMoveBackwards()
        {
            var rover = new Rover(1, 1, "N");
            var inputArrayOne = new char[] { 'b' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(1, rover.XCoordinate);
            Assert.AreEqual(0, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.North, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtOneOneSouthAndMoveBackwards()
        {
            var rover = new Rover(1, 1, "S");
            var inputArrayOne = new char[] { 'b' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(1, rover.XCoordinate);
            Assert.AreEqual(2, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.South, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtZeroZeroEastAndMoveForeward()
        {
            var rover = new Rover(0, 0, "E");
            var inputArrayOne = new char[] { 'f' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(1, rover.XCoordinate);
            Assert.AreEqual(0, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.East, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtOneOneWestAndMoveForeward()
        {
            var rover = new Rover(1, 1, "W");
            var inputArrayOne = new char[] { 'f' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(0, rover.XCoordinate);
            Assert.AreEqual(1, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.West, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtOneOneWestAndMoveBackwards()
        {
            var rover = new Rover(1, 1, "W");
            var inputArrayOne = new char[] { 'b' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(2, rover.XCoordinate);
            Assert.AreEqual(1, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.West, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtZeroZeroNorthAndTurnRightToFaceEast()
        {
            var rover = new Rover(0, 0, "N");
            var inputArrayOne = new char[] { 'r' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(DirectionEnums.East, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtZeroZeroEastAndTurnRightToFaceSouth()
        {
            var rover = new Rover(0, 0, "E");
            var inputArrayOne = new char[] { 'r' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(DirectionEnums.South, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtZeroZeroSouthAndTurnRightToFaceWest()
        {
            var rover = new Rover(0, 0, "S");
            var inputArrayOne = new char[] { 'r' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(DirectionEnums.West, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtZeroZeroWestAndTurnRightToFaceNorth()
        {
            var rover = new Rover(0, 0, "W");
            var inputArrayOne = new char[] { 'r' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(DirectionEnums.North, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtZeroZeroNorthAndTurnLeftToFaceWest()
        {
            var rover = new Rover(0, 0, "N");
            var inputArrayOne = new char[] { 'l' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(DirectionEnums.West, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtZeroZeroWestAndTurnLeftToFaceSouth()
        {
            var rover = new Rover(0, 0, "W");
            var inputArrayOne = new char[] { 'l' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(DirectionEnums.South, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtZeroZeroSouthAndTurnLeftToFaceEast()
        {
            var rover = new Rover(0, 0, "S");
            var inputArrayOne = new char[] { 'l' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(DirectionEnums.East, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtZeroZeroEastAndTurnLeftToFaceNorth()
        {
            var rover = new Rover(0, 0, "E");
            var inputArrayOne = new char[] { 'l' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(DirectionEnums.North, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtNineNineGoPastYBoundaryEndAtNineZero()
        {
            var rover = new Rover(9, 9, "N");
            var inputArrayOne = new char[] { 'f' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(9, rover.XCoordinate);
            Assert.AreEqual(0, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.North, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtNineNineGoPastXBoundaryEndAtZeroNine()
        {
            var rover = new Rover(9, 9, "E");
            var inputArrayOne = new char[] { 'f' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(0, rover.XCoordinate);
            Assert.AreEqual(9, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.East, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtZeroZeroGoPastZeroXBoundaryEndAtNineZero()
        {
            var rover = new Rover(0, 0, "W");
            var inputArrayOne = new char[] { 'f' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(9, rover.XCoordinate);
            Assert.AreEqual(0, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.West, rover.Direction);
        }

        [TestMethod]
        public void PlaceRoverAtZeroZeroGoPastZeroYBoundaryEndAtZeroNine()
        {
            var rover = new Rover(0, 0, "S");
            var inputArrayOne = new char[] { 'f' };
            rover.SendCommands(inputArrayOne);

            rover.ExcecuteCommands();

            Assert.AreEqual(0, rover.XCoordinate);
            Assert.AreEqual(9, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.South, rover.Direction);
        }

        [TestMethod]
        public void RoverZeroZeroNorthForewardIntoObstacleStayZeroZero()
        {
            var rover = new Rover(0, 0, "N");
            var inputArrayOne = new char[] { 'f' };
            rover.SendCommands(inputArrayOne);
            rover.AddObstacle(0, 1);

            rover.ExcecuteCommands();

            Assert.AreEqual(0, rover.XCoordinate);
            Assert.AreEqual(0, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.North, rover.Direction);
        }

        [TestMethod]
        public void RoverZeroZeroWestForewardIntoObstacleStayZeroZero()
        {
            var rover = new Rover(0, 0, "W");
            var inputArrayOne = new char[] { 'f' };
            rover.SendCommands(inputArrayOne);
            rover.AddObstacle(9, 0);

            rover.ExcecuteCommands();

            Assert.AreEqual(0, rover.XCoordinate);
            Assert.AreEqual(0, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.West, rover.Direction);
        }

        [TestMethod]
        public void RoverZeroZeroSouthForewardIntoObstacleStayZeroZero()
        {
            var rover = new Rover(0, 0, "S");
            var inputArrayOne = new char[] { 'f' };
            rover.SendCommands(inputArrayOne);
            rover.AddObstacle(0, 9);

            rover.ExcecuteCommands();

            Assert.AreEqual(0, rover.XCoordinate);
            Assert.AreEqual(0, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.South, rover.Direction);
        }

        [TestMethod]
        public void RoverNineNineNorthForewardIntoObstacleNineNine()
        {
            var rover = new Rover(9, 9, "N");
            var inputArrayOne = new char[] { 'f' };
            rover.SendCommands(inputArrayOne);
            rover.AddObstacle(9, 0);

            rover.ExcecuteCommands();

            Assert.AreEqual(9, rover.XCoordinate);
            Assert.AreEqual(9, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.North, rover.Direction);
        }

        [TestMethod]
        public void RoverNineNineEastForewardIntoObstacleStayNineNine()
        {
            var rover = new Rover(9, 9, "E");
            var inputArrayOne = new char[] { 'f' };
            rover.SendCommands(inputArrayOne);
            rover.AddObstacle(0, 9);

            rover.ExcecuteCommands();

            Assert.AreEqual(9, rover.XCoordinate);
            Assert.AreEqual(9, rover.YCoordinate);
            Assert.AreEqual(DirectionEnums.East, rover.Direction);
        }
    }
}
