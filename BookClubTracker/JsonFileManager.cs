using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace BookClubTracker
{
    class JsonFileManager
    {
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

        public static void SerializeMeetUpsToFile(List<MeetUp> meetUps, string fileName)
        {
            // I commmented out the below and added it to line 39 out of curiosity
            //var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(jsonWriter, meetUps);
            }

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
    }
}
