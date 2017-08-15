using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using notelohell.DAO;
using MongoDB.Bson;

namespace notelohell.Models
{
    public class UsersModel
    {
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        public ObjectId _id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Pwsin { get; set; }
        [Required]
        public string GameTag { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public bool GravarUsuario()
        {
            UsersDAO dao = new UsersDAO();
            UsersModel usercheck = dao.BuscarUsuario(this.Email,null);
            if (usercheck == null)
            {
                dao.GravarUsuario(this);
                return true;
            }
            return false;
        }

        public UsersModel BuscarUsuario()
        {
            UsersDAO dao = new UsersDAO();
            UsersModel userFind = dao.BuscarUsuario(this.Email, this.Pwsin);
            if (userFind == null)
                return null;
            else
                return userFind;
        }
    }
}