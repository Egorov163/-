using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тестовое_задание_с_лифтом
{
    public class Floor
    {
        public Floor(int floor) 
        { 
            ThisFloor = floor;
        }
        public SystemElevator SystemElevator { get; set; } = new SystemElevator();
        public int ThisFloor { get; set; }
        public int TheCurrentFloorOfTheCabinIs1 { get; set; } 
        public bool CurrentStatusOfCabin1 { get; set; }
        public int TheCurrentFloorOfTheCabinIs2 { get; set; }
        public bool CurrentStatusOfCabin2 { get; set; }
        public int StatusOfTheElevatorCallButton { get; set; }
        public void PressTheElevatorCallButton() 
        {
            SystemElevator.CallingTheElevator(ThisFloor);
        }
    }
}
