using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class Infractions : BaseEntity
    {
        public Infractions()
        {
            ViolationRecordDetails = new HashSet<ViolationRecordDetails>();
        }

        public int InfractionId { get; set; }

        public string Description { get; set; }

        public int Penalty { get; set; }

        public byte Points { get; set; }

        public virtual ICollection<ViolationRecordDetails> ViolationRecordDetails { get; set; }
    }
}