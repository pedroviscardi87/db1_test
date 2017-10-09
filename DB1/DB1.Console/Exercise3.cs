using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Console
{
    /// <summary>
    /// 3.	Utilizando LINQ, elabore um método que traga somente os números do primeiro array que não estejam contidos no 
    /// segundo array e demonstre o resultado no console:
    ///     int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
    ///     int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };
    /// </summary>
    public class Exercise3
    {
        public int[] first { get; set; }
        public int[] second { get; set; }

        public Exercise3()
        {
            first = new List<int>() { 1, 3, 7, 29, 42, 98, 234, 93 }.ToArray();
            second = new List<int>() { 4, 6, 93, 7, 55, 32, 3 }.ToArray();
        }

        public int[] GetDifference()
        {
            return first.Except(second).ToArray();
        }
    }
}
