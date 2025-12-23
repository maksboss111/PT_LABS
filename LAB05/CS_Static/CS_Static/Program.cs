using System;
using CS_Static;
class Program
{
    static void Main()
    {
        Date d1 = new Date(2022, 12, 24);
        Date d2 = new Date(2023, 1, 12);
        Date d3 = new Date(2023, 1, 12);

        Console.WriteLine(d1 + 24);
        Console.WriteLine(d2 - 10);
        Console.WriteLine(d2 - d1);
        Console.WriteLine(d3.Equals(d2));


        try
        {

            // Date d3 = new Date(2022, 2, 30);
            // Date d3 = new Date(2022, 2, -12);
            Date d4 = new Date(0, 2, 12);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception Caught!!!");
        }


        Console.ReadKey();
    }
}