using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {    
            int number = 23423;
            double numberBig = 123123.34;
            decimal amount = 31.12M;
            bool isReady = false;
            string name = "My name";
            char sign = 'c';
            DateTime today = new DateTime(2022, 9, 1, 12, 0, 0);

            List<int> lista = new List<int> { 1, 2, 3 };
            lista.Add(4);
            Console.WriteLine(lista[0]);

            List<string> stringLista = new List<string> { "one" };


            Console.ReadKey();
        }
    }
}
