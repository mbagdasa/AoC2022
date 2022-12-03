using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Input;

namespace Day03
{
    public static class Puzzle01
    {
        public static void Execute()
        {
            var rucksackList = ReadPuzzleInput.GetFullTextTest(3).Split("|")
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .Select(x => x.Split(x.Length/2).ToList())
                                    ;

            List<int> sum = new List<int>();
            foreach (var item in rucksackList)
            {
                for (int i = 0; i<item[0].Length; i++)
                {
                    var itemChar = item[0][i];
                    
                    if (item[1].Contains(item[0][i]))
                    {
                        var itemPriority = (int)itemChar - 96;

                        if (Char.IsUpper(itemChar))
                        {
                            itemPriority += 58;
                        }

                        //Console.WriteLine(itemChar + " " + itemPriority);
                        sum.Add(itemPriority);
                        break;
                    }
                }
            }
            
            Console.WriteLine(sum.Sum());
        }
    }
}
