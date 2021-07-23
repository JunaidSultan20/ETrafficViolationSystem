using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class Country : BaseEntity
    {
        public Country()
        {
            CarMakes = new HashSet<CarMake>();
            States = new HashSet<States>();
        }

        public int CountryId { get; set; }

        public string CountryTitle { get; set; }

        public string ShortCode { get; set; }

        public string CountryCode { get; set; }

        public string DialingCode { get; set; }

        public virtual ICollection<CarMake> CarMakes { get; set; }

        public virtual ICollection<States> States { get; set; }
    }
}