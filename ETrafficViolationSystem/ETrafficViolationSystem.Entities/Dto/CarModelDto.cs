namespace ETrafficViolationSystem.Entities.Dto
{
    public class CarModelDto : BaseDto
    {
        public string ModelId { get; set; }

        public string ModelTitle { get; set; }

        public int ProductionYear { get; set; }

        public short MakeId { get; set; }
    }

    public class CarModelInsertDto
    {
        public string ModelId { get; set; }

        public string ModelTitle { get; set; }

        public int? ProductionYear { get; set; }

        public short? MakeId { get; set; }
    }

    public class CarModelUpdateDto : BaseUpdateDto
    {
        public string ModelId { get; set; }

        public string ModelTitle { get; set; }

        public int? ProductionYear { get; set; }

        public short? MakeId { get; set; }
    }
}