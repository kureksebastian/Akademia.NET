Console.WriteLine("Podaj liczbę:");
while (true)
{
    try
    {
        var number = GetInput();

        if (Calculate(number))
            Console.WriteLine("Liczba parzysta");
        else
            Console.WriteLine("Liczba nieparzysta");

        Console.WriteLine("Podaj kolejną liczbę lub wpis exit aby wyjść z aplikacji.");
    }

    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

static bool Calculate(int number)
{
    var result = number % 2;

    //if(result == 0)
    //    return true;
    //else
    //    return false;

    return result == 0;
}

 static int GetInput()
{
    var input = Console.ReadLine();
    if (input.ToUpper() == "EXIT")
        Environment.Exit(0);

    if (!int.TryParse(input, out int number))
        throw new Exception("Podana wartość jest niepoprawna");

    return number;
}
