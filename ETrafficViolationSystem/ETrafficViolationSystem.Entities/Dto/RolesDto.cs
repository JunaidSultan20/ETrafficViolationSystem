using System;

namespace ETrafficViolationSystem.Entities.Dto
{
    public class RolesDto : BaseDto
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }
    }

    public class RoleInsertDto
    {
        public string Name { get; set; }
    }
}