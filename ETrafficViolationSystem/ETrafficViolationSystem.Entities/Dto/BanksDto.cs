namespace ETrafficViolationSystem.Entities.Dto
{
    public class BanksDto : BaseDto
    {
        public byte? BankId { get; set; }

        public string Title { get; set; }

        public string ShortCode { get; set; }
    }

    public class BanksInsertDto
    {
        public string Title { get; set; }

        public string ShortCode { get; set; }
    }

    public class BanksUpdateDto : BaseUpdateDto
    {
        public string Title { get; set; }

        public string ShortCode { get; set; }
    }
}