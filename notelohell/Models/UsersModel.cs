using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using notelohell.DAO;

namespace notelohell.Models
{
    public class UsersModel
    {
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string pwHash { get; set; }
        [Required]
        public string gameTag { get; set; }

        public bool gravarUsuario()
        {
            UsersDAO dao = new UsersDAO();
            UsersModel usercheck = dao.buscarUsuario(this.Email,null);
            if (usercheck == null)
            {
                dao.gravarUsuario(this);
                return true;
            }
            return false;
        }

        public UsersModel buscarUsuario()
        {
            UsersDAO dao = new UsersDAO();
            UsersModel userFind = dao.buscarUsuario(this.Email, this.pwHash);
            if (userFind == null)
                return null;
            else
                return userFind;
        }
    }
}