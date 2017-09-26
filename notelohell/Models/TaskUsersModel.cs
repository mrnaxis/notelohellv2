using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using notelohell.DAO;

namespace notelohell.Models
{
    public class TaskUserModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string EmailTask { get; set; }
        public int Order { get; set; }
        public string Nome { get; set; }
        public string Desc { get; set; }
        public DateTime Data { get; set; }
        public bool Complete { get; set; }

        public TaskUserModel()
        {

        }

        public string gravarTask()
        {
            string nomeRetorno = string.Empty;
            TaskUserDAO dao = new TaskUserDAO();
            TaskUserModel taskcheck = dao.BuscarTasks(EmailTask);
            if (taskcheck == null)
            {
                Id = ObjectId.GenerateNewId();
                nomeRetorno = dao.GravarTask(this);
            }
            else
            {
                TaskUserModel retorno;
                retorno = dao.AdicionarTask(this);
                nomeRetorno = retorno.Nome;
            }
            
           return nomeRetorno;
        }


    }
}