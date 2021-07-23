using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class CountryRequest : BaseRequest
    {
        public CountryDto Country { get; set; }
    }

    public class CountryUpdateRequest : BaseRequest
    {
        public CountryUpdateDto Country { get; set; }
    }
}