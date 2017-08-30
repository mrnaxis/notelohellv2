using System;
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
        protected static IMongoClient _client = new MongoClient("mongodb://localhost:27017");
        protected static IMongoDatabase _database = _client.GetDatabase("notel");
        public MongoConfig()
        {

        }
        public void SalvarCollection(object doc,string collection)
        {
           var col = _database.GetCollection<object>(collection);
           col.InsertOne(doc);
        }
        public List<T> Buscar<T>(FilterDefinition<T> filter,string collection)
        {
            var col = _database.GetCollection<T>(collection);
            return col.Find(filter).ToList();
        }
        public BsonDocument Alterar<T>(FilterDefinition<T> filter,string collection,BsonDocument doc)
        {
            var col = _database.GetCollection<T>(collection);
            var options = new FindOneAndUpdateOptions<T>();
            options.ReturnDocument = ReturnDocument.After;
            return col.FindOneAndUpdate(filter,doc,options).ToBsonDocument();
        }
    }
}