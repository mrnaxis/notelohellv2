using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using notelohell.App_Start;
using notelohell.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace notelohell.DAO
{
    public class TaskUserDAO
    {
        protected static string collection = "usuarios";
        protected static MongoConfig conf = new MongoConfig();


        public List<TaskUserModel> BuscarTasks(string email, string nome = null)
        {
            var builder = Builders<UsersModel>.Filter;
            FilterDefinition<UsersModel> filter;
            List<TaskUserModel> doc = null;
            try
            {
                if (nome == null)
                {
                    filter = builder.Eq("Email", email);
                    doc = conf.Buscar(filter, collection)[0].Tasks;
                }
                else
                {
                    filter = builder.Eq("Email", email) & builder.Eq("Tasks.Nome", nome);
                    doc = conf.Buscar(filter, collection)[0].Tasks;
                    doc = (from task in doc
                           where task.Nome == nome
                           select task).ToList();
                }
            }
            catch(Exception ex)
            {

            }
            return doc;
        }
        public TaskUserModel AdicionarTask(TaskUserModel task,string email)
        {
            TaskUserModel ret;
            var builder = Builders<UsersModel>.Filter;
            FilterDefinition<UsersModel> filter;
            filter = builder.Eq("Email", email);

            List<TaskUserModel> checkPrev = BuscarTasks(email, task.Nome);

            if (checkPrev.Count > 0)
                task.Nome = task.Nome + checkPrev.Count;

            var doc = new BsonDocument
            {
                { "$push",new BsonDocument{
                    { "Tasks",
                        new BsonDocument
                        {
                            {"Order", task.Order},
                            {"Nome",task.Nome ?? "Nova Tarefa"},
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
        public TaskUserModel AlterarTask(string email,TaskUserModel task, string nome_old)
        {
            List<TaskUserModel> tasks = BuscarTasks(email);
            int indice = tasks.FindIndex(0, name => name.Nome == nome_old);
            TaskUserModel ret;
            //indice = 0;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.And(builder.Eq("Email", email), builder.Eq("Tasks.Nome", nome_old));
            var doc = new BsonDocument
            {{"$set",new BsonDocument{
                {"Tasks."+indice.ToString()+".Order", task.Order },
                {"Tasks."+indice.ToString()+".Nome", task.Nome},
                {"Tasks."+indice.ToString()+".Desc",task.Desc },
                {"Tasks."+indice.ToString()+".Data",task.Data },
                {"Tasks."+indice.ToString()+".Complete", task.Complete }
                }
              }
            };
            try
            {
                var a = BsonSerializer.Deserialize<UsersModel>(conf.Alterar(filter, collection, doc));
                ret = a.Tasks[0];
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                ret = null;
            }
            return ret;
        }

        public bool SeekAndDestroy(string email, TaskUserModel task)
        {
            List<TaskUserModel> tasks = BuscarTasks(email);
            int indice = tasks.FindIndex(0, name => name.Nome == task.Nome);
            TaskUserModel ret;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.And(builder.Eq("Email", email), builder.Eq("Tasks.Nome", task.Nome));
            return false;
        }

        private int RetornaIndice(List<TaskUserModel> tasks,TaskUserModel task)
        {
            return tasks.IndexOf(task);
        }
    }
}