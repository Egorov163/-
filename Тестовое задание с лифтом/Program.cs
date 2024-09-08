using System.Collections.Generic;

namespace Тестовое_задание_с_лифтом
{
    class Program
    {
        static void Main(string[] args)
        {
            var lifts = new List<Lift>();
            var floors = new List<Floor>();

            // Create 2 lifts and 20 floors

            for (int i = 0; i < 2; i++)
            {
                lifts.Add(new Lift());
            }

            for (int i = 0; i < 20; i++)
            {
                floors.Add(new Floor(i + 1, lifts));
            }

            // Simulate passenger actions
            floors[0].CallLift();
            floors[0].SendLift(14);

            floors[14].CallLift();
            floors[14].SendLift(1);
        }
    }
}
