using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover
{
    public class Rover
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public DirectionEnums Direction { get; private set; }
        public char[] CommandArray { get; private set; }
        public int WorldWidth;
        public int WorldHeight;
        public List<Obstacle> obstacles;

        public Rover(int xCoord, int yCoord, String direction, int width = 10, int height = 10)
        {
            XCoordinate = xCoord;
            YCoordinate = yCoord;
            Direction = ReturnDirectionEnumFromString(direction);
            CommandArray = new char[] { };
            WorldWidth = width;
            WorldHeight = height;
            obstacles =  new List<Obstacle>();
        }

        private DirectionEnums ReturnDirectionEnumFromString(string direction)
        {
            if (direction == "N")
                return DirectionEnums.North;
            else if (direction == "S")
                return DirectionEnums.South;
            else if (direction == "E")
                return DirectionEnums.East;
            else if (direction == "W")
                return DirectionEnums.West;
            else
                return DirectionEnums.InvalidDirection;
            //Throw Exception?
        }

        public void SendCommands(char[] IncomingCommandArray)
        {
            if (IncomingCommandArray != null)
                CommandArray = CommandArray.Concat(IncomingCommandArray).ToArray();
        }

        public void ExcecuteCommands()
        {
            for(int i = 0; i < CommandArray.Length; i++)
            {
                if (CommandArray[i] == 'f' || CommandArray[i] == 'b')
                    Move(CommandArray[i]);
                else if (CommandArray[i] == 'l' || CommandArray[i] == 'r')
                    Turn(CommandArray[i]);
            }
        }

        private void Turn(char v)
        {
            List<DirectionEnums> directions = new List<DirectionEnums>
                { DirectionEnums.North, DirectionEnums.East, DirectionEnums.South, DirectionEnums.West };
            int currentDirection = directions.IndexOf(Direction);

            if (v == 'r')
                Direction = directions.ElementAt((currentDirection + 1) % 4);
            else
            {
                if (currentDirection == 0)
                    Direction = DirectionEnums.West;
                else
                    Direction = directions.ElementAt(currentDirection - 1);
            }

        }

        private void Move(char moveChar)
        {
            if (moveChar == 'f')
            {
                if (Direction == DirectionEnums.North)
                    YCoordinate = CheckYBoundary(YCoordinate + 1);
                else if (Direction == DirectionEnums.South)
                    YCoordinate = CheckYBoundary(YCoordinate - 1);
                else if (Direction == DirectionEnums.East)
                    XCoordinate = CheckXBoundary(XCoordinate + 1);
                else
                    XCoordinate = CheckXBoundary(XCoordinate - 1);
            }
            else
            {
                if (Direction == DirectionEnums.North)
                    YCoordinate = CheckYBoundary(YCoordinate - 1);
                else if (Direction == DirectionEnums.South)
                    YCoordinate = CheckYBoundary(YCoordinate + 1);
                else if (Direction == DirectionEnums.East)
                    XCoordinate = CheckXBoundary(XCoordinate - 1);
                else
                    XCoordinate = CheckXBoundary(XCoordinate + 1);
            }
        }

        private int CheckYBoundary(int coordinate)
        {
            int returnCoordinate = 0;
            if (coordinate < 0)
                returnCoordinate = WorldHeight - 1;
            else if (coordinate > WorldHeight - 1)
                returnCoordinate = 0;
            else
                returnCoordinate = coordinate;

            if (!DetectYObstacle(returnCoordinate))
                return returnCoordinate;
            else
                return YCoordinate;
        }

        private bool DetectYObstacle(int coordinate)
        {
            for(int i = 0; i < obstacles.ToArray().Length; i++)
            {
                if (obstacles.ElementAt(i).XCoord == XCoordinate && obstacles.ElementAt(i).YCoord == coordinate)
                    return true;
            }
            return false;
        }

        public void AddObstacle(int x, int y)
        {
            Obstacle obstacle = new Obstacle(x, y);
            obstacles.Add(obstacle);
        }

        private bool DetectXObstacle(int coordinate)
        {
            for (int i = 0; i < obstacles.ToArray().Length; i++)
            {
                if (obstacles.ElementAt(i).XCoord == coordinate && obstacles.ElementAt(i).YCoord == YCoordinate)
                    return true;
            }
            return false;
        }

        private int CheckXBoundary(int coordinate)
        {
            int returnCoordinate = 0;
            if (coordinate < 0)
                returnCoordinate = WorldWidth - 1;
            else if (coordinate > WorldWidth - 1)
                returnCoordinate = 0;
            else
                returnCoordinate = coordinate;

            if (!DetectXObstacle(returnCoordinate))
                return returnCoordinate;
            else
                return XCoordinate;
        }
    }
}
