/* ���� ������ ����������, � ������� �������� ���� ����� � �������������� ��������� 
� �������� ��������� ����� ��������� ����: ��� ������, ��������, ��� �������, ������������ ������������. 
��� ������ ����� ������� ��������, � ������� ������������ �������� ����� (���� ������, ���� �����) 
���������� �������� ��������� ������� �������� ��������� ���� ������ � ������ ������� ����, 
������� �� ���� �� ����� � ����, ������� �� ����� � ���������� */
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
        Console.WriteLine($"\n����� �����: {books.Author}");
        Console.WriteLine($"�������� �����: {books.NameBook}");
        Console.WriteLine($"��� �������: {books.YearPublication}");
        Console.WriteLine($"������������: {books.NamePublish}");
    }
    public void PrintAllBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("���������� �����.");
        }
        else
        {
            Console.WriteLine("������ ���� ����: ");
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
            Console.WriteLine($"����� '{nameBook}' �� �������");
            return;
        }
        forms.Add(new Form { NameBook = nameBook, Issue = issue, Return = null });
        Console.WriteLine($"����� '{nameBook}' ������");
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
                Console.WriteLine($"����� '{nameBook}' ��������� � ����������.");
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine($"����� '{nameBook}' �� �������.");
        }
    }
    public void NeverIssue()
    {
        Console.WriteLine("\n������ ����, ������� ������� �� ����������: ");
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
            Console.WriteLine("��� ����� ���� �����-�� ������");
        }
    }
    public void BookIsNotLibrary()
    {
        bool found = false;
        Console.WriteLine("\n������ �������� ����: ");
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
            Console.WriteLine("������� ���� ����");
        }
    }
}

class Program
{
    static void AddNewBook(Library books)
    {
        Book book = new Book();
        Console.WriteLine("\n������� ������ �����: ");
        book.Author = Console.ReadLine();
        Console.WriteLine("������� �������� �����: ");
        book.NameBook = Console.ReadLine();
        Console.WriteLine("������� ��� ������� �����: ");
        book.YearPublication = int.Parse(Console.ReadLine());
        Console.WriteLine("������� ������������ ������������ �����: ");
        book.NamePublish = Console.ReadLine();
        books.AddBook(book);
    }
    static void Issue(Library books)
    {
        Console.WriteLine("\n������� �������� ����� ������� ������ ������: ");
        string nameBook = Console.ReadLine();
        Console.WriteLine("������� ���� ������ �����: ");
        DateTime issue = DateTime.Parse(Console.ReadLine());
        books.IssueBook(nameBook, issue);
    }
    static void Return(Library books)
    {
        Console.WriteLine("\n������� �������� �����, ������� ������ �������: ");
        string bookName = Console.ReadLine();
        Console.WriteLine("������� ���� ����� �����: ");
        DateTime return_ = DateTime.Parse(Console.ReadLine());
        books.ReturnBook(bookName, return_);
    }
    static void Main()
    {
        Library library = new Library();
        bool a = true;
        while (a)
        {
            Console.WriteLine("\n1. �������� ����� �����");
            Console.WriteLine("2. ������ ����� ��������");
            Console.WriteLine("3. ������� ����� � ����������");
            Console.WriteLine("4. �������� ��� �����");
            Console.WriteLine("5. �������� �����, ������� ������� �� ����������");
            Console.WriteLine("6. �������� �����, ������� ������ �� �����");
            Console.WriteLine("7. ����� �� ���������");
            Console.Write("\n�������� ��������: ");

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
                    Console.WriteLine("\n�������� �����. ������� ����� �� 1 �� 7.");
                    break;
            }
        }
    }
}
