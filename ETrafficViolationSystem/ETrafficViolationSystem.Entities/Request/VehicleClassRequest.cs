using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class VehicleClassRequest : BaseRequest
    {
        public VehicleClassDto VehicleClassDto { get; set; }
    }
}