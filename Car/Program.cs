using Car;
using Car.Domain;
using Car.Domain.Aggregates;
using Car.Helpers;

CarStock AutoLager = new CarStock();

// Diese Region ist fuer das automatische befuellen und ausschreiben
#region AutomatischeErstellung
try
{
    AutoLager.AddCar(CarFactory.CreateCar(CarMarke.VW, 1960));
    AutoLager.AddCar(CarFactory.CreateCar(CarMarke.Ford, 1910));
    AutoLager.AddCar(CarFactory.CreateCar(CarMarke.VW, 1978));
    AutoLager.AddCar(CarFactory.CreateCar(CarMarke.VW, 1958));
    AutoLager.AddCar(CarFactory.CreateCar(CarMarke.Ford, 2015));
    AutoLager.AddCar(CarFactory.CreateCar(CarMarke.VW, 2023));
}
catch (Exception ex)
{
    ErrorWriter.WriteError(ex);
}

foreach(var carItem in AutoLager.GetAllCars())
{
    Console.WriteLine(carItem.GetStringForOutput());
}
#endregion

/*
// Diese Region ist mit User Input 
#region Kundeneingabe
Console.WriteLine("Das ist eine AutoLager Applikation");
Console.WriteLine("Um ein neues Auto einzugeben, bitte geben sie die Marke und den Jahrgang des Autos, z.B \"Ford, 1990\" ");
Console.WriteLine("Die unterstuetzten Automarken sind Ford und VW\n");
while (true)
{
    string? userInput = Console.ReadLine();
    try
    {
        ParserResult result = InputParser.ParseInput(userInput);
        AutoLager.AddCar(CarFactory.CreateCar(result.Marke, result.Jahrgang));
        foreach(var carItem in AutoLager.GetAllCars())
        {
            Console.WriteLine(carItem.GetStringForOutput());
        }
        // eine leere Zeile um es lesbarer zu machen in der Console
        Console.WriteLine();
    }
    catch (Exception ex)
    {
        ErrorWriter.WriteError(ex);
    }
}
#endregion
*/
