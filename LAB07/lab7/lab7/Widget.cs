using System;

public class Widget
{
    private int _width;
    private int _height;

    public int Width
    {
        get { return _width; }
        set
        {
            if (value > 0) _width = value;
            else throw new ArgumentException("Ширина должна быть положительным числом");
        }
    }

    public int Height
    {
        get { return _height; }
        set
        {
            if (value > 0) _height = value;
            else throw new ArgumentException("Высота должна быть положительным числом");
        }
    }

    public string Label { get; set; }

    public Widget(int width, int height, string label = "")
    {
        Width = width;
        Height = height;
        Label = label;
    }

    public override string ToString()
    {
        return $"Виджет: {Label}, Размер: {Width}x{Height}";
    }
}