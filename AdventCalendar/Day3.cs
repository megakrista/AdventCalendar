using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar
{
    internal class Day3
    {
        List<string> batteries = new();
        List<int> joltages = new();

        public Day3()
        {
            GetBatteries();
            FindMaxJoltage();
            Console.WriteLine($"Result is {joltages.Sum()}");
        }

        public void FindMaxJoltage()
        {
            foreach (var battery in batteries)
            {
                var digits = battery.Select(ch => ch - '0').ToList();
                int highestNum = digits.Max();
                int index = digits.IndexOf(highestNum);

                var right = digits.Skip(index + 1);
                var left = digits.Take(index);

                var remainingDigits = right.Any() ? right : left;

                int secondHighestNum = remainingDigits.Max();

                int result = right.Any() ? Convert.ToInt32(string.Format("{0}{1}", highestNum, secondHighestNum)) : Convert.ToInt32(string.Format("{0}{1}", secondHighestNum, highestNum));

                joltages.Add(result);
            }
        }

        private List<string>  GetBatteries()
        {
            var lines = File.ReadAllLines("Data/batteries.txt");

            foreach (var line in lines)
            {
                batteries.Add(line);
            }
            return batteries;
        }
    }
}
