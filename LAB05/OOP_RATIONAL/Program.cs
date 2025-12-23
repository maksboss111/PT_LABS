using System;
using OOP_RATIONAL;

// Используем инициализатор для задания значений полям после создания объекта
Rational r1 = new Rational(4, 8);
Rational r2 = new Rational(2, -5);
Rational r3 = new Rational(-3, -4);

Console.WriteLine(r1);
Console.WriteLine(r2);
Console.WriteLine(r3);

Rational r4 = r1 + r2 * r3;
Console.WriteLine(r4);

Rational r5 = new Rational(0, 5);
try
{
    // Попытка деления на r5, должна вызвать ошибку
    Rational r6 = r1 / r5;
    Console.WriteLine(r6);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Ошибка: {ex.Message}");
}

Rational r7 = new Rational(3, 5);
Rational r8 = new Rational(5, 7);

Console.WriteLine(r7 < r8);


Rational r9 = new Rational(1, 5);
Rational r10 = new Rational(1, 7);

Console.WriteLine(r9 = r10);