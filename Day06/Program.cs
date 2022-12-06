using Input;

namespace Day06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var buffer = ReadPuzzleInput.GetFullText(6);
            var range = 14;

            for (int i = 0; i < buffer.Length; i++)
            {
                if (i < (range-1))
                {
                    continue;
                }

                List<char> marker = new List<char>()
                {
                    buffer[i]
                };
                for (int j = 1; j < range; j++)
                {
                    marker.Add(buffer[i - j]);
                }

                var ct = marker.Select(x => x.ToString()).Distinct();
                if (ct.Count() == range)
                {
                    Console.WriteLine(i+1);
                }
            }
        }
    }
}