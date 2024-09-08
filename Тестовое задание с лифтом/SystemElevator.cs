using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тестовое_задание_с_лифтом
{
    public class SystemElevator
    {        
        public ElevatorCabin ElevatorCabin1  = new ElevatorCabin();
        public ElevatorCabin ElevatorCabin2  = new ElevatorCabin();
        public void CallingTheElevator(int floor)
        {
            if (!ElevatorCabin1.Busy())
            {
                ElevatorCabin1.ArriveAtTheDesiredFloor(floor);
            } 
            else if (!ElevatorCabin2.Busy())
            {
                ElevatorCabin1.ArriveAtTheDesiredFloor(floor);
            }
        }

        
    }
}
