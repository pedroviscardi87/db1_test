using Microsoft.VisualStudio.TestTools.UnitTesting;
using DB1.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.Console.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ExecExercise1Test()
        {
            //N = 13
            //S = 13 > 40 > 20 > 10 > 5 > 16 > 8 > 4 > 2 > 1
            var compare = new Exercise1() { sequence = new List<int>() { 13, 40, 20, 10, 5, 16, 8, 4, 2, 1 }.ToArray() };
            var sequence_exe = new Exercise1().GetBySequence(13, 0, 0).FirstOrDefault();
            Assert.AreEqual(true, compare.sequence.Except(sequence_exe.sequence).ToArray().Length == 0);
        }

        [TestMethod()]
        public void ExecExercise2Test()
        {
            Exercise2 exec2 = new Exercise2();
            exec2.numbers = new List<int>() { 1, 3, 5, 7, 9, 11 }.ToArray();
            var has_unpaired = exec2.HasUnpaired();
            System.Diagnostics.Debug.WriteLine(String.Format(" Contém somente números ímpares: {0}", has_unpaired ? "Sim" : "Não"));
            Assert.AreEqual(true, has_unpaired);
        }

        [TestMethod()]
        public void ExecExercise3Test()
        {
            int[] result = new int[3] { 7, 8, 9 };
            Exercise3 exec3 = new Exercise3();
            exec3.first = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.ToArray();
            exec3.second = new List<int>() { 1, 2, 3, 4, 5, 6 }.ToArray();
            System.Diagnostics.Debug.WriteLine(" Primeiro array [1, 2, 3, 4, 5, 6] ");
            System.Diagnostics.Debug.WriteLine(" Segundo array [1, 2, 3, 4, 5, 6, 7, 8, 9] ");
            System.Diagnostics.Debug.WriteLine(" Números do primeiro array que não estão no segundo [7, 8, 9] ");
            var has_difference = result.Except(exec3.GetDifference()).ToArray().Length == 0;
            System.Diagnostics.Debug.WriteLine(String.Format(" O Resultado está correto: {0}", has_difference ? "Sim" : "Não"));
            Assert.AreEqual(true, has_difference);

        }
    }
}