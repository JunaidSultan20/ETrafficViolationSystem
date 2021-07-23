using Microsoft.AspNetCore.Identity;

namespace ETrafficViolationSystem.Entities.Models
{
    public class Users : IdentityUser<int>
    {
        public virtual Officers Officer { get; set; }
    }
}