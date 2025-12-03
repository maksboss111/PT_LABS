using System;

namespace RangeApp
{
    public class Range
    {
        private double a;
        private double b;

        public double A
        {
            get { return a; }
            set
            {
                a = value;
                if (value > b)
                    throw new ArgumentException("Значение A не может превышать B");
            }
        }

        public double B
        {
            get { return b; }
            set
            {
                if (value < a)
                    throw new ArgumentException("Значение B не может быть меньше A");
                b = value;
            }
        }

        public Range(double a, double b)
        {
            if (a > b)
                throw new ArgumentException("Начало интервала не может быть больше конца");
            this.a = a;
            this.b = b;
        }

        public bool IsInside(double x)
        {
            return x >= a && x < b;
        }

        public void PrintRange()
        {
            Console.WriteLine($"Интервал: [{a}, {b})");
        }
    }

    class Program
    {
        static void Main(string[] args)
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
                    case "1": // Создание нового диапазона
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

                    case "2": // Проверка точки
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

                    case "3": // Изменение границ
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

                    case "4": // Показать диапазон
                        if (range == null)
                            Console.WriteLine("Диапазон не создан!");
                        else
                            range.PrintRange();
                        break;

                    case "5": // Выход
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