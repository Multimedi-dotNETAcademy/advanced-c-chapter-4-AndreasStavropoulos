using System;

namespace Bookmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BookMarkManager bookMarkManager = new BookMarkManager();
            bookMarkManager.Menu();

            Console.ReadLine();
        }
    }
}
