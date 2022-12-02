using Input;
using System;
using System.Reflection;


namespace Day01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var carriedCaloriesSum = ReadPuzzleInput.GetFullText(1).Split("||")
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .Select(x => x.Split("|")
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .Select(Int32.Parse).ToList<int>())
                                    .Select(x => x.Sum())
                                    .ToList()
                                    .OrderByDescending(x => x);

            ;

            Console.WriteLine(carriedCaloriesSum.Max());
            Console.WriteLine(carriedCaloriesSum.Take(3).Sum());
        }
    }
}