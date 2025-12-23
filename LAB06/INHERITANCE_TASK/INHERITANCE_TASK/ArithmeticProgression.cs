using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INHERITANCE_TASK
{
    internal class ArithmeticProgression : Progression
    
        {
            public ArithmeticProgression(double firstElement, double difference)
                : base(firstElement, difference, "Арифметическая") { }

            public override double GetElement(int n)
            {
                if (n <= 0) throw new ArgumentException("Номер элемента должен быть положительным");
                return FirstElement + (n - 1) * CommonDifference;
            }

            public override double GetSumOfFirstElements(int n)
            {
                if (n <= 0) throw new ArgumentException("Количество элементов должно быть положительным");
                return n * (2 * FirstElement + (n - 1) * CommonDifference) / 2;
            }

            public override double GetSumOfElementsInInterval(int a, int b)
            {
                if (a > b) throw new ArgumentException("Начало интервала должно быть меньше или равно концу");
                if (a <= 0) throw new ArgumentException("Номера элементов должны быть положительными");
                return GetSumOfFirstElements(b) - GetSumOfFirstElements(a - 1);
            }
        }

    }

