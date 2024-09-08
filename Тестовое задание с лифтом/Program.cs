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
            var systemElevator = new SystemElevator();


            var Floors = new List<Floor>();

            for (int i = 1; i <= 20; i++)
            {
                Floors.Add(new Floor(i));
            }

            foreach (var floor in Floors)
            {
                floor.SystemElevator = systemElevator;
                floor.TheCurrentFloorOfTheCabinIs1 = floor.SystemElevator.ElevatorCabin1.CurrentFloor;
                floor.TheCurrentFloorOfTheCabinIs2 = floor.SystemElevator.ElevatorCabin2.CurrentFloor;
                floor.CurrentStatusOfCabin1 = !(floor.SystemElevator.ElevatorCabin1.Busy());
                floor.CurrentStatusOfCabin2 = !(floor.SystemElevator.ElevatorCabin2.Busy());
            }

            var floor1 = Floors.First(f=>f.ThisFloor==1);
            floor1.PressTheElevatorCallButton();
            Console.WriteLine("Люди зашли в лифт");
            systemElevator.ElevatorCabin1.PressTheFloorButton(14);

            
            Console.WriteLine();


        }
    }
}
