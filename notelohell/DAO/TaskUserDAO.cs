using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using notelohell.App_Start;
using notelohell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace notelohell.DAO
{
    public class TaskUserDAO
    {
        protected static string collection = "usuarios";
        protected static MongoConfig conf = new MongoConfig();


        public List<TaskUserModel> BuscarTasks(string email, string nome = null)
        {
            var builder = Builders<TaskUserModel>.Filter;
            FilterDefinition<TaskUserModel> filter;
            if (nome == null)
                filter = builder.Eq("Email", email);
            else
                filter = builder.Eq("EmailTask", email) & builder.Eq("Nome", nome);

            List<TaskUserModel> doc = conf.Buscar(filter, collection);

            return doc;
        }
        public TaskUserModel AdicionarTask(TaskUserModel task,string email)
        {
            TaskUserModel ret;
            var builder = Builders<UsersModel>.Filter;
            FilterDefinition<UsersModel> filter;
            filter = builder.Eq("Email", email);
            var doc = new BsonDocument
            {
                { "$push",new BsonDocument{
                    { "Tasks",
                        new BsonDocument
                        {
                            {"Order", task.Order},
                            {"Nome",task.Nome ?? ""},
                            {"Desc",task.Desc ?? ""},
                            {"Data", task.Data },
                            {"Complete",task.Complete }
                        }
                    }
                }
                }
            };
            try
            {
                var a = BsonSerializer.Deserialize<UsersModel>(conf.Alterar(filter, collection, doc));
                return ret = a.Tasks.Last();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                ret = null;
            }
            return ret;
        }
    }
}