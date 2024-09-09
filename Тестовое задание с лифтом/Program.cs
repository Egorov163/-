using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тестовое_задание_с_лифтом
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = new ElevatorSystem();
            var passengers = new List<(string, int, int)>
        {
            ("Пассажир 1", 1, 14),
            ("Пассажир 2", 15, 1)
        };

            foreach (var passenger in passengers)
            {
                try
                {
                    system.SimulatePassengers(passenger.Item1, passenger.Item2, passenger.Item3);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            Console.WriteLine($"{Environment.NewLine}Симуляция завершена. Нажмите любую клавишу для выхода.");
            Console.ReadKey();
        }
    }
}
