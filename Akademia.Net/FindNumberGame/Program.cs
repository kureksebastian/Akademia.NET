// See https://aka.ms/new-console-template for more information

Random random = new Random();
int randomNumber = random.Next(0, 100);
int tries = 0;

do
{ 
    try
    {
        Console.WriteLine("Gra polega na odgadnięciu wylosowanej liczby.");
        Console.WriteLine("Podaj liczbę z zakresu 0-100:");
        if (!int.TryParse(Console.ReadLine(), out int number))
            throw new Exception("Podana wartość jest niepoprawna");
        tries++;

        if (number < randomNumber)
        {
            Console.WriteLine("Podana liczba jest mniejsza");            
        }
        else if( number > randomNumber)
        {
            Console.WriteLine("Podna liczbna jest większa.");
        }
        else if (number == randomNumber)
        {
            Console.WriteLine($"Odgadłeś liczbę po {tries} próbach, Gratulacje!");
            break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }


} while (true);

Console.ReadLine();