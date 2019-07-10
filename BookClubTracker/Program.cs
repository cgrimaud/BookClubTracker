using System;



namespace BookClubTracker
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // var meetups contains the JSON data
            var meetUps = JsonFileManager.GetListOfAllMeetUps();
            
            UserOptions.Run(meetUps);


        }

        
    }
}

