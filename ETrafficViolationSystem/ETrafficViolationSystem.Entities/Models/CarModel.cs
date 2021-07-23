namespace ETrafficViolationSystem.Entities.Models
{
    public class CarModel : BaseEntity
    {
        public string ModelId { get; set; }

        public string ModelTitle { get; set; }

        public int ProductionYear { get; set; }

        public short MakeId { get; set; }

        public virtual CarMake CarMake { get; set; }
    }
}