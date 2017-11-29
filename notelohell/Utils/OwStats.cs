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
            string projection = "{DadosOverWatch : 1, _id : 0}";
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter;
            filter = builder.Empty;
           
           return conf.Buscar(filter,collection,projection);
        }
        /// <summary>
        ///  Retorna a média geral de vitorias competitivas
        /// </summary>
        public double CalcularVitoriasGeral()
        {
            double cont,soma,total;
            cont = soma = total = 0;
            List<BsonDocument> lista = DadosOverWatch();
            foreach(BsonDocument doc in lista)
            {
                try
                {
                    var comp = doc["DadosOverWatch"]["us"]["stats"]["competitive"]["game_stats"].ToBsonDocument();
                    var win = comp["games_won"];
                    var games = comp["games_played"];
                    
                    if (win != BsonNull.Value && games != BsonNull.Value)
                    {
                        soma += ((double)win/(double)games) *100;
                        cont++;
                    }
                    
                }
                catch { }
                
            }
            if (cont > 0)
                total = soma / cont;
            return total;
        }
        public double CalcularVitorias(BsonDocument dados)
        {
            double cont, soma, total;
            cont = soma = total = 0;

            try
            {
                var comp = dados["DadosOverWatch"]["us"]["stats"]["competitive"]["game_stats"].ToBsonDocument();
                var win = comp["games_won"];
                var games = comp["games_played"];

                if (win != BsonNull.Value && games != BsonNull.Value)
                {
                    soma += ((double)win / (double)games) * 100;
                    cont++;
                }

            }
            catch { }


            if (cont > 0)
                total = soma / cont;
            return total;
        }
    }
}