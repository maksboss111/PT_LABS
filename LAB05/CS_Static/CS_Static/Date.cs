using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Static
{
    public class Date
    {
        private int _year;
        private int _month;
        private int _day;
        // Свойство для года с проверкой корректности
        public int Year
        {
            get { return _year; }
            set
            {
                if (value < 1)
                    throw new ArgumentException("Год не может быть меньше 1");
                _year = value;
                AdjustDayIfNeeded(); // Проверяем, чтобы день был корректным для нового года
            }
        }
        // Свойство для месяца с проверкой корректности
        public int Month
        {
            get { return _month; }
            set
            {
                if (value < 1 || value > 12)
                    throw new ArgumentException("Месяц должен быть от 1 до 12");
                _month = value;
                AdjustDayIfNeeded(); // Проверяем, чтобы день был корректным для нового месяца
            }
        }
        // Свойство для дня с проверкой корректности
        public int Day
        {
            get { return _day; }
            set
            {
                if (value < 1 || value > DaysInMonth(_year, _month))
                    throw new ArgumentException($"День должен быть от 1 до {DaysInMonth(_year, _month)}");
                _day = value;
            }
        }
        // Конструктор с параметрами
        public Date(int year, int month, int day)
        {
            // Используем свойства для установки значений, чтобы проверить корректность
            Year = year;
            Month = month;
            Day = day;
        }
        // Вспомогательный метод для получения количества дней в месяце
        private static int DaysInMonth(int year, int month)
        {
            if (month < 1 || month > 12)
                return 0;

            if (month == 2)
                return IsLeapYear(year) ? 29 : 28;

            int[] daysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return daysInMonth[month - 1];
        }

        // Вспомогательный метод для проверки високосного года
        private static bool IsLeapYear(int year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        // Метод для корректировки дня, если он недопустим для текущих года и месяца
        private void AdjustDayIfNeeded()
        {
            int maxDays = DaysInMonth(_year, _month);
            if (_day > maxDays)
                _day = maxDays;
        }
        // Оператор сложения даты и числа (дата через n дней)
        public static Date operator +(Date date, int days)
        {
            return AddDays(date, days);
        }
        // Оператор вычитания числа из даты (дата n дней назад)
        public static Date operator -(Date date, int days)
        {
            return AddDays(date, -days);
        }
        // Оператор вычитания двух дат (разница в днях)
        public static int operator -(Date date1, Date date2)
        {
            return DaysBetween(date1, date2);
        }
        // Вспомогательный метод для добавления дней к дате
       
        private static Date AddDays(Date date, int days)
        {
            if (date == null)
                throw new ArgumentNullException(nameof(date));

            DateTime dt = new DateTime(date.Year, date.Month, date.Day);
            dt = dt.AddDays(days);
            return new Date(dt.Year, dt.Month, dt.Day);
        }
        // Вспомогательный метод для вычисления разницы в днях между двумя датами
        private static int DaysBetween(Date date1, Date date2)
        {
            if (date1 == null || date2 == null)
                throw new ArgumentNullException(date1 == null ? nameof(date1) : nameof(date2));

            DateTime dt1 = new DateTime(date1.Year, date1.Month, date1.Day);
            DateTime dt2 = new DateTime(date2.Year, date2.Month, date2.Day);
            return (int)(dt1 - dt2).TotalDays;
        }
        // Переопределение метода ToString
        public override string ToString()
        {
            return $"{_year}/{_month:00}/{_day:00}";
        }

        // Переопределение метода Equals
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Date))
                return false;

            Date other = (Date)obj;
            return _year == other._year && _month == other._month && _day == other._day;
        }
        // Переопределение GetHashCode для согласованности с Equals
        public override int GetHashCode()
        {
            // Альтернативная реализация для старых версий .NET
            unchecked // Позволяет переполнение без исключения
            {
                int hash = 17;
                hash = hash * 23 + _year.GetHashCode();
                hash = hash * 23 + _month.GetHashCode();
                hash = hash * 23 + _day.GetHashCode();
                return hash;
            }
        }
    }
}
