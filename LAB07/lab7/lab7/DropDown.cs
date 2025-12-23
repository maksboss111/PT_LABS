
using System.Collections.Generic;
using System;

public class DropDown : Widget, IClickable
{
    private List<string> _options = new List<string>();
    private int _selectedIndex = -1;

    public List<string> Options
    {
        get { return new List<string>(_options); }
        set { _options = value ?? new List<string>(); }
    }

    public int SelectedIndex
    {
        get { return _selectedIndex; }
        set
        {
            if (value >= -1 && value < _options.Count)
                _selectedIndex = value;
        }
    }

    public string SelectedOption
    {
        get
        {
            if (_selectedIndex >= 0 && _selectedIndex < _options.Count)
                return _options[_selectedIndex];
            return "";
        }
    }

    public DropDown(int width, int height, List<string> options, string label = "")
        : base(width, height, label)
    {
        Options = options;
        if (options.Count > 0)
            SelectedIndex = 0;
    }

    public void Click()
    {
        Console.WriteLine($"Выпадающий список '{Label}' открыт, доступно {Options.Count} опций");
    }

    public void AddOption(string option)
    {
        _options.Add(option);
    }

    public void RemoveOption(string option)
    {
        _options.Remove(option);
        if (_selectedIndex >= _options.Count)
            _selectedIndex = _options.Count - 1;
    }

    public override string ToString()
    {
        return $"Выпадающий список: {Label}, Размер: {Width}x{Height}, Выбрано: '{SelectedOption}', Опций: {Options.Count}";
    }
}