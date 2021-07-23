using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Request
{
    public class BankRequest : BaseRequest
    {
        public BanksDto BanksDto { get; set; }
    }

    public class BankInsertRequest : BaseRequest
    {
        public BanksDto BanksDto { get; set; }
    }

    public class BankUpdateRequest : BaseRequest
    {
        public BanksDto BanksDto { get; set; }
    }
}