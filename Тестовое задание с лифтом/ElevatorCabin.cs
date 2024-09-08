using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тестовое_задание_с_лифтом
{
    public class ElevatorCabin
    {
        public int CurrentFloor { get; set; } = 1;
        public bool GoingUp { get; set; } = false;
        public bool GoingDown { get; set; } = false;
        public bool OpensTheDoors { get; set; } = false;
        public bool ClosesTheDoors { get; set; } = false;
        public bool ItStandsWithTheDoorsOpen { get; set; } = false;
        public bool Free { get; set; }

        public bool Busy()
        {
            if (GoingUp || GoingDown || OpensTheDoors || ClosesTheDoors || ItStandsWithTheDoorsOpen)
            {
                return true;
            }
            return false;
        }


        public void PressTheFloorButton(int floor)
        {
            Console.WriteLine($"Нажали кнопку этажа {floor}");
            ArriveAtTheDesiredFloor(floor);

                  
        }
        public void PressTheDoorClosingButton()
        {
            Console.WriteLine($"Нажали кнопку закрытия дверей");
        }
        public void PressTheDoorOpeningButton()
        {
            Console.WriteLine($"Нажали кнопку открытия дверей");
        }
        public void PressTheButtonToCallTheDispatcher()
        {
            Console.WriteLine($"Нажали кнопку вызова диспетчера");
        }
        public void TheCabinSensorDetectsMovementBetweenTheDoors()
        {
            Console.WriteLine($"Датчик кабины фиксирует движение между дверьми");
        }
        public void TheCabinSensorDetectsTheAbsenceOfMovementBetweenTheDoors()
        {
            Console.WriteLine($"Датчик кабины фиксирует отсутствие движения между дверьми");
        }

        public void ArriveAtTheDesiredFloor(int floor)
        {
            PressTheFloorButton(floor);

            if (floor == CurrentFloor)
            {
                TheElevatorIsInPlace(floor);
            }

            else if (floor > CurrentFloor)
            {
                TheCabinSensorDetectsTheAbsenceOfMovementBetweenTheDoors();
                PressTheDoorClosingButton();
                GoingUp = true;
                CurrentFloor = floor;
                GoingUp = false;
                TheElevatorIsInPlace(floor);
            }

            else if (floor < CurrentFloor)
            {
                TheCabinSensorDetectsTheAbsenceOfMovementBetweenTheDoors();
                PressTheDoorClosingButton();
                GoingDown = true;
                CurrentFloor = floor;
                GoingDown = false;
                TheElevatorIsInPlace(floor);
            }
        }
        public void TheElevatorIsInPlace(int floor)
        {
            Console.WriteLine($"Лифт на месте. Приехал на {floor} этаж ");
            OpensTheDoors = true;
            ItStandsWithTheDoorsOpen = true;
        }
    }
}