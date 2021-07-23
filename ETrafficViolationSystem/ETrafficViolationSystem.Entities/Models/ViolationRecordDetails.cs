namespace ETrafficViolationSystem.Entities.Models
{
    public class ViolationRecordDetails : BaseEntity
    {
        public int Id { get; set; }

        public int ViolationId { get; set; }

        public int InfractionId { get; set; }

        public virtual Infractions Infraction { get; set; }

        public virtual ViolationRecords ViolationRecords { get; set; }
    }
}