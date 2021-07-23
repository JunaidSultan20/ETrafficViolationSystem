namespace ETrafficViolationSystem.Entities.Dto
{
    public class ViolationRecordDetailsDto : BaseDto
    {
        public int Id { get; set; }

        public int ViolationId { get; set; }

        public int InfractionId { get; set; }
    }

    public class ViolationRecordDetailsInsertDto : BaseInsertDto
    {
        public int? ViolationId { get; set; }

        public int? InfractionId { get; set; }
    }

    public class ViolationRecordDetailsUpdateDto : BaseUpdateDto
    {
        public int? ViolationId { get; set; }

        public int? InfractionId { get; set; }
    }
}