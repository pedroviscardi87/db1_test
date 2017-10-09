using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Console
{
    public static class Program
    {
        #region Utils

        private static String Concat<t>(this IEnumerable<t> lst, Func<t, Object> valueFunction, String separator = ", ", String format = null, String defaultValue = null, Boolean distinct = false)
        {
            if (lst == null || lst.Count() == 0)
                return defaultValue;
            var newlst = (distinct ? lst.Select(item => valueFunction(item)).Distinct() : lst.Select(item => valueFunction(item))).ToList();
            var str = new StringBuilder();
            foreach (var value in newlst)
            {
                var valuestr = Convert.ToString(value);
                if (!String.IsNullOrEmpty(valuestr))
                    str.Append(String.IsNullOrEmpty(format) ? valuestr + separator : String.Format("{0:" + format + "}", value) + separator);
            }
            return String.IsNullOrEmpty(str.ToString()) ? null : str.Remove(str.Length - separator.Length, separator.Length).ToString();
        }

        #endregion

        #region Execute Exercise 1

        /// <summary>
        ///     1.	Para definir uma sequência a partir de um número inteiro o positivo, temos as seguintes regras:
        ///          •	Se n é par, o próximo valor é n/2
        ///          •	Se n é ímpar, o próximo valor é 3n + 1
        ///     Usando a regra acima e iniciando com o número 13, geramos a seguinte sequência: 
        ///          13 > 40 > 20 > 10 > 5 > 16 > 8 > 4 > 2 > 1
        ///     Podemos ver que esta sequência(iniciando em 13 e terminando em 1) contém 10 termos.
        ///     Embora ainda não tenha sido provado(este problema é conhecido como Problema de Collatz), sabemos que com qualquer número 
        ///     que você começar, a sequência resultante chega no número 1 em algum momento.
        ///     Desenvolva uma aplicação que descubra qual o número inicial entre 1 e 1 milhão que produz a maior sequência.
        /// </summary>
        /// <param name="n">Sequência para somente um número: Exemplo 13</param>
        ///     Os parâmetros abaixo serão utilizados para trazer uma sequência entre ínicio e fim, 
        ///     trazendo a maior sequência do intervalo. 
        /// <param name="beginning">Faixa de ínicio</param>
        /// <param name="end">Faixa final</param>
        public static void ExecExercise1(int n, int beginning, int end)
        {
            if (beginning > end)
            {
                System.Console.Write("\n");
                System.Console.WriteLine(" O ínicio não pode ser maior que o fim!!");
            }

            var list = new Exercise1().GetBySequence(n, beginning, end);
            //loop list sequences
            foreach (var s in list)
            {
                System.Console.Write("\n");
                System.Console.WriteLine(" Sequência: {0}", s.sequence.Concat(t => t, " > "));
                System.Console.WriteLine(" Tamanho: {0}", s.sequence.Length);
            }
            //verify beginning and end
            if (beginning > 0 && end > 0)
            {
                //max sequence
                var max = new Exercise1().GetMax(list);
                System.Console.Write("\n => MAIOR SEQUÊNCIA ENTRE " + beginning + " E " + end);
                System.Console.WriteLine("\n --------------------------------------------------------------------------");
                System.Console.WriteLine(" Sequência: {0}", max.sequence.Concat(t => t, " > "));
                System.Console.WriteLine(" Tamanho: {0}", max.sequence.Length);
            }
            //wait
            System.Console.ReadLine();
        }

        #endregion

        #region Execute Exercise 2

        /// <summary>
        /// 2.	Utilizando LINQ, elabore um método que defina se o seguinte array contém somente números ímpares 
        /// e demonstre o resultado no console:
        ///     int[] numeros = { 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
        /// </summary>
        public static void ExecExercise2()
        {
            Exercise2 exec2 = new Exercise2();
            System.Console.WriteLine(" O Array [{0}] contém somente números ímpares: {1}", exec2.numbers.Concat(t => t), exec2.HasUnpaired() ? "Sim" : "Não");
            System.Console.ReadLine();
        }

        #endregion

        #region Execute Exercise 3

        /// <summary>
        /// 3.	Utilizando LINQ, elabore um método que traga somente os números do primeiro array que não estejam contidos no 
        /// segundo array e demonstre o resultado no console:
        ///     int[] primeiroArray = { 1, 3, 7, 29, 42, 98, 234, 93 };
        ///     int[] segundoArray = { 4, 6, 93, 7, 55, 32, 3 };
        /// </summary>
        public static void ExecExercise3()
        {
            Exercise3 exec3 = new Exercise3();
            System.Console.WriteLine(" Primeiro array [{0}] ", exec3.first.Concat(n => n));
            System.Console.WriteLine(" Segundo array [{0}] ", exec3.second.Concat(n => n));
            System.Console.WriteLine(" Números do primeiro array que não estão no segundo [{0}] ", exec3.GetDifference().Concat(n => n));
            System.Console.ReadLine();
        }

        #endregion

        private static void Main(string[] args)
        {
            ExecExercise1(13, 0, 0);
            ExecExercise1(13, 1, 1000000);
            ExecExercise2();
            ExecExercise3();
        }
    }
}
