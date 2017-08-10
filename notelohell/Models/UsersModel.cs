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
        [Required]
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string pwHash { get; set; }
        [Required]
        public string gameTag { get; set; }

        public void gravarUsuario(UsersModel user)
        {
            UsersDAO dao = new UsersDAO();
            dao.gravarUsuario(user);
        }
    }
}