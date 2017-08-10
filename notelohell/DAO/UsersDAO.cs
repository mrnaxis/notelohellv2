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
        public void gravarUsuario(UsersModel user)
        {
            var usuario = new BsonDocument
            {
                {"nickname",user.Id },
                {"email",user.Email },
                {"pwhash",user.pwHash },
                {"gametag",user.gameTag }
            };
            MongoConfig conf = new MongoConfig();
            conf.salvarCollection(usuario,"usuarios");
        }
    }
}