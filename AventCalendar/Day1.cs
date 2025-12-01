using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AventCalendar
{
    internal class Day1
    {
        int result = 0;
        int currentPosition = 50;
        const int minNum = 0;
        const int maxNum = 100;
        List<KeyValuePair<char, int>> rotations = new List<KeyValuePair<char, int>>();


        public Day1()
        {
            ExecuteRotations();
            Console.WriteLine("Final Position: " + currentPosition);
            Console.WriteLine("Number of times pointed at 0: " + result);
        }

        private void ExecuteRotations()
        {
            GetRotations();
            foreach (var rotation in rotations)
            {
                char direction = rotation.Key;
                int distance = rotation.Value;
                Rotate(direction, distance);
            }
        }

        private int Rotate(char direction, int distance)
        {
            currentPosition = direction == 'L' ? currentPosition - distance : currentPosition + distance;

            while (currentPosition > maxNum)
                currentPosition -= maxNum;
            while (currentPosition < minNum)
                currentPosition += maxNum;

            CheckHundred();
            CheckResult();

            return currentPosition;
        }

        private void CheckResult() 
        {
            if (currentPosition == minNum)
                result += 1;
        }
        private int CheckHundred()
        {
            if (currentPosition == maxNum)
                 currentPosition = 0;
            return currentPosition;
        }

        private List<KeyValuePair<char, int>> GetRotations()
        {
            var lines = File.ReadAllLines("Data/rotations.txt");

            foreach (var line in lines)
            {
                var dir = line[0];
                var dist = int.Parse(line.Substring(1));
                rotations.Add(new KeyValuePair<char, int>(dir, dist));
            }
            return rotations;
        }
    }
}
