using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INHERITANCE_TASK
{
        public class GeometricProgression : Progression
        {
            public GeometricProgression(double firstElement, double denominator)
                : base(firstElement, denominator, "Геометрическая") { }

            public override double GetElement(int n)
            {
                if (n <= 0) throw new ArgumentException("Номер элемента должен быть положительным");
                return FirstElement * Math.Pow(CommonDifference, n - 1);
            }

            public override double GetSumOfFirstElements(int n)
            {
                if (n <= 0) throw new ArgumentException("Количество элементов должно быть положительным");
                if (CommonDifference == 1) return FirstElement * n;
                return FirstElement * (Math.Pow(CommonDifference, n) - 1) / (CommonDifference - 1);
            }

            public override double GetSumOfElementsInInterval(int a, int b)
            {
                if (a > b) throw new ArgumentException("Начало интервала должно быть меньше или равно концу");
                if (a <= 0) throw new ArgumentException("Номера элементов должны быть положительными");
                return GetSumOfFirstElements(b) - GetSumOfFirstElements(a - 1);
            }
        }
    }

