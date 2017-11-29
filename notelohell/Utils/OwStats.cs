using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using notelohell.App_Start;
using MongoDB.Driver;
using MongoDB.Bson;

namespace notelohell.Utils
{
    public class OwStats
    {
        protected static string collection = "usuarios";
        protected static MongoConfig conf = new MongoConfig();
        public OwStats() { }

        /// <summary>
        /// Retorna todos os dados do jogo Overwatch disponiveis na base
        /// </summary>
        public List<BsonDocument> DadosOverWatch()
        {
            string projection = "{DadosOverWatch : 1}";
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter;
            filter = builder.Empty;
           
           return conf.Buscar(filter,collection,projection);
        }

        public void Calcular()
        {

        }
    }
}