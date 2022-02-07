using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ASP.Net_Core_WebAPI.Models
{
    public class Customers
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string username { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public DateTime birthdate { get; set; }

        public string email { get; set; }

        public Boolean active { get; set; }

        public Int32[] phone { get; set; }
    }
}
