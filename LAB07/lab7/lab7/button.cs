
using System;

public class Button : Widget, IClickable, IResizable
{
    public bool IsEnabled { get; set; } = true;
    public string ButtonStyle { get; set; } = "По умолчанию";

    public Button(int width, int height, string label = "")
        : base(width, height, label)
    {
    }

    public void Click()
    {
        if (IsEnabled)
        {
            Console.WriteLine($"Кнопка '{Label}' нажата!");
        }
        else
        {
            Console.WriteLine($"Кнопка '{Label}' отключена и не может быть нажата");
        }
    }

    public void Resize(int width, int height)
    {
        Width = width;
        Height = height;
        Console.WriteLine($"Кнопка изменена до размера {width}x{height}");
    }

    public override string ToString()
    {
        return $"Кнопка: {Label}, Размер: {Width}x{Height}, Включена: {IsEnabled}, Стиль: {ButtonStyle}";
    }
}