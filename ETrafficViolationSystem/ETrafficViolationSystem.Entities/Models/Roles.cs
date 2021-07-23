using System;
using Microsoft.AspNetCore.Identity;

namespace ETrafficViolationSystem.Entities.Models
{
    public class Roles : IdentityRole<int>
    {
        public bool IsActive { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}