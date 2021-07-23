using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class VehicleColorsRequest : BaseRequest
    {
        public VehicleColorsDto VehicleColorsDto { get; set; }
    }
}