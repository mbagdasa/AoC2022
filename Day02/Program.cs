using Input;

namespace Day02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var strategyAdvisor = ReadPuzzleInput.GetFullText(2).Split("|")
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .Select(x => x.Split(" ")
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .ToList());

            int totalScore = 0;
            foreach (var item in strategyAdvisor)
            {
                IFightType p1;
                IFightType p2;

                
                if (item[0].Equals("A"))
                {
                    p1 = new Rock();
                }
                else if (item[0].Equals("B"))
                {
                    p1 = new Paper();
                }
                else
                {
                    p1 = new Scissor();
                }


                // Puzzle 1
                //if (item[1].Equals("X"))
                //{
                //    p2 = new Rock();
                //}
                //else if (item[1].Equals("Y"))
                //{
                //    p2 = new Paper();
                //}
                //else
                //{
                //    p2 = new Scissor();
                //}

                // Puzzle 2
                // X - lose
                // Y - draw
                // Z - win
                if (item[1].Equals("X"))
                {
                    if(p1 is Rock)
                    {
                        p2 = new Scissor();
                    }
                    else if (p1 is Paper)
                    {
                        p2 = new Rock();
                    }
                    else
                    {
                        p2 = new Paper();
                    }
                }
                else if (item[1].Equals("Y"))
                {
                    if (p1 is Rock)
                    {
                        p2 = new Rock();
                    }
                    else if (p1 is Paper)
                    {
                        p2 = new Paper();
                    }
                    else
                    {
                        p2 = new Scissor();
                    }
                }
                else
                {
                    if (p1 is Rock)
                    {
                        p2 = new Paper();
                    }
                    else if (p1 is Paper)
                    {
                        p2 = new Scissor();
                    }
                    else
                    {
                        p2 = new Rock();
                    }
                }


                var fight = new Fight(p1, p2);
                Console.WriteLine(fight.Result);
                totalScore += fight.Result;
            }

            Console.WriteLine(totalScore    );
        }
    }
}