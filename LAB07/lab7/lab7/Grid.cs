
using System;

public class Grid : Widget, IResizable
{
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    private Widget[,] elements;

    public Grid(int rows, int columns, string label = "Сетка")
        : base(columns * 100, rows * 50, label)
    {
        if (rows <= 0 || columns <= 0)
            throw new ArgumentException("Количество строк и столбцов должно быть положительным");

        Rows = rows;
        Columns = columns;
        elements = new Widget[rows, columns];
    }

    public void AddToGrid(Widget widget, int row, int column)
    {
        if (row < 0 || row >= Rows || column < 0 || column >= Columns)
            throw new ArgumentException("Неверный индекс строки или столбца");

        if (elements[row, column] != null)
            throw new InvalidOperationException($"Позиция ({row},{column}) уже занята");

        elements[row, column] = widget;
        Console.WriteLine($"Виджет '{widget.Label}' добавлен в позицию ({row},{column})");
    }

    public bool DeleteFromGrid(Widget widget)
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (elements[i, j] == widget)
                {
                    elements[i, j] = null;
                    Console.WriteLine($"Виджет '{widget.Label}' удален из позиции ({i},{j})");
                    return true;
                }
            }
        }
        return false;
    }

    public bool DeleteFromGrid(int row, int column)
    {
        if (row < 0 || row >= Rows || column < 0 || column >= Columns)
            return false;

        if (elements[row, column] != null)
        {
            Console.WriteLine($"Виджет '{elements[row, column].Label}' удален из позиции ({row},{column})");
            elements[row, column] = null;
            return true;
        }
        return false;
    }

    public void CheckVisibility()
    {
        Console.WriteLine($"\nПроверка видимости для {Label}:");
        int visibleCount = 0;

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (elements[i, j] != null)
                {
                    visibleCount++;
                    Console.WriteLine($"Позиция ({i},{j}): {elements[i, j].Label} - ВИДИМ");
                }
                else
                {
                    Console.WriteLine($"Позиция ({i},{j}): ПУСТО");
                }
            }
        }
        Console.WriteLine($"Всего видимых виджетов: {visibleCount}");
    }

    public bool NeedsResize()
    {
        // Проверяем, заполнена ли сетка полностью
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (elements[i, j] == null)
                    return false; // Есть свободное место
            }
        }
        return true; // Все ячейки заняты
    }

    public void Resize(int width, int height)
    {
        Width = width;
        Height = height;
        Console.WriteLine($"Сетка изменена до размера {width}x{height}");
    }

    public void DisplayGrid()
    {
        Console.WriteLine($"\n=== Сетка: {Label} ({Rows}x{Columns}) ===");
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (elements[i, j] != null)
                {
                    string typeName = elements[i, j].GetType().Name;
                    string shortName = typeName.Length >= 3 ? typeName.Substring(0, 3) : typeName;
                    Console.Write($"[{shortName}] ");
                }
                else
                    Console.Write("[   ] ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public override string ToString()
    {
        int widgetCount = 0;
        for (int i = 0; i < Rows; i++)
            for (int j = 0; j < Columns; j++)
                if (elements[i, j] != null)
                    widgetCount++;

        return $"Сетка: {Label}, Размер: {Rows}x{Columns}, Виджетов: {widgetCount}/{Rows * Columns}";
    }
}