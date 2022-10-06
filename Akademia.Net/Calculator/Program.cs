using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Podaj swoje imię.");
                var name = Console.ReadLine();

                Console.WriteLine("Podaj swoje miejsce urodznie.");
                var placeOfBirth = Console.ReadLine();

                Console.WriteLine("Podaj rok urodzenia");
                var year = GetInput();

                Console.WriteLine("Podaj miesiąc urodzenie.");
                var month = GetInput();

                Console.WriteLine("Podaj dzień urodzin.");
                var day = GetInput();

                var age = CalculateAge(year, month, day); 

                Console.WriteLine($"Cześć {name} urodziłeś się w {placeOfBirth} i masz {age} lat");          
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static int CalculateAge(int year, int month, int day)
        {
            var now = DateTime.Now;
           
            if (month < now.Month)
            {
                return now.Year - year - 1;
            }
            else if (month == now.Month && day < now.Day)
            {
                return now.Year - year - 1;
            }
            else
            {
                return now.Year - year;
            }                
        }

        private static int GetInput()
        {
            if (!int.TryParse(Console.ReadLine(), out int number))
                throw new Exception("Podana wartość jest niepoprawna");
            return number;           
        }
    }
}
