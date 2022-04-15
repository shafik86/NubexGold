using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NubexGold.Client.Controller
{
    public class AdministrationController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager )
        {
            this.roleManager = roleManager;
        }

        [HttpPost]
        public IActionResult CreateRole()
        {
            return null;
        }

    }
}
