using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Тестовое_задание_с_лифтом
{
    public class ElevatorSystem
    {
        private List<Elevator> _elevators;
        private List<Floor> _floors;

        public ElevatorSystem()
        {
            _elevators = new List<Elevator>
            {
                new Elevator("Лифт 1", 5),
                new Elevator("Лифт 2", 10)
            };

            _floors = new List<Floor>();
            var floorsCount = 20;

            for (var i = 1; i <= floorsCount; i++)
            {
                _floors.Add(new Floor(i));
            }
        }

        private void CallElevator(int floorNumber)
        {
            var minFloor = 1;
            var maxFloor = 20;

            if (floorNumber < minFloor || floorNumber > maxFloor)
            {
                throw new ArgumentOutOfRangeException("Номер этажа вышел за границы! " +
                    "Допустимый диапазон: [" + minFloor + "; " + maxFloor + "]");
            }

            var floor = _floors[floorNumber - 1];
            floor.PressCallButton();

            var nearestElevator = FindNearestElevator(floorNumber);
            var passengerClick = false;
            nearestElevator.PressFloorButton(floorNumber, passengerClick);
        }

        private Elevator FindNearestElevator(int floorNumber)
        {
            var result = _elevators
                .Where(e => e.State != ElevatorState.Overload)
                .OrderBy(e => Math.Abs(e.CurrentFloor - floorNumber))
                .FirstOrDefault();

            if (result == null)
            {
                throw new InvalidOperationException("Свободных лифтов нет");
            }

            return result;
        }

        private void UpdateFloorStatuses()
        {
            foreach (var floor in _floors)
            {
                floor.UpdateElevatorStatus(_elevators[0].Name, _elevators[0].CurrentFloor, _elevators[0].State);
                floor.UpdateElevatorStatus(_elevators[1].Name, _elevators[1].CurrentFloor, _elevators[1].State);
            }
        }

        private void SimulateElevatorMovement(Elevator elevator, int targetFloor)
        {
            if (elevator.State == ElevatorState.Overload)
            {
                throw new InvalidOperationException("Лифт не может начать движение, так как перегружен");
            }

            if (elevator.CurrentFloor != targetFloor)
            {
                Console.WriteLine($"{elevator.Name} начинает движение к этажу {targetFloor}");
            }

            while (elevator.CurrentFloor != targetFloor)
            {
                elevator.Move();
                UpdateFloorStatuses();
                _floors[elevator.CurrentFloor - 1].DisplayStatus();
                Thread.Sleep(1000);
            }

            _floors[elevator.CurrentFloor - 1].ResetCallButton();
        }

        public void SimulatePassengers(string name, int fromFloor, int toFloor)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Название лифта не содержит символов или равно null");
            }

            var minFloor = 1;
            var maxFloor = 20;
            var passengersCount = 1;

            if (fromFloor < minFloor || fromFloor > maxFloor)
            {
                throw new ArgumentOutOfRangeException("Номер начального этажа вышел за границы! " +
                    "Допустимый диапазон: [" + minFloor + "; " + maxFloor + "]");
            }

            if (toFloor < minFloor || toFloor > maxFloor)
            {
                throw new ArgumentOutOfRangeException("Номер конечного этажа вышел за границы! " +
                    "Допустимый диапазон: [" + minFloor + "; " + maxFloor + "]");
            }

            Console.WriteLine($"\n--- Симуляция {name} ---");
            Console.WriteLine($"{name} вызывает лифт на {fromFloor} этаже");
            CallElevator(fromFloor);
            UpdateFloorStatuses();
            _floors[fromFloor - 1].DisplayStatus();
            Thread.Sleep(2000);

            var elevator = FindNearestElevator(fromFloor);
            var passengerClick = true;

            SimulateElevatorMovement(elevator, fromFloor);
            Console.WriteLine($"{name} входит в лифт");
            elevator.AddPassengers(passengersCount);
            elevator.PressFloorButton(toFloor, passengerClick);
            SimulateElevatorMovement(elevator, toFloor);
            elevator.RemovePassengers(passengersCount);
            Console.WriteLine($"{name} выходит на {toFloor} этаже");
        }
    }
}
