using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class Designation : BaseEntity
    {
        public Designation()
        {
            Officers = new HashSet<Officers>();
        }

        public byte? DesignationId { get; set; }

        public string Title { get; set; }

        public byte? ReportsTo { get; set; }

        public virtual ICollection<Officers> Officers { get; set; }
    }
}