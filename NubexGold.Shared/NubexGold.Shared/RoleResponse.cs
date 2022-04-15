using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NubexGold.Shared
{
    public class RoleResponse
    {
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
