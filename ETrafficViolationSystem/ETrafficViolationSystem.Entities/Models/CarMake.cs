using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class CarMake : BaseEntity
    {
        public CarMake()
        {
            CarModels = new HashSet<CarModel>();
            Vehicles = new HashSet<Vehicles>();
        }

        public short MakeId { get; set; }

        public string MakeTitle { get; set; }

        public int OriginCountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<CarModel> CarModels { get; set; }

        public virtual ICollection<Vehicles> Vehicles { get; set; }
    }
}