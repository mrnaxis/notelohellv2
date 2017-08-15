using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using notelohell.Models;
using notelohell.App_Start;

namespace notelohell.DAO
{
    public class UsersDAO
    {
        protected static string collection = "usuarios";
        protected MongoConfig conf = new MongoConfig();
        public void GravarUsuario(UsersModel user)
        {

            conf.SalvarCollection(user,collection);
        }

        public UsersModel BuscarUsuario(string login, string senha)
        {           
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter;
            if (senha == null)
                filter = builder.Eq("Email", login);
            else
                filter = builder.Eq("Email", login) & builder.Eq("Pwsin", senha);

            List<BsonDocument> doc = conf.Buscar(filter,collection);
            UsersModel usuario = new UsersModel();

            if (doc.Count > 0)
            {
                usuario.Nome = doc.First()["Nome"].ToString();
                usuario.Email = doc.First()["Email"].ToString();
                usuario.GameTag = doc.First()["GameTag"].ToString();
            }
            else
                return null;
            return usuario;
        }
    }
}