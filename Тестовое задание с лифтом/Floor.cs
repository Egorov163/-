using System;
using System.Collections.Generic;

namespace Тестовое_задание_с_лифтом
{
    public class Floor
    {
        private int floorNumber;
        private bool isLiftCalled;
        private List<Lift> lifts;

        public Floor(int number, List<Lift> liftList)
        {
            floorNumber = number;
            isLiftCalled = false;
            lifts = liftList;
        }

        public int FloorNumber
        {
            get { return floorNumber; }
        }

        public bool IsLiftCalled
        {
            get { return isLiftCalled; }
            set { isLiftCalled = value; }
        }

        public void CallLift()
        {
            isLiftCalled = true;
            Console.WriteLine($"Lift called on floor {floorNumber}.");
        }

        public void SendLift(int targetFloor)
        {
            Lift nearestLift = GetNearestLift();
            nearestLift.PressFloorButton(targetFloor);
            nearestLift.Move();
            isLiftCalled = false;
        }

        private Lift GetNearestLift()
        {
            Lift nearestLift = lifts[0];
            int minDistance = Math.Abs(nearestLift.CurrentFloor - floorNumber);

            for (int i = 1; i < lifts.Count; i++)
            {
                int distance = Math.Abs(lifts[i].CurrentFloor - floorNumber);
                if (distance < minDistance)
                {
                    nearestLift = lifts[i];
                    minDistance = distance;
                }
            }

            return nearestLift;
        }
    }
}
