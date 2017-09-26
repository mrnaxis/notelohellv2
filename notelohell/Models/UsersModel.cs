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
        public bool Ativo { get; set; }
        public List<TaskUserModel> Tasks = new List<TaskUserModel>();

        public UsersModel() { }

        public bool GravarUsuario()
        {
            UsersDAO dao = new UsersDAO();
            UsersModel usercheck = dao.BuscarUsuario(Email, null);
            if (usercheck == null)
            {
                Id = ObjectId.GenerateNewId();
                Ativo = true;
            }
            return dao.GravarUsuario(this);
        }

        public UsersModel BuscarUsuario()
        {
            UsersDAO dao = new UsersDAO();
            return dao.BuscarUsuario(Email, Pwsin);
        }
        public void DesativarUsuario()
        {
            UsersDAO dao = new UsersDAO();
            UsersModel user = dao.BuscarUsuario(Email, Pwsin);
            if (user != null)
            {
                Ativo = false;
                dao.AlterarUsuario(this);
            }

        }

        public UsersModel AlterarUsuario()
        {
            UsersDAO dao = new UsersDAO();         
            return dao.AlterarUsuario(this);
        }

        public UsersModel AlterarSenhaUsuario()
        {
            UsersDAO dao = new UsersDAO();
            return dao.AlterarSenhaUsuario(this);
        }

        public bool Equals(UsersModel user)
        {
            if (!((user.Ativo.Equals(this.Ativo)) && (user.BirthDate.ToString("dd/MM/yyyy").Equals(this.BirthDate.ToString("dd/MM/yyyy")))
                && (user.Email.Equals(this.Email)) && (user.GameTag.Equals(this.GameTag))
                && (user.Nome.Equals(this.Nome)) && (user.Pwsin.Equals(this.Pwsin))
                && (user.Id.Equals(this.Id))))
                return false;
            return true;
        }
    }
}