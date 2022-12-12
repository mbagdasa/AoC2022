using Input;
using System;
using System.Net.Http.Headers;

namespace Day08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inputList = ReadPuzzleInput.GetFullTextTest(8).Split("|")
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .Select(x => x.ToCharArray())
                                    .Select(x => Array.ConvertAll(x, c => (int)Char.GetNumericValue(c)))
                                    .ToList()
                                    ;

            var ct = 0;
            List<int> scenicVal = new List<int>();
            // loop thru rows
            for (int r = 0; r < inputList.Count; r++)
            {
                // loop thru columns
                for (int c = 0; c < inputList[r].Length; c++)
                {
                    var currVal = inputList[r][c];

                    var maxValLeft = getMaxValLeft(r, c, inputList);
                    var maxValRight = getMaxValRight(r, c, inputList);
                    var maxValTop = getMaxValTop(r, c, inputList);
                    var maxValBottom = getMaxValBottom(r, c, inputList);

                    if (currVal > maxValLeft[0] || currVal > maxValRight[0]
                        || currVal > maxValTop[0] || currVal > maxValBottom[0])
                    {
                        Console.Write(currVal);
                        ct ++;
                    }
                    else
                    {
                        Console.Write(".");
                    }

                    // Puzzle 2
                    var scenicScoreLeft = Math.Abs(maxValLeft[1]-c)==0 ? 1 : Math.Abs(maxValLeft[1] - c);
                    var scenicScoreRight = Math.Abs(maxValRight[1]-c) == 0 ? 1 : Math.Abs(maxValRight[1] - c);
                    var scenicScoreTop = Math.Abs(maxValTop[1]-c) == 0 ? 1 : Math.Abs(maxValTop[1] - c);
                    var scenicScoreBottom = Math.Abs(maxValBottom[1] - c) == 0 ? 1 : Math.Abs(maxValBottom[1] - c);

                    var val = scenicScoreLeft * scenicScoreRight * scenicScoreTop * scenicScoreBottom;
                    scenicVal.Add(val);
                    Console.Write($"({val})");
                }
                Console.WriteLine();

            }

            Console.WriteLine(scenicVal.Max());
        }

        public static int[] getMaxValLeft(int row, int col, List<int[]> inputList)
        {
            int[] elem = new int[2] { -1, 0 };
            var c = col;
            var subset = inputList[row][0..c];
            if (subset.Length == 0)
            {
                return elem;
            }
            var max = subset.Max();
            var index = Array.IndexOf(inputList[row], max);
            elem[0] = max;
            elem[1] = index;
            return elem;
        }

        public static int[] getMaxValRight(int row, int col, List<int[]> inputList)
        {
            int[] elem = new int[2] { -1, 0 };
            var c = col + 1;
            var len = inputList[row].Length;
            var subset = inputList[row][c..len];
            if (subset.Length == 0)
            {
                return elem;
            }
            var max = subset.Max();
            var index = Array.IndexOf(inputList[row], max);
            elem[0] = max;
            elem[1] = index;
            //return subset.Max();
            return elem;
        }

        public static int[] getMaxValTop(int row, int col, List<int[]> inputList)
        {
            int[] elem = new int[2] { -1, 0 };
            List<int> subset = new();
            for (int r = 0; r < row; r++)
            {
                subset.Add(inputList[r][col]);
            }
            if (subset.Count == 0)
            {
                return elem;
            }
            var max = subset.Max();
            var index = subset.IndexOf(max);
            elem[0] = max;
            elem[1] = index;
            //return subset.Max();
            return elem;
        }

        public static int[] getMaxValBottom(int row, int col, List<int[]> inputList)
        {
            int[] elem = new int[2] { -1, 0 };
            List<int> subset = new();
            for (int r = row + 1; r < inputList.Count; r++)
            {
                subset.Add(inputList[r][col]);
            }
            if (subset.Count == 0)
            {
                return elem;
            }
            var max = subset.Max();
            var index = subset.IndexOf(max);

            if (row == 0)
            {
                index += 1;
            }
            else
            {
                index += row + 1;
            }
            elem[0] = max;
            elem[1] = index;
            //return subset.Max();
            return elem;
        }
    }
}