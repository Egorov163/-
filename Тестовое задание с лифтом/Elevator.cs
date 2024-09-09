using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Тестовое_задание_с_лифтом
{
    public class Elevator
    {
        public int CurrentFloor { get; private set; }
        public ElevatorState State { get; private set; }
        public int Capacity { get; private set; }
        public string Name { get; private set; }
        public bool DoorsOpen { get; private set; }
        public bool MovementDetected { get; private set; }
        public int CurrentPassengers { get; private set; }

        private List<int> _destinations = new List<int>();
        private Random _random = new Random();

        public Elevator(string name, int capacity)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Название лифта не содержит символов или равно null");
            }

            var minCapacity = 1;

            if (capacity < minCapacity)
            {
                throw new InvalidOperationException("Вместимость лифта должна быть натуральным числом");
            }

            Name = name;
            Capacity = capacity;
            CurrentFloor = 1;
            State = ElevatorState.StandingWithOpenDoors;
            DoorsOpen = true;
            CurrentPassengers = 0;
        }

        public void PressFloorButton(int floor, bool passengerClick)
        {
            var minFloor = 1;
            var maxFloor = 20;

            if (floor < minFloor || floor > maxFloor)
            {
                throw new ArgumentOutOfRangeException("Номер этажа вышел за границы! " +
                    "Допустимый диапазон: [" + minFloor + "; " + maxFloor + "]");
            }

            if (passengerClick && CurrentFloor != minFloor && floor > CurrentFloor)
            {
                throw new InvalidOperationException("Лифт, находящийся не на первом этаже, " +
                    "может ехать только вниз");
            }

            if (!_destinations.Contains(floor) && CurrentFloor != floor)
            {
                _destinations.Add(floor);
                Console.WriteLine($"{Name}: Добавлен этаж назначения {floor}");
            }
        }

        public void PressCloseDoorsButton()
        {
            if (DoorsOpen)
            {
                Console.WriteLine($"{Name}: Нажата кнопка закрытия дверей");
                CloseDoors();
            }
        }

        public void PressOpenDoorsButton()
        {
            if (!DoorsOpen)
            {
                Console.WriteLine($"{Name}: Нажата кнопка открытия дверей");
                OpenDoors();
            }
        }

        public void PressCallOperatorButton()
        {
            Console.WriteLine($"{Name}: Нажата кнопка вызова диспетчера");
        }

        public void DetectMovementBetweenDoors()
        {
            MovementDetected = true;
            Console.WriteLine($"{Name}: Обнаружено движение между дверьми");
            if (State == ElevatorState.ClosingDoors)
            {
                OpenDoors();
                CloseDoors();
            }
        }

        public void DetectNoMovementBetweenDoors()
        {
            MovementDetected = false;
            Console.WriteLine($"{Name}: Движение между дверьми не обнаружено");
        }

        public void AddPassengers(int count)
        {
            if (State != ElevatorState.StandingWithOpenDoors)
            {
                throw new InvalidOperationException("В лифт не могут зайти пассажиры, так как он закрыт");
            }

            var minPassengersCount = 1;

            if (count < minPassengersCount)
            {
                throw new InvalidOperationException("Количество пассажиров должно быть натуральным числом");
            }

            var availableSpace = Capacity - CurrentPassengers;
            CurrentPassengers += count;
            if (count <= availableSpace)
            {
                Console.WriteLine($"{Name}: Вошло {count} пассажир(ов). Текущее количество пассажиров: {CurrentPassengers}");
            }
            else
            {
                Console.WriteLine($"{Name}: Предупреждение о перегрузе! Максимальная вместимость: {Capacity}");
                State = ElevatorState.Overload;
            }
        }

        public void RemovePassengers(int count)
        {
            if (count < 1)
            {
                throw new InvalidOperationException("Количество пассажиров должно быть натуральным числом");
            }

            if (CurrentPassengers - count < 0)
            {
                throw new InvalidOperationException("Количество людей, покинувших лифт, " +
                    "не должно быть больше общего количества");
            }

            if (State != ElevatorState.StandingWithOpenDoors)
            {
                throw new InvalidOperationException("Из лифта не могут зайти пассажиры, так как он закрыт");
            }

            CurrentPassengers -= count;
            Console.WriteLine($"{Name}: Вышло {count} пассажир(ов). Текущее количество пассажиров: {CurrentPassengers}");
            if (State == ElevatorState.Overload && CurrentPassengers <= Capacity)
            {
                State = ElevatorState.StandingWithOpenDoors;
                Console.WriteLine($"{Name}: Перегруз устранен");
            }
        }

        public void Move()
        {
            if (_destinations.Count == 0)
            {
                return;
            }

            if (DoorsOpen)
            {
                CloseDoors();
            }

            var direction = DetermineDirection();
            var maxFloorValue = 20;
            var minFloorValue = 1;
            State = direction;

            if (direction == ElevatorState.MovingUp)
            {
                CurrentFloor = Math.Min(CurrentFloor + 1, maxFloorValue);
                Console.WriteLine($"{Name}: Движение вверх. Текущий этаж: {CurrentFloor}");
            }
            else if (direction == ElevatorState.MovingDown)
            {
                CurrentFloor = Math.Max(CurrentFloor - 1, minFloorValue);
                Console.WriteLine($"{Name}: Движение вниз. Текущий этаж: {CurrentFloor}");
            }

            if (_destinations.Contains(CurrentFloor))
            {
                _destinations.Remove(CurrentFloor);
                ArriveAtFloor();
            }
        }

        private void ArriveAtFloor()
        {
            Console.WriteLine($"{Name}: Прибытие на этаж {CurrentFloor}");
            Thread.Sleep(3000);
            OpenDoors();
        }

        private void OpenDoors()
        {
            State = ElevatorState.OpeningDoors;
            Console.WriteLine($"{Name}: Открытие дверей");
            Thread.Sleep(2000);
            DoorsOpen = true;
            State = ElevatorState.StandingWithOpenDoors;
        }

        private void CloseDoors()
        {
            if (State == ElevatorState.Overload)
            {
                Console.WriteLine("Двери нельзя закрыть, пока перегруз не устранен");
                return;
            }

            State = ElevatorState.ClosingDoors;
            Console.WriteLine($"{Name}: Закрытие дверей");
            var maxRandomValue = 3;
            var detectMovementValue = 0;

            if (_random.Next(maxRandomValue) == detectMovementValue)
            {
                DetectMovementBetweenDoors();
                return;
            }
            Thread.Sleep(2000);
            DoorsOpen = false;
            DetectNoMovementBetweenDoors();
        }

        private ElevatorState DetermineDirection()
        {
            if (_destinations.Count == 0)
            {
                return ElevatorState.StandingWithOpenDoors;
            }

            return _destinations[0] > CurrentFloor
                ? ElevatorState.MovingUp
                : ElevatorState.MovingDown;
        }
    }
}
