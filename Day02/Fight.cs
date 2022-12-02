using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    internal class Fight
    {

        IFightType p1;
        IFightType p2;
        private int result = int.MinValue;

        public int Result
        {
            get 
            {
                if (result >= 0)
                    return result;

                result = 0;
                if (p1.GetType() == p2.GetType())
                {
                    result += 3;
                }
                else if (p2 is Paper && p1 is Rock)
                {
                    result += 6;
                }
                else if (p2 is Rock && p1 is Scissor)
                {
                    result += 6;
                }
                else if (p2 is Scissor && p1 is Paper)
                {
                    result += 6;
                }

                result += p2.Points;

                return result; 
            }
        }


        public Fight(IFightType p1, IFightType p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        
    }
}
