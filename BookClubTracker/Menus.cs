using System;
using System.Collections.Generic;
using System.Text;

namespace BookClubTracker
{
    class Menus
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Welcome to Book Club Tracker 2019! What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. View past events");
            Console.WriteLine("2. Add new event ");
            Console.WriteLine("3. Edit an event");
            Console.WriteLine("4. Delete an event");
            Console.WriteLine("5. Exit");
            Console.WriteLine();
            Console.Write("Selection: ");
      
        }

        public static void EditMenu(MeetUp meetUpToEdit)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Please select the field you wish to edit");
            Console.WriteLine();
            Console.WriteLine($"1. Title: {meetUpToEdit.Title}");
            Console.WriteLine($"2. Author: {meetUpToEdit.Author} ");
            Console.WriteLine($"3. Genre: {meetUpToEdit.Genre}");
            Console.WriteLine($"4. Date: {meetUpToEdit.MeetUpDate}");
            Console.WriteLine($"5. Location: {meetUpToEdit.MeetUpLocation}");
            Console.WriteLine("6. Save & Exit");
            Console.WriteLine();
            Console.Write("Selection: ");
        }
    }
}
