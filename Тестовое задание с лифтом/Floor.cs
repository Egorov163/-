using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тестовое_задание_с_лифтом
{
    public class Floor
    {
        public int FloorNumber { get; private set; }
        public int FirstElevatorCurrentFloor { get; private set; }
        public ElevatorState FirstElevatorCurrentState { get; private set; }
        public int SecondElevatorCurrentFloor { get; private set; }
        public ElevatorState SecondElevatorCurrentState { get; private set; }
        public bool IsCallButtonPressed { get; private set; }
        public Floor(int floorNumber)
        {
            if (floorNumber < 1 || floorNumber > 20)
            {
                throw new ArgumentOutOfRangeException("Числовое значение вышло за границы");
            }

            FloorNumber = floorNumber;
            IsCallButtonPressed = false;
            FirstElevatorCurrentFloor = 1;
            SecondElevatorCurrentFloor = 1;
            FirstElevatorCurrentState = ElevatorState.StandingWithOpenDoors;
            SecondElevatorCurrentState = ElevatorState.StandingWithOpenDoors;
        }

        public void PressCallButton()
        {
            IsCallButtonPressed = true;
            var buttonName = FloorNumber == 1
                ? "вверх"
                : "вниз";

            Console.WriteLine($"Этаж {FloorNumber}: Вызов лифта. Нажата кнопка {buttonName}");
        }

        public void ResetCallButton()
        {
            IsCallButtonPressed = false;
        }

        public void UpdateElevatorStatus(string elevatorName, int currentFloor, ElevatorState currentState)
        {
            var firstElevatorName = "Лифт 1";
            var secondElevatorName = "Лифт 2";

            if (elevatorName == firstElevatorName)
            {
                FirstElevatorCurrentFloor = currentFloor;
                FirstElevatorCurrentState = currentState;
            }
            else if (elevatorName == secondElevatorName)
            {
                SecondElevatorCurrentFloor = currentFloor;
                SecondElevatorCurrentState = currentState;
            }
        }

        public void DisplayStatus()
        {
            var elevatorStates = new Dictionary<ElevatorState, string>
            {
                {ElevatorState.MovingUp, "Движение вверх"},
                {ElevatorState.MovingDown, "Движение вниз"},
                {ElevatorState.OpeningDoors, "Открывает двери"},
                {ElevatorState.ClosingDoors, "Закрывает двери"},
                {ElevatorState.StandingWithOpenDoors, "Стоит с открытыми дверями"},
                {ElevatorState.Overload, "Перегружен"}
            };

            var firstElevatorName = "Лифт 1";
            var secondElevatorName = "Лифт 2";

            Console.WriteLine($"Статус этажа {FloorNumber}:");
            Console.WriteLine($"  {firstElevatorName}: Этаж {FirstElevatorCurrentFloor}, Состояние: {elevatorStates[FirstElevatorCurrentState]}");
            Console.WriteLine($"  {secondElevatorName}: Этаж {SecondElevatorCurrentFloor}, Состояние: {elevatorStates[SecondElevatorCurrentState]}");
            Console.WriteLine($"  Кнопка вызова: {(IsCallButtonPressed ? "Нажата" : "Не нажата")}");
        }
    }
}
