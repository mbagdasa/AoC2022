using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day02
{
    public interface IFightType
    {
        int Points { get; }
        
        List<char> IDs { get; }
    }
}
