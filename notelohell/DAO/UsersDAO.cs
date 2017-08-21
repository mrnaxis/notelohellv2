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
        public void GravarUsuario(UsersModel user)
        {
            conf.SalvarCollection(user, collection);
        }

        public UsersModel BuscarUsuario(string login, string senha)
        {
            var builder = Builders<UsersModel>.Filter;
            FilterDefinition<UsersModel> filter;
            if (senha == null)
                filter = builder.Eq("Email", login);
            else
                filter = builder.Eq("Email", login) & builder.Eq("Pwsin", senha);

            List<UsersModel> doc = conf.Buscar(filter, collection);
            UsersModel usuario;

            if (doc.Count > 0)
                usuario = doc[0];
            else
                usuario = null;

            return usuario;
        }
        
        public void AlterarUsuario(UsersModel user)//precisa de um usuario inteiro
        {
            var builder = Builders<UsersModel>.Filter;
            FilterDefinition<UsersModel> filter;
            filter = builder.Eq("Email", user.Email);
            var doc = new BsonDocument
            {//colocar campos editaveis aqui
                { "nome", user.Nome },
                {"Pwsin",user.Pwsin },
                {"gametag",user.GameTag }                                           
            };
            conf.Alterar(filter, collection,doc);
        }
    }
}