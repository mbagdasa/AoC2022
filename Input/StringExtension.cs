using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input
{
    public static class StringExtension
    {
        public static IEnumerable<string> Split(this string str, int n)
        {
            if (String.IsNullOrEmpty(str) || n < 1)
            {
                throw new ArgumentException();
            }

            return Enumerable.Range(0, str.Length / n)
            .Select(i => str.Substring(i * n, n));
        }
    }
}
