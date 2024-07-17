using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrajwalStack
{
    public static class Hanoi
    {
        public static void Tower(int diskCount, string tower1, string tower2, string tower3)
        {
            if (diskCount == 1)
            {
                Console.WriteLine($"{tower1}->{tower3}");
                return;
            }
            Tower(diskCount - 1, tower1, tower3, tower2);
            Console.WriteLine($"{tower1}->{tower3}");
            Tower(diskCount - 1, tower2, tower1, tower3);
        }
    }
}
