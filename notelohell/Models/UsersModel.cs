using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using notelohell.DAO;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace notelohell.Models
{
    public class UsersModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Digite seu nome")]
        public string Nome { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Digite uma senha válida")]
        public string Pwsin { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Digite uma gametag/nickname valida")]
        public string GameTag { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public bool Ativo { get; private set; }

        public UsersModel()
        {
            this.Id = ObjectId.GenerateNewId();
            this.Ativo = true;
        }

        public bool GravarUsuario()
        {
            UsersDAO dao = new UsersDAO();
            UsersModel usercheck = dao.BuscarUsuario(this.Email, null);
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
        public void DesativarUsuario()
        {
            UsersDAO dao = new UsersDAO();
            UsersModel user = dao.BuscarUsuario(this.Email, this.Pwsin);
            if (user != null)
            {
                this.Ativo = false;
                dao.AlterarUsuario(this);
            }

        }

        public UsersModel AlterarUsuario()
        {
            UsersDAO dao = new UsersDAO();
            UsersModel user = dao.BuscarUsuario(Email);//talvez não precise mais
            if(user != null)
            {
               user = dao.AlterarUsuario(this);
            }
            return user;
        }
        public UsersModel AlterarSenhaUsuario()
        {
            UsersDAO dao = new UsersDAO();
            UsersModel user = dao.BuscarUsuario(Email);
            if (user != null)
            {
                user = dao.AlterarSenhaUsuario(this);
            }
            return user;
        }
    }
}