/* база данных библиотеки, в которой описания книг будет с использованием структуры 
и включать структура будет следующие поля: ФИО автора, название, год издания, наименование издательства. 
Для каждой книги имеется формуляр, в котором отображаются движение книга (дата выдачи, дата сдачи) 
необходимо написать программу которая позволит заполнять базу данных и делать выборку книг, 
которые не были на руках и книг, которые не сданы в библиотеку */
using System;
struct Book
{
    public string Author;
    public string NameBook;
    public int YearPublication;
    public string NamePublish;
}
struct Form
{
    public string NameBook;
    public DateTime Issue;
    public DateTime? Return;
}
class Library
{
    List<Book> books = new List<Book>();
    List<Form> forms = new List<Form>();
    public void AddBook(Book book)
    {
        books.Add(book);
    }
    public void PrintBook(Book books)
    {
        Console.WriteLine($"\nАвтор книги: {books.Author}");
        Console.WriteLine($"Название книги: {books.NameBook}");
        Console.WriteLine($"Год выпуска: {books.YearPublication}");
        Console.WriteLine($"Издательство: {books.NamePublish}");
    }
    public void PrintAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("Библиотека пуста.");
        }
        else
        {
            Console.WriteLine("Список всех книг: ");
            foreach (var book in books)
            {
                PrintBook(book);
            }
        }
    }
    public void IssueBook(string nameBook, DateTime issue)
    {
        bool exist = false;
        foreach (var book in books)
        {
            if (book.NameBook == nameBook)
            {
                exist = true;
                break;
            }
        }
        if (!exist)
        {
            Console.WriteLine($"Книга '{nameBook}' не найдена");
            return;
        }
        forms.Add(new Form { NameBook = nameBook, Issue = issue, Return = null });
        Console.WriteLine($"Книга '{nameBook}' выдана");
    }
    public void ReturnBook(string nameBook, DateTime return_)
    {
        bool found = false;
        for (int i = 0; i < forms.Count; i++)
        {
            if (forms[i].NameBook == nameBook && forms[i].Return == null)
            {
                var newForm = forms[i];
                newForm.Return = return_;
                forms[i] = newForm;
                Console.WriteLine($"Книга '{nameBook}' вернулась в библиотеку.");
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine($"Книга '{nameBook}' не найдена.");
        }
    }
    public void NeverIssue()
    {
        Console.WriteLine("\nСписок книг, которые никогда не выдавались: ");
        bool found = false;
        for (int i = 0; i < books.Count; i++)
        {
            bool issued = false;
            foreach (var form in forms)
            {
                if (form.NameBook == books[i].NameBook)
                {
                    issued = true;
                    break;
                }
            }
            if (!issued)
            {
                PrintBook(books[i]);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Все книги были когда-то выданы");
        }
    }
    public void BookIsNotLibrary()
    {
        bool found = false;
        Console.WriteLine("\nСписок выданных книг: ");
        for (int i = 0; i < books.Count; i++)
        {
            foreach (var form in forms)
            {
                if (form.Return == null)
                {
                    if (form.NameBook == books[i].NameBook)
                    {
                        PrintBook(books[i]);
                        found = true;
                    }
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Выданых книг нету");
        }
    }
}

class Program
{
    static void AddNewBook(Library books)
    {
        Book book = new Book();
        Console.WriteLine("\nВведите автора книги: ");
        book.Author = Console.ReadLine();
        Console.WriteLine("Введите название книги: ");
        book.NameBook = Console.ReadLine();
        Console.WriteLine("Введите год выпуска книги: ");
        book.YearPublication = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите наименование издательства книги: ");
        book.NamePublish = Console.ReadLine();
        books.AddBook(book);
    }
    static void Issue(Library books)
    {
        Console.WriteLine("\nВведите название книги которую хотите выдать: ");
        string nameBook = Console.ReadLine();
        Console.WriteLine("Введите дату выдачи книги: ");
        DateTime issue = DateTime.Parse(Console.ReadLine());
        books.IssueBook(nameBook, issue);
    }
    static void Return(Library books)
    {
        Console.WriteLine("\nВведите название кники, которую хотите вернуть: ");
        string bookName = Console.ReadLine();
        Console.WriteLine("Введите дату сдачи книги: ");
        DateTime return_ = DateTime.Parse(Console.ReadLine());
        books.ReturnBook(bookName, return_);
    }
    static void Main()
    {
        Library library = new Library();
        bool a = true;
        while (a)
        {
            Console.WriteLine("\n1. Добавить новую книгу");
            Console.WriteLine("2. Выдать книгу читателю");
            Console.WriteLine("3. Вернуть книгу в библиотеку");
            Console.WriteLine("4. Показать все книги");
            Console.WriteLine("5. Показать книги, которые никогда не выдавались");
            Console.WriteLine("6. Показать книги, которые сейчас на руках");
            Console.WriteLine("7. Выйти из программы");
            Console.Write("\nВыберите действие: ");

            int vibor = int.Parse(Console.ReadLine());
            switch (vibor)
            {
                case 1:
                    AddNewBook(library);
                    break;
                case 2:
                    Issue(library);
                    break;
                case 3:
                    Return(library);
                    break;
                case 4:
                    library.PrintAllBooks();
                    break;
                case 5:
                    library.NeverIssue();
                    break;
                case 6:
                    library.BookIsNotLibrary();
                    break;
                case 7:
                    a = false;
                    break;
                default:
                    Console.WriteLine("\nНеверный выбор. Введите число от 1 до 7.");
                    break;
            }
        }
    }
}
