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

        public bool GravarTask(TaskUserModel Tu)
        {
            bool salvou = false;
            try
            {
                conf.SalvarCollection(Tu, collection);
                salvou = true;
            }
            catch(Exception ex)
            {

            }
            return salvou;
        }
    }
}