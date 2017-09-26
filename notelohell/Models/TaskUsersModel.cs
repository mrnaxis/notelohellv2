﻿using MongoDB.Bson;
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

        public string gravarTask()
        {
            string nomeRetorno = string.Empty;
            TaskUserDAO dao = new TaskUserDAO();
            
            TaskUserModel retorno;
            retorno = dao.AdicionarTask(this);
            nomeRetorno = retorno.Nome;
                      
           return nomeRetorno;
        }


    }
}