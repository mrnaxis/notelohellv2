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
        public int Order { get; set; }
        public string Nome { get; set; }
        public string Desc { get; set; }
        public DateTime Data { get; set; }
        public bool Complete { get; set; }

        public TaskUserModel()
        {

        }

        public string gravarTask(string email)
        {
            string nomeRetorno = string.Empty;
            TaskUserDAO dao = new TaskUserDAO();
            
            TaskUserModel retorno;
            retorno = dao.AdicionarTask(this,email);
            nomeRetorno = retorno.Nome;
                      
           return nomeRetorno;
        }

        public List<TaskUserModel> BuscarTasks(string email, string nome = null)
        {
            TaskUserDAO td = new TaskUserDAO();
            List<TaskUserModel> ltd = td.BuscarTasks(email, nome);
            return ltd;
        }

        public TaskUserModel AlterarTask(string email)
        {
            TaskUserDAO taskDao = new TaskUserDAO();
            return taskDao.AlterarTask(email, this);
        }

    }
}