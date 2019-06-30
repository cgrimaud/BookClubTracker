using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace BookClubTracker
{

    public class RootObject
    {
        public MeetUp[] MeetUp { get; set; }
    }

    public class MeetUp
    {

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }
        [JsonProperty(PropertyName = "genre")]
        public string Genre { get; set; }
        [JsonProperty(PropertyName = "meetUpDate")]
        public string MeetUpDate { get; set; }
        [JsonProperty(PropertyName = "meetUpLocation")]
        public string MeetUpLocation { get; set; }
    }

}

