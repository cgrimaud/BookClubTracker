using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace BookClubTracker
{
    class UserOptions
    {
        public static void Run(List<MeetUp> meetUps)
        {

            int userInput = 0;
            do
            {
                Menus.MainMenu();
                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        DisplayAllMeetUps();
                        break;
                    case 2:
                        AddNewMeetUpToList(meetUps);
                        break;
                    case 3:
                        Console.WriteLine("Add Edit Method");
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 4:
                        DeleteMeetUp(meetUps);
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case 5:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(" Error: Invalid Choice");
                        System.Threading.Thread.Sleep(1000);
                        break;

                }
            } while (userInput != 5);
        }

        public static void DisplayAllMeetUps()
        {
            var meetUps = JsonFileManager.GetListOfAllMeetUps();
            foreach (var meetUp in meetUps)
            {
                Console.WriteLine("ID: " + meetUp.Id);
                Console.WriteLine("Title: " + meetUp.Title);
                Console.WriteLine("Author: " + meetUp.Author);
                Console.WriteLine("Genre: " + meetUp.Genre);
                Console.WriteLine("Date: " + meetUp.MeetUpDate);
                Console.WriteLine("Location: " + meetUp.MeetUpLocation);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(" Press [enter] to return to the menu.");
            Console.ReadLine();
        }

        public static List<MeetUp> AddNewMeetUpToList(List<MeetUp> meetUps)
        {
            var meetUp = new MeetUp();

            // TODO: write method to add id automatically
            Console.Write("ID: ");
            meetUp.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Book Title: ");
            meetUp.Title = Console.ReadLine();

            Console.Write("Book Author: ");
            meetUp.Author = Console.ReadLine();

            Console.Write("Book Genre: ");
            meetUp.Genre = Console.ReadLine();

            Console.Write("Date of Meet Up: ");
            meetUp.MeetUpDate = Console.ReadLine();

            Console.Write("Location of Meet Up: ");
            meetUp.MeetUpLocation = Console.ReadLine();

            meetUps.Add(meetUp);

            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "books.json");
            JsonFileManager.SerializeMeetUpsToFile(meetUps, fileName);

            return meetUps;
        }

        public static List<MeetUp> DeleteMeetUp(List<MeetUp> meetUps)
        {
           

            Console.Write("Enter ID of meet up you want to delete: ");
            int.TryParse(Console.ReadLine(), out var meetUpId);

            var meetUpToDelete = meetUps.SingleOrDefault(m => m.Id == meetUpId);

            if(meetUpToDelete != null)
            {
                meetUps.Remove(meetUpToDelete);
            }
            else
            {
                Console.Write($"Could not find a Meet Up with ID: {meetUpId}.");
            }

            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "books.json");
            JsonFileManager.SerializeMeetUpsToFile(meetUps, fileName);

            return meetUps;
        }

    }
}

