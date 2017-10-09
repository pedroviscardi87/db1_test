using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Console
{
    /// <summary>
    /// 2.	Utilizando LINQ, elabore um método que defina se o seguinte array contém somente números ímpares 
    /// e demonstre o resultado no console:
    ///     int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
    /// </summary>
    public class Exercise2
    {
        public int[] numbers { get; set; }

        public Exercise2()
        {
            numbers = new List<int>() { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 }.ToArray();
        }

        public Boolean HasUnpaired()
        {
            return numbers.Count(n => n % 2 == 0) == 0;
        }
    }
}
