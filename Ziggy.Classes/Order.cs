using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Ziggy.Classes
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("kid")]
        public string Kid { get; set; }
        [BsonElement("status")]
        public Status Status { get; set; }
        [BsonElement("toys")]
        public List<Toy> Toys { get; set; }
        [BsonElement("requestDate")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime RequestDate { get; set; }
    }
}