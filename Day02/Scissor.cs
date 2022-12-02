using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public class Scissor: IFightType
    {
        public int Points => 3;

        List<char> IFightType.IDs => new() { 'C', 'Z' };
    }
}
