using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class InfractionsRequest : BaseRequest
    {
        public InfractionsDto InfractionsDto { get; set; }
    }

    public class InfractionsInsertRequest : BaseRequest
    {
        public InfractionsInsertDto Infraction { get; set; }
    }

    public class InfractionsUpdateRequest : BaseRequest
    {
        public InfractionsUpdateDto Infraction { get; set; }
    }
}