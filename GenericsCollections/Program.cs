// See https://aka.ms/new-console-template for more information

namespace GenericsCollections;

// class representing a book with properties for title, author, and publication year.
public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int PublicationYear { get; set; }
}

// class representing a library catalog.
public class LibraryCatalog
{
    private List<Book> books = new List<Book>();

    // method to add a book to the catalog.
    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Buku '{book.Title}' berhasil ditambahkan");
    }

    // method to remove a book from the catalog by title
    public void RemoveBook(string title)
    {
        Book bookToRemove = FindBook(title);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"Buku '{title}' berhasil dihapus");
        }
        else
        {
            ErrorHandler.ShowError($"Buku '{title}' tidak ditemukan");
        }
    }

    // method to find a book by title.
    public Book FindBook(string title)
    {
        Book findBook = books.Find(book => book.Title == title);
        if (findBook != null)
        {
            Console.WriteLine($"Buku '{title}' ditemukan");
            return findBook;
        }
        else
        {
            ErrorHandler.ShowError($"Buku '{title}' tidak ditemukan");
            return null;
        }
    }

    // method to list the books in the catalog.
    public void ListBooks()
    {
        if (books.Count == 0)
        {
            ErrorHandler.ShowError("Belum ada buku yang ditambahkan");
        }
        else
        {
            Console.WriteLine("Daftar buku:");
            foreach (var book in books)
            {
                Console.WriteLine($"Judul: {book.Title}, Penulis: {book.Author}, Tahun Terbit: {book.PublicationYear}");
            }
        }
    }

    // nested class to handle error messages.
    public class ErrorHandler
    {
        public static void ShowError(string message)
        {
            Console.WriteLine($"Error: {message}");
        }
    }
}

public class LibraryApp
{
    public static void Main(string[] args)
    {
        LibraryCatalog catalog = new LibraryCatalog();

        while (true)
        {
            Console.WriteLine("Selamat datang di Perpustakaan");
            Console.WriteLine("Silakan pilih menu yang tersedia");
            Console.WriteLine("1. Tambah buku");
            Console.WriteLine("2. Hapus buku");
            Console.WriteLine("3. Cari buku");
            Console.WriteLine("4. Lihat daftar buku");
            Console.WriteLine("5. Keluar");
            Console.WriteLine("Pilihan: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    // case 1: adding a new book to the catalog.
                    case 1:
                        Book newBook = new Book();
                        Console.WriteLine("Judul: ");
                        newBook.Title = Console.ReadLine();
                        Console.WriteLine("Penulis: ");
                        newBook.Author = Console.ReadLine();
                        Console.WriteLine("Tahun Terbit: ");
                        newBook.PublicationYear = int.Parse(Console.ReadLine());
                        catalog.AddBook(newBook);
                        break;

                    // case 2: removing a book based on title.
                    case 2:
                        Console.WriteLine("Judul: ");
                        string title = Console.ReadLine();
                        catalog.RemoveBook(title);
                        break;

                    // case 3: finding a book by title.
                    case 3:
                        Console.WriteLine("Judul: ");
                        string searchTitle = Console.ReadLine();
                        Book findbook = catalog.FindBook(searchTitle);
                        if (findbook != null)
                        {
                            Console.WriteLine($"Buku ditemukan: Judul: {findbook.Title}, Penulis: {findbook.Author}, Tahun Publikasi: {findbook.PublicationYear}");
                        }
                        else
                        {
                            Console.WriteLine($"Buku '{searchTitle}' tidak ditemukan");
                        }
                        break;

                    // case 4: listing the books in the catalog.
                    case 4:
                        catalog.ListBooks();
                        break;

                    // case 5: exiting the application.
                    case 5:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Pilihan tidak tersedia");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Pilihan harus berupa angka");
            }
        }
    }
}