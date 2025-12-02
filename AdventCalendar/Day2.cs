using System.Text.RegularExpressions;

namespace AdventCalendar
{
    internal class Day2
    {
        List<(long start, long end)> ranges = new();
        List<long> repeatedNumsTwice = new();
        List<long> repeatedNums = new();

        public Day2()
        {
            FindInvalid();
            FindInvalidWithRegex();
            var result = CountResult();
            var resultRegex = CountResultForRegex();


            Console.WriteLine($"Result is {result}");
            Console.WriteLine($"Result for regex is {resultRegex}");
        }

        private void FindInvalid()
        {
            ranges = GetRanges();

            foreach (var range in ranges)
            {
                var firstNum = range.start;
                var lastNum = range.end;

                for (long num = firstNum; num <= lastNum; num++)
                {
                    var numStr = num.ToString();
                    var length = numStr.Length;

                    if (length % 2 != 0)
                        continue;

                    var half = length / 2;
                    var left = numStr.Substring(0, half);
                    var right = numStr.Substring(half, half);

                    if (left == right)
                        repeatedNumsTwice.Add(num);
                }
            }
        }

        private void FindInvalidWithRegex()
        {
            ranges = GetRanges();
            var pattern = new Regex(@"^(\d+)\1+$");

            foreach (var range in ranges)
            {
                for (long num = range.start; num <= range.end; num++)
                {
                    var s = num.ToString();

                    if (pattern.IsMatch(s))
                        repeatedNums.Add(num);
                }
            }
        }

        private long CountResult()
        {
            var result = repeatedNumsTwice.Sum();
            return result;
        }
        private long CountResultForRegex()
        {
            var result = repeatedNums.Sum();
            return result;
        }

        private List<(long start, long end)> GetRanges()
        {
            var text = File.ReadAllText("Data/ranges.txt").Trim();
            var result = new List<(long start, long end)>();

            foreach (var part in text.Split(','))
            {
                var bounds = part.Split('-');
                var start = long.Parse(bounds[0]);
                var end = long.Parse(bounds[1]);
                result.Add((start, end));
            }

            return result;
        }
    }
}
