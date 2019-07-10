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
                            break;
                        case 4:
                            DeleteMeetUp(meetUps);
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
            Console.Clear();
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

            meetUp.Id = GetNextId(meetUps);

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
            Console.WriteLine();
            Console.WriteLine("Your Meet Up has been added!");
            System.Threading.Thread.Sleep(1500);

            JsonFileManager.SaveToFile(meetUps);

            return meetUps;
        }

        public static List<MeetUp> DeleteMeetUp(List<MeetUp> meetUps)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Delete a Meet Up");
            Console.WriteLine();
            foreach (var meetUp in meetUps)
            {
                Console.WriteLine(meetUp.Id + ". " + meetUp.Title);
            }
            Console.WriteLine();
            Console.Write("Enter ID of meet up you want to delete or select 0 to exit: ");
            int.TryParse(Console.ReadLine(), out var meetUpId);

            var meetUpToDelete = meetUps.SingleOrDefault(m => m.Id == meetUpId);

            if (meetUpToDelete != null)
            {
                meetUps.Remove(meetUpToDelete);
                Console.WriteLine($"The Meet Up with ID {meetUpId} has been deleted.");
                System.Threading.Thread.Sleep(1500);
                JsonFileManager.SaveToFile(meetUps);
            }
            else
            {
                Console.Write($"Could not find a Meet Up with ID: {meetUpId}.");
                System.Threading.Thread.Sleep(1000);
            }

            

            return meetUps;
        }

        public static List<MeetUp> EditMeetUp(List<MeetUp> meetUps)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Edit a Meet Up");
            Console.WriteLine();
            foreach (var M in meetUps)
            {
                Console.WriteLine(M.Id + ". " + M.Title);
            }
            Console.WriteLine();
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

        private static int GetNextId(List<MeetUp> meetUps)
        {
            int returnValue = 1;

            
                if (meetUps.Any())
                {
                    //get the meet up with the highest ID
                    var meetUp = meetUps.OrderByDescending(m => m.Id).FirstOrDefault();

                    // add 1 to the highest meet up id that already exists
                    int id = meetUp.Id;
                    id++;
                    returnValue = id;
                }
          

            return returnValue;
        }


    }
}

