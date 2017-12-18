﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Ziggy.Classes
{ 
    public class Toy
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("cost")]
        public decimal Cost { get; set; }
        [BsonElement("amount")]
        public int Amount { get; set; }
    }
}