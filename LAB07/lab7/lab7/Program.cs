
using System.Collections.Generic;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Тестирование иерархии виджетов GUI ===\n");

        // Создаем сетку 2x2
        Grid window = new Grid(2, 2, "Главное окно");
        Console.WriteLine(window.ToString());

        // Создаем виджеты
        Button btnOk = new Button(100, 40, "OK");
        Button btnCancel = new Button(100, 40, "Отмена");

        TextView textView = new TextView(150, 60, 100, "Имя пользователя");
        textView.SetText("ИванИванов");

        List<string> colors = new List<string> { "Красный", "Зеленый", "Синий", "Желтый" };
        DropDown colorDropdown = new DropDown(120, 30, colors, "Выбор цвета");

        // Добавляем виджеты в сетку
        Console.WriteLine("\n=== Добавление виджетов в сетку ===");
        window.AddToGrid(btnOk, 0, 0);
        window.AddToGrid(btnCancel, 0, 1);
        window.AddToGrid(textView, 1, 0);

        // Пытаемся добавить в занятую позицию
        try
        {
            window.AddToGrid(colorDropdown, 1, 1);
            Console.WriteLine("Успешно добавлено");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        // Отображаем сетку
        window.DisplayGrid();

        // Тестируем видимость
        window.CheckVisibility();

        // Тестируем методы виджетов
        Console.WriteLine("\n=== Тестирование методов виджетов ===");
        btnOk.Click();
        btnCancel.IsEnabled = false;
        btnCancel.Click();

        colorDropdown.Click();
        Console.WriteLine($"Выбранный цвет: {colorDropdown.SelectedOption}");
        colorDropdown.SelectedIndex = 2;
        Console.WriteLine($"Новый выбранный цвет: {colorDropdown.SelectedOption}");

        // Тестируем текстовое поле
        textView.SetText("Новый текст для тестирования длинного ввода, который будет обрезан");
        Console.WriteLine($"Текст после установки: '{textView.Text}'");
        textView.IsReadOnly = true;
        textView.SetText("Попытка изменить текст при режиме только чтение");

        // Тестируем изменение размера
        Console.WriteLine("\n=== Тестирование изменения размера ===");
        btnOk.Resize(120, 50);
        textView.Resize(160, 70);
        window.Resize(400, 300);

        // Тестируем удаление
        Console.WriteLine("\n=== Тестирование удаления ===");
        window.DeleteFromGrid(btnCancel);
        window.DisplayGrid();

        // Тестируем проверку на необходимость изменения размера
        Console.WriteLine($"Сетка требует изменения размера: {window.NeedsResize()}");

        // Добавляем еще один элемент в освободившееся место
        Console.WriteLine("\n=== Добавление нового виджета ===");
        window.AddToGrid(colorDropdown, 0, 1);
        window.DisplayGrid();

        // Снова проверяем необходимость изменения размера
        Console.WriteLine($"Сетка требует изменения размера: {window.NeedsResize()}");

        // Добавляем последний элемент чтобы заполнить сетку
        Console.WriteLine("\n=== Добавление последнего виджета ===");
        Button btnApply = new Button(100, 40, "Применить");
        window.AddToGrid(btnApply, 1, 1);
        window.DisplayGrid();
        Console.WriteLine($"Сетка полностью заполнена, требует изменения размера: {window.NeedsResize()}");

        // Выводим информацию о всех виджетах
        Console.WriteLine("\n=== Информация о виджетах ===");
        Console.WriteLine(btnOk.ToString());
        Console.WriteLine(btnApply.ToString());
        Console.WriteLine(textView.ToString());
        Console.WriteLine(colorDropdown.ToString());
        Console.WriteLine(window.ToString());

        // Тестируем работу с выпадающим списком
        Console.WriteLine("\n=== Работа с выпадающим списком ===");
        colorDropdown.AddOption("Фиолетовый");
        colorDropdown.AddOption("Оранжевый");
        Console.WriteLine($"Всего опций в списке: {colorDropdown.Options.Count}");
        colorDropdown.SelectedIndex = colorDropdown.Options.Count - 1;
        Console.WriteLine($"Последняя выбранная опция: {colorDropdown.SelectedOption}");

        // Удаляем опцию
        colorDropdown.RemoveOption("Зеленый");
        Console.WriteLine($"Осталось опций после удаления: {colorDropdown.Options.Count}");

        Console.WriteLine("\n=== Тестирование завершено ===");
        Console.ReadKey();
    }
}