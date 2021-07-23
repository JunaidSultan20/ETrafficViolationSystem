using System;

namespace ETrafficViolationSystem.Entities.Dto
{
    public class RolesDto
    {
        
    }

    public class RoleInsertDto : BaseInsertDto
    {
        public string Name { get; set; }
    }
}