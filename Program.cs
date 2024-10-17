using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static Dictionary<string, List<string>> library = new Dictionary<string, List<string>>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nБиблиотека:");
            Console.WriteLine("1. Добавить книгу");
            Console.WriteLine("2. Удалить книгу");
            Console.WriteLine("3. Отобразить книги автора");
            Console.WriteLine("4. Искать книгу по названию");
            Console.WriteLine("5. Отобразить все книги");
            Console.WriteLine("6. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    RemoveBook();
                    break;
                case "3":
                    DisplayBooksByAuthor();
                    break;
                case "4":
                    SearchBookByTitle();
                    break;
                case "5":
                    DisplayAllBooks();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Некорректный выбор, попробуйте еще раз.");
                    break;
            }
        }
    }

    static void AddBook()
    {
        Console.Write("Введите имя автора: ");
        string author = Console.ReadLine();

        Console.Write("Введите название книги: ");
        string bookTitle = Console.ReadLine();

        if (!library.ContainsKey(author))
        {
            library[author] = new List<string>();
        }

        library[author].Add(bookTitle);
        Console.WriteLine($"Книга \"{bookTitle}\" добавлена автору \"{author}\".");
    }

    static void RemoveBook()
    {
        Console.Write("Введите имя автора: ");
        string author = Console.ReadLine();

        if (library.ContainsKey(author))
        {
            Console.Write("Введите название книги для удаления: ");
            string bookTitle = Console.ReadLine();

            if (library[author].Remove(bookTitle))
            {
                Console.WriteLine($"Книга \"{bookTitle}\" удалена у автора \"{author}\".");
            }
            else
            {
                Console.WriteLine($"Книга \"{bookTitle}\" не найдена у автора \"{author}\".");
            }
        }
        else
        {
            Console.WriteLine($"Автор \"{author}\" не найден.");
        }
    }

    static void DisplayBooksByAuthor()
    {
        Console.Write("Введите имя автора: ");
        string author = Console.ReadLine();

        if (library.ContainsKey(author))
        {
            Console.WriteLine($"Книги автора \"{author}\":");
            foreach (var book in library[author])
            {
                Console.WriteLine($" - {book}");
            }
        }
        else
        {
            Console.WriteLine($"Автор \"{author}\" не найден.");
        }
    }

    static void SearchBookByTitle()
    {
        Console.Write("Введите название книги для поиска: ");
        string title = Console.ReadLine();
        bool found = false;

        foreach (var author in library.Keys)
        {
            if (library[author].Any(b => b.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Книга \"{title}\" найдена у автора \"{author}\".");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine($"Книга \"{title}\" не найдена среди авторов.");
        }
    }

    static void DisplayAllBooks()
    {
        Console.WriteLine("Все книги в библиотеке:");
        foreach (var author in library.Keys)
        {
            Console.WriteLine($"Автор: {author}");
            foreach (var book in library[author])
            {
                Console.WriteLine($" - {book}");
            }
        }
    }
}
