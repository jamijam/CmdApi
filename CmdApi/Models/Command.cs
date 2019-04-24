using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CmdApi.Models
{
    public class Command
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("HowTo")]
        public string HowTo { get; set; }

        [BsonElement("Platform")]
        public string Platform { get; set; }

        [BsonElement("CommandLine")]
        public string CommandLine { get; set; }
    }
}
