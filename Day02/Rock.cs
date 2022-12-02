using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public class Rock: IFightType
    {
        public int Points => 1;

        List<char> IFightType.IDs => new() { 'A', 'X' };
    }
}
