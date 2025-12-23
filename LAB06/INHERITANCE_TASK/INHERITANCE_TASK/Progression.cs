using System;

public abstract class Progression
{
    public double FirstElement { get; protected set; }
    public double CommonDifference { get; protected set; }
    public string ProgressionType { get; protected set; }

    protected Progression(double firstElement, double commonDifference, string progressionType)
    {
        FirstElement = firstElement;
        CommonDifference = commonDifference;
        ProgressionType = progressionType;
    }

    public abstract double GetElement(int n);
    public abstract double GetSumOfFirstElements(int n);
    public abstract double GetSumOfElementsInInterval(int a, int b);

    public virtual void PrintFirstElements(int n)
    {
        Console.Write($"{ProgressionType} прогрессия (первые {n} элементов): ");
        for (int i = 1; i <= n; i++)
        {
            Console.Write($"{GetElement(i)} ");
        }
        Console.WriteLine();
    }
}



