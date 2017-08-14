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
        public void gravarUsuario(UsersModel user)
        {
            var usuario = new BsonDocument
            {
                {"nome",user.Nome },
                {"email",user.Email },
                {"pwhash",user.pwHash },
                {"gametag",user.gameTag }
            };
            conf.salvarCollection(usuario,collection);
        }

        public UsersModel buscarUsuario(string login, string senha)
        {           
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("nn","");
            if (senha == null)
                filter = builder.Eq("email", login);
            else
                filter = builder.Eq("email", login) & builder.Eq("pwhash", senha);

            List<BsonDocument> doc = conf.buscar(filter,collection);
            UsersModel usuario = new UsersModel();

            if (doc.Count > 0)
            {
                usuario.Nome = doc.First()["nome"].ToString();
                usuario.Email = doc.First()["email"].ToString();
                usuario.gameTag = doc.First()["gametag"].ToString();
            }
            else
                return null;
            return usuario;
        }
    }
}