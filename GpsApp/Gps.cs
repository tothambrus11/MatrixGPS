using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsApp
{
    class Gps
    {
        private Map map;
        private Position2D startPosition;
        private Position2D targetPosition;

        public Gps(Map map, Position2D startPosition, Position2D targetPosition)
        {
            this.map = map;
            this.startPosition = startPosition;
            this.targetPosition = targetPosition;
        }

        private int shortestWay = 999999;

        public int getShortestWay()
        {

            gps(startPosition, 0, new List<Position2D> { });
            return shortestWay;
        }
        private void gps(Position2D currentPosition, int currentLengthOfTheWay, List<Position2D> way)
        {
            if (currentPosition.Equals(targetPosition))
            {
                if(shortestWay > currentLengthOfTheWay)
                {
                    shortestWay = currentLengthOfTheWay;
                }
                return;
            }

            printMessage(currentLengthOfTheWay, ("I am at the position " + currentPosition.x + "; " + currentPosition.y + " Where can I move to? "));

            // If we can move right
            if (map.getField(currentPosition.x + 1, currentPosition.y))
            {
                currentLengthOfTheWay++;
                printMessage(currentLengthOfTheWay, "I can move right.");
                way.Add(new Position2D(currentPosition.x + 1, currentPosition.y));
                gps(new Position2D(currentPosition.x + 1, currentPosition.y), currentLengthOfTheWay, way);
            }
            // If we can move left
            if(map.getField(currentPosition.x - 1, currentPosition.y))
            {
                currentLengthOfTheWay++;
                printMessage(currentLengthOfTheWay, "I can move left.");
                gps(new Position2D(currentPosition.x - 1, currentPosition.y), currentLengthOfTheWay);
            }
            // If we can move down
            if (map.getField(currentPosition.x, currentPosition.y - 1))
            {
                currentLengthOfTheWay++;
                printMessage(currentLengthOfTheWay, "I can move down.");
                gps(new Position2D(currentPosition.x, currentPosition.y - 1), currentLengthOfTheWay);
            }
            // If we can move up
            if (map.getField(currentPosition.x, currentPosition.y + 1))
            {
                currentLengthOfTheWay++;
                printMessage(currentLengthOfTheWay, "I can move up.");
                gps(new Position2D(currentPosition.x, currentPosition.y + 1), currentLengthOfTheWay);
            }
            
        }

        private void printMessage(int deep, string message)
        {
            Console.WriteLine();
            for (int i = 0; i != deep; i++)
            {
                Console.Write("\t");
            }
            Console.Write(message);
        }
        private Boolean Contains(Position2D tű, Position2D[] szénakazal)
        {
            foreach (Position2D currentPos in szénakazal)
            {
                if (currentPos.Equals(tű))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
