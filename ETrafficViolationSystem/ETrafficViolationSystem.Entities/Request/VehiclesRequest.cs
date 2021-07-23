using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class VehiclesRequest : BaseRequest
    {
        public VehiclesDto VehiclesDto { get; set; }
    }
}