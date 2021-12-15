using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChallengeCoodesh_CROM.Models.Entitie
{
    public class Articles
    {
        [BsonId]
        public int id { get; set; }
        public bool featured { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
        public string newsSite { get; set; }
        public string summary { get; set; }
        public string publishedAt { get; set; }
        public List<Launch> launches { get; set; }
        public List<Event> events { get; set; }
    }
    public class Launch
    {
        public string id { get; set; }
        public string provider { get; set; }
    }

    public class Event
    {
        public int id { get; set; }
        public string provider { get; set; }
    }
}

