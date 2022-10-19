Console.WriteLine("Podaj liczbę:");
while (true)
{
    try
    {
        var number = GetInput();
        var fizzBuzz = new FizzBuzz.FizzBuzz();
        Console.WriteLine(fizzBuzz.Calculate(number));
        Console.WriteLine("Podaj kolejną liczbę lub wpis exit aby wyjść z aplikacji.");
    }

    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
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
