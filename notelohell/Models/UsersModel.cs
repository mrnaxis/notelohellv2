using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace notelohell.Models
{
    public class UsersModel : IUser
    {
        public string Id { get; set; }
        public string UserName { get { return Email; } set { Email = UserName; } }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string pwHash { get; set; }
        public string gameTag { get; set; }
    }
}