using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тестовое_задание_с_лифтом
{
    public class Lift
    {
        private int currentFloor;
        private int targetFloor;
        private bool isMoving;
        private bool isDoorsOpen;

        public Lift()
        {
            currentFloor = 1;
            targetFloor = 1;
            isMoving = false;
            isDoorsOpen = true;
        }

        public int CurrentFloor
        {
            get { return currentFloor; }
        }

        public void PressFloorButton(int floor)
        {
            targetFloor = floor;
            isMoving = true;
            isDoorsOpen = false;
            Console.WriteLine($"Lift button for floor {floor} is pressed.");
        }

        public void OpenDoors()
        {
            isDoorsOpen = true;
            Console.WriteLine("Lift doors are opening.");
        }

        public void CloseDoors()
        {
            isDoorsOpen = false;
            Console.WriteLine("Lift doors are closing.");
        }

        public void Move()
        {
            if (currentFloor < targetFloor)
            {
                Console.WriteLine($"Lift is moving up to floor {targetFloor}.");
                while (currentFloor < targetFloor)
                {
                    currentFloor++;
                    Console.WriteLine($"Lift is on floor {currentFloor}.");
                    //Thread.Sleep(1000);
                }
            }
            else if (currentFloor > targetFloor)
            {
                Console.WriteLine($"Lift is moving down to floor {targetFloor}.");
                while (currentFloor > targetFloor)
                {
                    currentFloor--;
                    Console.WriteLine($"Lift is on floor {currentFloor}.");
                    //Thread.Sleep(1000);
                }
            }

            isMoving = false;
            OpenDoors();
        }
    }
}
