using Input;
using System.Collections;
using System.Text.RegularExpressions;

namespace Day05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var lines = ReadPuzzleInput.GetTextArray(5);

            int stackHeight = 0;
            List<int> stackPos = new();

            Regex regex = new Regex(@"(?:\d[0-9 ]*\d)");
            Regex regexDigit = new Regex(@"[0-9]");
            for (int r = 0; r < lines.Length; r++)
                {
                if (regex.IsMatch(lines[r]))
                {
                    stackHeight = r;
                    // save index position in string
                    for (int i = 0; i < lines[r].Length; i++)
                    {
                        if (regexDigit.IsMatch(Char.ToString(lines[r][i])))
                        {
                            stackPos.Add(i);
                        }
                    }
                    break;
                }
            }

            Dictionary<int, List<string>> cratesPerStack = new();

            for (int r = stackHeight-1; r >= 0; r--)
            {
                var crates = new List<string>();

                for (int i = 0; i < stackPos.Count; i++)
                {
                    var content = Char.ToString(lines[r][stackPos[i]]).Trim();
                    if (!(string.IsNullOrEmpty(content)))
                    {
                        if (!cratesPerStack.TryGetValue(i+1, out crates))
                        {
                            crates = new List<string>();
                            crates.Add(content);
                            cratesPerStack.Add(i+1, crates);
                        }
                        else 
                        {
                            crates.Add(content);
                            cratesPerStack[i+1] = crates;
                        }
                    }
                }
            }

            // Actions
            List<string[]> actions = new();
            Regex regexAction = new Regex(@"move*[0-9]*from*[0-9]*to*[0-9]");
            for (int r = stackHeight + 2; r < lines.Length; r++)
            {
                string[] numbers = Regex.Split(lines[r], @"\D+").Where(x => x.Length > 0).ToArray();
                actions.Add(numbers);
            }

            // Execute Actions
            //Puzzle01
            //foreach (var action in actions)
            //{
            //    int anz = Convert.ToInt16(action[0].ToString());
            //    int stackFromIdx = Convert.ToInt16(action[1].ToString());
            //    int stackToIdx = Convert.ToInt16(action[2].ToString());
            //    for (int i = 0; i < anz; i++)
            //    {
            //        var crate = cratesPerStack[stackFromIdx];
            //        var lastIndex = crate.Count - 1;

            //        var lastElement = crate[lastIndex];
            //        cratesPerStack[stackFromIdx].RemoveAt(lastIndex);

            //        cratesPerStack[stackToIdx].Add(lastElement);
            //    }
            //}

            //Puzzle02
            foreach (var action in actions)
            {
                int anz = Convert.ToInt16(action[0].ToString());
                int stackFromIdx = Convert.ToInt16(action[1].ToString());
                int stackToIdx = Convert.ToInt16(action[2].ToString());
                var crate = cratesPerStack[stackFromIdx];
                var lastIndex = crate.Count - anz;

                var elementsToMove = crate.GetRange(lastIndex, anz);

                cratesPerStack[stackFromIdx].RemoveRange(lastIndex, anz);

                cratesPerStack[stackToIdx].AddRange(elementsToMove); 
            }


            string result = string.Empty;
            foreach (var item in cratesPerStack.Values)
            {
                result += item[item.Count-1];
            }

            Console.WriteLine(result);
        }
    }
}