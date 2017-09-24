using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace notelohell.Models
{
    public class TaskUserModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string EmailTask { get; set; }
        public int Order { get; set; }
        public string Nome { get; set; }
        public string Desc { get; set; }
        public DateTime Data { get; set; }
        public bool Complete { get; set; }

        public TaskUserModel()
        {

        }


    }
}