using System;
using System.Collections.Generic;

namespace Bookmarks
{
    public class BookMarkManager
    {
        private List<BookMark> myBookMarks = new List<BookMark>();

        public void Menu()
        {
            RetriveListOfBookMarksFromUser();
            Console.Clear();
            ShowBookMarks();
            SecondMenu();
        }

        private void SecondMenu()
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Go to the website");
            Console.WriteLine("2. Add a bookmark");
            Console.WriteLine("3. Ajust a bookmark");
            Console.WriteLine("4. Remove a bookmark");
            int userInput = int.Parse(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    GoToAWebSite();
                    ShowBookMarks();
                    SecondMenu();
                    break;

                case 2:
                    AddBookmark();
                    break;

                case 3:
                    AjustBookMark();
                    SecondMenu();
                    break;

                case 4:
                    RemoveBookMark();
                    SecondMenu();
                    break;

                default:
                    Console.WriteLine("Error");
                    SecondMenu();
                    break;
            }
        }

        private void AddBookmark()
        {
            myBookMarks.Add(RetriveBookmarkFromUser());
            Console.Clear();
            Console.WriteLine("Updated List:");
            ShowBookMarks();
            SecondMenu();
        }

        private void RemoveBookMark()
        {
            ShowBookMarks();
            Console.WriteLine("Which one to remove?");
            int userInput = int.Parse(Console.ReadLine());

            for (int i = 0; i < myBookMarks.Count; i++)
            {
                if (userInput == i + 1)
                {
                    myBookMarks.Remove(myBookMarks[i]);
                }
            }
            Console.Clear();
            Console.WriteLine("Updated List:");
            ShowBookMarks();
            SecondMenu();
        }

        private void AjustBookMark()
        {
            ShowBookMarks();
            Console.WriteLine("Which one to adjust?");
            int userInput = int.Parse(Console.ReadLine());
            foreach (BookMark bookMark in myBookMarks)
            {
                if (userInput == myBookMarks.IndexOf(bookMark) + 1)
                {
                    Console.WriteLine($"Name: {bookMark.Name} URL: {bookMark.URL} ");
                    Console.WriteLine("Enter new data:");
                    Console.WriteLine("Name: ");
                    bookMark.Name = Console.ReadLine();
                    Console.WriteLine("URL: ");
                    bookMark.URL = Console.ReadLine();
                }
            }
            Console.Clear();
            Console.WriteLine("Upadated List:");
            ShowBookMarks();
        }

        private void GoToAWebSite()
        {
            Console.WriteLine("Type a number:");
            int userInput = int.Parse(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    myBookMarks[0].OpenSite();
                    break;

                case 2:
                    myBookMarks[1].OpenSite();
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
            Console.Clear();
        }

        private List<BookMark> RetriveListOfBookMarksFromUser()
        {
            for (int i = 0; i < 2; i++)
            {
                myBookMarks.Add(RetriveBookmarkFromUser());
            }

            return myBookMarks;
        }

        private void ShowBookMarks()
        {
            Console.WriteLine("----Your Bookmarks-----");
            foreach (BookMark bookMark in myBookMarks)
            {
                Console.WriteLine($"{myBookMarks.IndexOf(bookMark) + 1} : {bookMark.Name}");
            }
        }

        private BookMark RetriveBookmarkFromUser()
        {
            Console.WriteLine("--Enter the name and the Url of your new bookmark--");
            BookMark bookMark = new BookMark();
            Console.Write("Name: ");
            bookMark.Name = Console.ReadLine();
            Console.Write("URL: ");
            bookMark.URL = Console.ReadLine();
            return bookMark;
        }
    }
}