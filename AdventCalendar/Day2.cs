namespace AdventCalendar
{
    internal class Day2
    {
        List<(long start, long end)> ranges = new();
        List<long> repeatedNums = new();

        public Day2()
        {
            FindInvalid();
            var result = CountResult();

            Console.WriteLine($"Result is {result}");
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
                    var half = length / 2;
                    var left = numStr.Substring(0, half);
                    var right = numStr.Substring(half, half);

                    if (length % 2 == 0)
                    {
                       if(left == right)
                       {
                            repeatedNums.Add(num);
                       }
                    }
                }
            }
        }   

        private long CountResult()
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
