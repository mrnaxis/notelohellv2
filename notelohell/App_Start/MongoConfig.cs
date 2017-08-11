﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace notelohell.App_Start
{
    public class MongoConfig
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        public MongoConfig()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("notel");
        }
        public void salvarCollection(BsonDocument doc,string collection)
        {
           var col = _database.GetCollection<BsonDocument>(collection);
           col.InsertOne(doc);
        }
    }
}