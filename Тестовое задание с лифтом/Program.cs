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

            Passenger(Floors, systemElevator, 1, 14);
            Passenger(Floors, systemElevator, 15, 1);


            Console.WriteLine();


        }
        public static void Passenger(List<Floor> Floors,
            SystemElevator systemElevator,
            int WhichFloorIsTheSignalFrom,
            int WhereWillTheElevatorGo)
        {
            if ((WhichFloorIsTheSignalFrom < 1 || WhichFloorIsTheSignalFrom > 20)
                || (WhereWillTheElevatorGo < 1 || WhereWillTheElevatorGo > 20))
            {
                Console.WriteLine("Вы что то ввели не то");
            }
            else 
            {
                var floor1 = Floors.First(f => f.ThisFloor == WhichFloorIsTheSignalFrom);
                floor1.PressTheElevatorCallButton();
                Console.WriteLine("Люди зашли в лифт");
                systemElevator.ElevatorCabin1.PressTheFloorButton(WhereWillTheElevatorGo);
                Console.WriteLine("Люди вышли из лифта");
                var floor15 = Floors.First(f => f.ThisFloor == WhichFloorIsTheSignalFrom);
                floor15.PressTheElevatorCallButton();
                systemElevator.ElevatorCabin1.PressTheFloorButton(WhereWillTheElevatorGo);
            }            
        }
    }
}
