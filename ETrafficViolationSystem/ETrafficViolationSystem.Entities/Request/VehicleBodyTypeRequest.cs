using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class VehicleBodyTypeRequest : BaseRequest
    {
        public VehicleBodyTypeDto VehicleBodyTypeDto { get; set; }
    }
}