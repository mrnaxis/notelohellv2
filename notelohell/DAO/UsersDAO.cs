using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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
        public bool GravarUsuario(UsersModel user)
        {
            bool salvou = false;
            try
            {
                conf.SalvarCollection(user, collection);//qualquer merda que der no banco vai retornar exception
                salvou = true;
            }

            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            return salvou;
        }

        public UsersModel BuscarUsuario(string login, string senha = null)
        {
            var builder = Builders<UsersModel>.Filter;
            FilterDefinition<UsersModel> filter;
            if (senha == null)
                filter = builder.Eq("Email", login) & builder.Eq("Ativo",true);
            else
                filter = builder.Eq("Email", login) & builder.Eq("Pwsin", senha) & builder.Eq("Ativo", true);

            List<UsersModel> doc = conf.Buscar(filter, collection);
            UsersModel usuario;

            if (doc.Count > 0)
                usuario = doc[0];
            else
                usuario = null;

            return usuario;
        }
        
        public UsersModel AlterarUsuario(UsersModel user)//precisa de um usuario inteiro
        {
            UsersModel ret;
            var builder = Builders<UsersModel>.Filter;
            FilterDefinition<UsersModel> filter;
            filter = builder.Eq("_id",user.Id);
            var doc = new BsonDocument
            {{"$set",new BsonDocument{
                {"Nome", user.Nome },
                {"Email", user.Email},
                {"BirthDate",user.BirthDate },
                {"GameTag",user.GameTag },
                {"Ativo",user.Ativo }
                }
              }
            };
            try
            {
                return BsonSerializer.Deserialize<UsersModel>(conf.Alterar(filter, collection, doc));
            }
            catch(Exception ex)
            {
                string erro = ex.Message;
                ret = null;
            }
            return ret;
            
        }
        public UsersModel AlterarSenhaUsuario(UsersModel user)//precisa de um usuario inteiro
        {
            var builder = Builders<UsersModel>.Filter;
            FilterDefinition<UsersModel> filter;
            filter = builder.Eq("Email", user.Email);
            var doc = new BsonDocument
            {{"$set",new BsonDocument{
                {"Pwsin", user.Pwsin}
                }
              }
            };

            return BsonSerializer.Deserialize<UsersModel>(conf.Alterar(filter, collection, doc));
        }
    }
}