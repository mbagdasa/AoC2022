using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public class Paper: IFightType
    {
        public int Points => 2;

        List<char> IFightType.IDs => new() { 'B', 'Y' };
    }
}
