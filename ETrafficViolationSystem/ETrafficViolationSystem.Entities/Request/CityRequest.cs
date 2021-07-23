using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class CityRequest : BaseRequest
    {
        public CityDto CityDto { get; set; }
    }
}