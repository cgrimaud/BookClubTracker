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

            var meetUps = JsonFileManager.GetListOfAllMeetUps();
            
            UserOptions.Run(meetUps);


        }

        
    }
}

