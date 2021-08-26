using Microsoft.AspNetCore.Identity;
using System;

namespace ETrafficViolationSystem.Entities.Dto
{
    public class UsersDto
    {
        [PersonalData]
        public virtual int Id { get; set; }

        [ProtectedPersonalData]
        public virtual string UserName { get; set; }

        public string NormalizedUserName { get; set; }

        [ProtectedPersonalData]
        public string Email { get; set; }

        public string NormalizedEmail { get; set; }

        [PersonalData]
        public bool EmailConfirmed { get; set; }

        [ProtectedPersonalData]
        public string PhoneNumber { get; set; }

        [PersonalData]
        public bool PhoneNumberConfirmed { get; set; }

        [PersonalData]
        public bool TwoFactorEnabled { get; set; }

        public virtual bool LockoutEnabled { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public virtual int AccessFailedCount { get; set; }
    }
}