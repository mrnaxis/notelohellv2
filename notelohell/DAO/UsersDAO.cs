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
        protected static MongoConfig conf = new MongoConfig();
        public void gravarUsuarioAsync(UsersModel user)
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
            var filter = builder.Eq("email", login) & builder.Eq("pwhash", senha);
            var doc = conf.buscar(filter,collection);
            UsersModel usuario = new UsersModel();
            usuario.Nome = doc[0]["nome"].ToString();
            usuario.Email = doc[0]["email"].ToString();
            usuario.pwHash = doc[0]["pwhash"].ToString();
            usuario.gameTag = doc[0]["gametag"].ToString();
            return usuario;
        }
    }
}