using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class OwnerDetailsRequest : BaseRequest
    {
        public OwnerDetailsDto OwnerDetailsDto { get; set; }
    }
}