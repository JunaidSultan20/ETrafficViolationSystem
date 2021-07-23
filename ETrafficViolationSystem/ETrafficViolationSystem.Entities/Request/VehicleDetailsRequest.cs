using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class VehicleDetailsRequest : BaseRequest
    {
        public VehicleDetailsDto VehicleDetailsDto { get; set; }
    }
}