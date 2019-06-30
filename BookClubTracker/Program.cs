using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BookClubTracker
{
    class Program
    {
        static void Main(string[] args)
        {

            var meetUps = GetListOfAllMeetUps();



            foreach(var meetUp in meetUps)
            {
                Console.WriteLine("Title: " + meetUp.Title);
                Console.WriteLine("Author: " + meetUp.Author);
                Console.WriteLine("Genre: " + meetUp.Genre);
                Console.WriteLine("Date: " + meetUp.MeetUpDate);
                Console.WriteLine("Location: " + meetUp.MeetUpLocation);
                Console.WriteLine();
            }



        }

        // Print all meetups to console
        public List<MeetUp> GetAllMeetUps()
        {
            List<MeetUp> allMeetUps = new List<MeetUp>();
            string meetUpDataFile = "";
            string jsonData = File.ReadAllText(meetUpDataFile);
            allMeetUps = JsonConvert.DeserializeObject<List<MeetUp>>(jsonData);
            return allMeetUps;
        }

        // Edit past meetups
        // start with editing a single meetup (even a single property inside the meetup)


        // Serialize (writng to) to a file
        // parse from one file into a new file maybe?


        // Add 'MeetUp'Class file for JSON file. Here I will store the object and manipulate it


        // Welcome to Bookclub tracker 2019! What would you like to do?
        // 1. View past events
        // 2. Edit past events
        // 3. Add new event 

        // Below could be a separate file manager class
        public static string ReadFile(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static List<MeetUp> DeserializeEvents(string fileName)
        {
            var meetUps = new List<MeetUp>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                meetUps = serializer.Deserialize<List<MeetUp>>(jsonReader);
            }
                
            return meetUps;
        }

        public static List<MeetUp> GetListOfAllMeetUps()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "books.json");
            var fileContents = ReadFile(fileName);
            var file = new FileInfo(fileName);
            var meetUps = DeserializeEvents(fileName);
            return meetUps;

            // TODO: Add try catch block that makes sure file exists
        }

        // end file manager class
    }
}
