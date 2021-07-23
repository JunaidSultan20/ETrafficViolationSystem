using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class DriverDetailsRequest : BaseRequest
    {
        public DriverDetailsDto DriverDetailsDto { get; set; }
    }
}