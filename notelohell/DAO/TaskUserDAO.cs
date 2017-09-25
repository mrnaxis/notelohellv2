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
        protected static string collection = "taskuser";
        protected static MongoConfig conf = new MongoConfig();

        public string GravarTask(TaskUserModel Tu)
        {
            string nomeSalvo = "";
            try
            {
                conf.SalvarCollection(Tu, collection);
                nomeSalvo = Tu.Nome;
            }
            catch(Exception ex)
            {

            }
            return nomeSalvo;
        }

        public TaskUserModel BuscarTasks(string email, string nome = null)
        {
            var builder = Builders<TaskUserModel>.Filter;
            FilterDefinition<TaskUserModel> filter;
            if (nome == null)
                filter = builder.Eq("Email", email);
            else
                filter = builder.Eq("EmailTask", email) & builder.Eq("Nome", nome);

            List<TaskUserModel> doc = conf.Buscar(filter, collection);
            TaskUserModel task;

            if (doc.Count > 0)
                task = doc[0];
            else
                task = null;

            return task;
        }
        public TaskUserModel AdicionarTask(TaskUserModel task)
        {
            TaskUserModel ret;
            var builder = Builders<TaskUserModel>.Filter;
            FilterDefinition<TaskUserModel> filter;
            filter = builder.Eq("EmailTask", task.EmailTask);
            var doc = new BsonDocument
            {
                { "$push",new BsonDocument{
                    { "Tasks",
                        new BsonDocument
                        {
                            {"EmailTask", task.EmailTask },
                            {"Order", task.Order},
                            {"Nome",task.Nome },
                            {"Desc",task.Desc },
                            {"Data", task.Data },
                            {"Complete",task.Complete }
                        }
                    }
                }
                }
            };
            try
            {
                return BsonSerializer.Deserialize<TaskUserModel>(conf.Alterar(filter, collection, doc));
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