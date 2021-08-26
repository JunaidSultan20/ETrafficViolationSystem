namespace ETrafficViolationSystem.Entities.Dto
{
    public class PaymentModeDto : BaseDto
    {
        public byte? PaymentModeId { get; set; }

        public string Title { get; set; }
    }

    public class PaymentModeInsertDto
    {
        public string Title { get; set; }
    }

    public class PaymentModeUpdateDto : BaseUpdateDto
    {
        public string Title { get; set; }
    }
}