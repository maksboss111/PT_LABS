using System;
using INHERITANCE_TASK;

class Program
{
    static void Main()
    {
        Random random = new Random();
        Progression[] progressions = new Progression[10];

        for (int i = 0; i < 10; i++)
        {
            if (random.Next(0, 2) == 0)
            {
                progressions[i] = new ArithmeticProgression(
                    firstElement: random.Next(1, 10),
                    difference: random.Next(1, 5));
            }
            else
            {
                progressions[i] = new GeometricProgression(
                    firstElement: random.Next(1, 5),
                    denominator: random.NextDouble() * 2 + 0.5);
            }
        }

        Console.WriteLine("Созданные прогрессии:");
        for (int i = 0; i < progressions.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {progressions[i].ProgressionType} прогрессия: " +
                $"a1 = {progressions[i].FirstElement}, " +
                $"{(progressions[i] is ArithmeticProgression ? "разность" : "знаменатель")} = {progressions[i].CommonDifference:F2}");
        }

        Console.WriteLine("\n" + new string('-', 50) + "\n");

        double sumOfTenthElements = 0;
        Console.WriteLine("10-е элементы прогрессий:");
        for (int i = 0; i < progressions.Length; i++)
        {
            double tenthElement = progressions[i].GetElement(10);
            Console.WriteLine($"{i + 1}. {progressions[i].ProgressionType}: {tenthElement:F2}");
            sumOfTenthElements += tenthElement;
        }
        Console.WriteLine($"\nСумма 10-х элементов всех прогрессий: {sumOfTenthElements:F2}");

        Console.WriteLine("\n" + new string('-', 50) + "\n");

        int maxSumIndex = 0;
        double maxSum = 0;
        Console.WriteLine("Суммы первых 5 элементов прогрессий:");
        for (int i = 0; i < progressions.Length; i++)
        {
            double sumOfFive = progressions[i].GetSumOfFirstElements(5);
            Console.WriteLine($"{i + 1}. {progressions[i].ProgressionType}: {sumOfFive:F2}");
            if (sumOfFive > maxSum)
            {
                maxSum = sumOfFive;
                maxSumIndex = i;
            }
        }

        Console.WriteLine($"\nПрогрессия с максимальной суммой первых 5 элементов:");
        Console.WriteLine($"Индекс: {maxSumIndex + 1}");
        Console.WriteLine($"Тип: {progressions[maxSumIndex].ProgressionType}");
        Console.WriteLine($"Первый элемент: {progressions[maxSumIndex].FirstElement}");
        Console.WriteLine($"{(progressions[maxSumIndex] is ArithmeticProgression ? "Разность" : "Знаменатель")}: {progressions[maxSumIndex].CommonDifference:F2}");
        Console.WriteLine($"Сумма первых 5 элементов: {maxSum:F2}");

        Console.WriteLine("\n" + new string('-', 50) + "\n");

        Console.WriteLine("Вывод первых 5 элементов каждой прогрессии:");
        for (int i = 0; i < progressions.Length; i++)
        {
            progressions[i].PrintFirstElements(5);
        }
    }
}