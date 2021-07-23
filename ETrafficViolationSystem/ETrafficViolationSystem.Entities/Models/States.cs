using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class States : BaseEntity
    {
        public States()
        {
            Cities = new HashSet<City>();
        }

        public int StateId { get; set; }

        public string StateTitle { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}