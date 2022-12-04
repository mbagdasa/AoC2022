using Input;

namespace Day04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool puzzle01 = false;
            bool puzzle02 = true;

            var sectionList = ReadPuzzleInput.GetFullText(4).Split("|")
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .Select(x => x.Split(",")
                                    .Select(x => x.Split("-")
                                    .Select(Int32.Parse).ToList<int>()))
                                    ;

            int ct = 0;
            foreach (var item in sectionList)
            {
                var r1 = item.ElementAt(0);
                var r2= item.ElementAt(1);

                if (puzzle01)
                {
                    if (r1[0] >= r2[0] && r1[1] <= r2[1])
                    {
                        // r1 full in r2
                        ct++;
                    }
                    else if (r2[0] >= r1[0] && r2[1] <= r1[1])
                    {
                        // r2 full in r1
                        ct++;
                    }
                }
                else
                {
                    if (!(r1[0] > r2[1] || r1[1] < r2[0]))
                    {
                        
                        ct++;
                    }
                }
                
            }
            Console.WriteLine(ct);
        }
    }
}