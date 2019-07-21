using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace BookClubTracker
{
    class JsonFileManager
    {

        // reads a JSON file and deserializes is into a list object of type MeetUp
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

        // takes the MeetUps list object and turns it into a JSON file
        public static void SerializeMeetUpsToFile(List<MeetUp> meetUps, string fileName)
        {
            
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(jsonWriter, meetUps);
            }

        }

        public static void SaveToFile(List<MeetUp> meetUps)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "books.json");
            SerializeMeetUpsToFile(meetUps, fileName);
        }

        // Determines directory where JSON file is supposed to be, calls DeserializeEvents method to return a list of MeetUp objects
        public static List<MeetUp> GetListOfAllMeetUps()
        {

            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                DirectoryInfo directory = new DirectoryInfo(currentDirectory);
                // gets file name from current directory
                var fileName = Path.Combine(directory.FullName, "books.json");
                if (File.Exists(fileName))
                {
                    // passes file name into DeserializeEvents method
                    var meetUps = DeserializeEvents(fileName);

                    return meetUps;
                }
                else
                {
                    throw new Exception($"Error: unable to find file: {fileName}");
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("Error",
                    $"An error occurred while trying to get meetUps.");
                throw;
            }
        }
    }
}
