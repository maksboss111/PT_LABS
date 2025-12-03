using System;

namespace RangeApp
{
    class Program1
    {
        static void Main1(string[] args)
        {
            Range range = null;

            while (true)
            {
                Console.WriteLine("\n1 - Создать новый диапазон");
                Console.WriteLine("2 - Проверить точку");
                Console.WriteLine("3 - Изменить границы диапазона");
                Console.WriteLine("4 - Показать текущий диапазон");
                Console.WriteLine("5 - Выход");
                Console.Write("Выберите действие: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        try
                        {
                            Console.Write("Введите начало диапазона (A): ");
                            double a = double.Parse(Console.ReadLine());

                            Console.Write("Введите конец диапазона (B): ");
                            double b = double.Parse(Console.ReadLine());

                            range = new Range(a, b);
                            Console.WriteLine("Диапазон успешно создан!");
                            range.PrintRange();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка: Введено нечисловое значение!");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        break;

                    case "2":
                        if (range == null)
                        {
                            Console.WriteLine("Сначала создайте диапазон!");
                            break;
                        }

                        try
                        {
                            Console.Write("Введите точку для проверки: ");
                            double point = double.Parse(Console.ReadLine());

                            bool inside = range.IsInside(point);
                            Console.WriteLine($"Точка {point} {(inside ? "внутри" : "вне")} диапазона");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка: Введено нечисловое значение!");
                        }
                        break;

                    case "3":
                        if (range == null)
                        {
                            Console.WriteLine("Сначала создайте диапазон!");
                            break;
                        }

                        try
                        {
                            Console.Write("Введите новое начало (A): ");
                            double newA = double.Parse(Console.ReadLine());

                            Console.Write("Введите новый конец (B): ");
                            double newB = double.Parse(Console.ReadLine());

                            range.A = newA;
                            range.B = newB;

                            Console.WriteLine("Границы успешно изменены!");
                            range.PrintRange();
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Ошибка: Введено нечисловое значение!");
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine($"Ошибка: {ex.Message}");
                        }
                        break;

                    case "4":
                        if (range == null)
                            Console.WriteLine("Диапазон не создан!");
                        else
                            range.PrintRange();
                        break;

                    case "5":
                        Console.WriteLine("До свидания!");
                        return;

                    default:
                        Console.WriteLine("Неизвестная команда!");
                        break;
                }
            }
        }
    }
}