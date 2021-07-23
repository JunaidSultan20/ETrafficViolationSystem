using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class RoleInsertRequest : BaseRequest
    {
        public RoleInsertDto Role { get; set; }
    }
}