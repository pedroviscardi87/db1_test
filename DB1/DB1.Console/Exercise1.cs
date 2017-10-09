using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Console
{
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
    public class Exercise1
    {
        public int[] sequence { get; set; }
        public Exercise1 GetByNumber(int n)
        {
            List<int> result = new List<int>();
            result.Add(n);
            try
            {
                do
                {
                    if (n % 2 == 0)
                        n = n / 2;
                    else
                       n = 3 * n + 1;
                    result.Add(n);
                } while (n > 1);
                return new Exercise1() { sequence = result.ToArray() };
            }
            catch (Exception)
            {
                return new Exercise1() { sequence = result.ToArray() };
            }
        }
        public List<Exercise1> GetBySequence(int n = 0, int beginning = 0, int end = 0)
        {
            try
            {
                var list = new List<Exercise1>();

                if (beginning == 0 && end == 0)
                    list.Add(new Exercise1().GetByNumber(n));
                else
                    for (int i = beginning; i <= end; i++)
                        list.Add(new Exercise1().GetByNumber(i));

                return list;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
        public Exercise1 GetMax(List<Exercise1> lst)
        {
            return lst.Where(s => s.sequence.Length == lst.Max(m => m.sequence.Length)).FirstOrDefault();
        }
    }
}
