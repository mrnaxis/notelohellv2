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
        protected IMongoClient _client { get; set; }
        protected IMongoDatabase _database { get; set; }
        public MongoConfig()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("notel");
        }
        public void SalvarCollection(object doc,string collection)
        {
           var col = _database.GetCollection<object>(collection);
           col.InsertOne(doc);
        }
        public List<BsonDocument> Buscar(FilterDefinition<BsonDocument> filter,string collection)
        {
            var col = _database.GetCollection<BsonDocument>(collection);
            return col.Find(filter).ToList();
        }
    }
}