using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
    }
}