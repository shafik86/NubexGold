using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }


    }
}
