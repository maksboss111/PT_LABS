
using System;

public class TextView : Widget, IResizable
{
    private int _maxTextLength;
    private string _text = "";

    public int MaxTextLength
    {
        get { return _maxTextLength; }
        set
        {
            if (value > 0) _maxTextLength = value;
            else throw new ArgumentException("Максимальная длина текста должна быть положительной");
        }
    }

    public string Text
    {
        get { return _text; }
        set
        {
            if (value.Length <= MaxTextLength)
                _text = value;
            else
                _text = value.Substring(0, MaxTextLength);
        }
    }

    public bool IsReadOnly { get; set; }

    public TextView(int width, int height, int maxTextLength, string label = "")
        : base(width, height, label)
    {
        MaxTextLength = maxTextLength;
    }

    public void Resize(int width, int height)
    {
        Width = width;
        Height = height;
        Console.WriteLine($"Текстовое поле изменено до размера {width}x{height}");
    }

    public void SetText(string text)
    {
        if (!IsReadOnly)
            Text = text;
        else
            Console.WriteLine($"Текстовое поле '{Label}' доступно только для чтения");
    }

    public override string ToString()
    {
        return $"Текстовое поле: {Label}, Размер: {Width}x{Height}, Макс. длина: {MaxTextLength}, Текст: '{Text}'";
    }
}