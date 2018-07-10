using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GpsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Position2D startPos = new Position2D(0, 2);
            Position2D targetPos = new Position2D(3, 4);

            Map map = new Map(new Boolean[,] {
                {true,true,true,true,true,true,false,false},
                {false,false,true,false,true,true,true,false},
                {false,false,true,true,true,true,false,false},
                {false,false,false,true,true,false,false,false},
                {false,false,false,true,true,true,true,true}
            });
            Gps gps = new Gps(map, startPos, targetPos);
            Console.WriteLine("The sortest way is: " + gps.getShortestWay());


        }

        
    }
}
