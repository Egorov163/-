using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тестовое_задание_с_лифтом
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var elevator1 = new ElevatorCabin();
            var elevator2 = new ElevatorCabin();

            var flors = new List<Floor>();
            for (int i = 1; i <= 20; i++) 
            {
                flors.Add( new Floor ());
            }
            Console.WriteLine();

        }
    }
}
