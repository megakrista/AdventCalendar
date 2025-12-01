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
        const int maxNum = 99;
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

        private void Rotate(char direction, int distance)
        {
            currentPosition = direction == 'L' ? currentPosition - distance : currentPosition + distance;

            while (currentPosition > maxNum)
                currentPosition -= 100;
            while (currentPosition < 0)
                currentPosition += 100;

            CheckResult();
        }

        private void CheckResult() 
        {
            if (currentPosition == 0)
                result += 1;
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
