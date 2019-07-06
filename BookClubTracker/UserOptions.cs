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
                        EditMeetUp(meetUps);
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

            JsonFileManager.SaveToFile(meetUps);

            return meetUps;
        }

        public static List<MeetUp> DeleteMeetUp(List<MeetUp> meetUps)
        {
           
            // TODO: Provide truncated listed of options?
            Console.Write("Enter ID of meet up you want to delete: ");
            int.TryParse(Console.ReadLine(), out var meetUpId);

            var meetUpToDelete = meetUps.SingleOrDefault(m => m.Id == meetUpId);

            if(meetUpToDelete != null)
            {
                meetUps.Remove(meetUpToDelete);
                Console.WriteLine($"The Meet Up with ID {meetUpId} has been deleted.");
            }
            else
            {
                Console.Write($"Could not find a Meet Up with ID: {meetUpId}.");
            }

            JsonFileManager.SaveToFile(meetUps);

            return meetUps;
        }

        public static List<MeetUp> EditMeetUp(List<MeetUp> meetUps)
        {
            Console.Write("Enter ID of meet up you want to edit: ");
            int.TryParse(Console.ReadLine(), out var meetUp);

            var meetUpToEdit = meetUps.FirstOrDefault(m => m.Id == meetUp);

            int userInput = 0;
            do
            {
                Menus.EditMenu(meetUpToEdit);

               
                userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.Write("New Title: ");
                        meetUpToEdit.Title = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("New Author: ");
                        meetUpToEdit.Author = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("New Genre: ");
                        meetUpToEdit.Genre = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("New Date: ");
                        meetUpToEdit.MeetUpDate = Console.ReadLine();
                        break;
                    case 5:
                        Console.Write("New Location: ");
                        meetUpToEdit.MeetUpLocation = Console.ReadLine();
                        break;
                    case 6:
                        Console.WriteLine("This Meet Up has been updated!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine(" Error: Invalid Choice");
                        System.Threading.Thread.Sleep(1000);
                        break;

                }
            } while (userInput != 6);

            JsonFileManager.SaveToFile(meetUps);

            return meetUps;
        }


        // Edit option
        // User selects Meet Up by ID
        // That Meet Up appears on Console 
        //  Select the field you wish to edit:
            // 1. title: {current info listed here}
            // 2. Author: {current info listed here}
            // 3. Genre: {current info listed here}
            // 4. Meet up Date: {current info listed here}
            // 5. Meet up Location: {current info listed here}
            // 6. Save & Exit
       // user selects number and updates data
       // list appears again with updated info in the field
       // user can continue to edit fields
       // on 6, do the save and redisplay main menu


    }
}

