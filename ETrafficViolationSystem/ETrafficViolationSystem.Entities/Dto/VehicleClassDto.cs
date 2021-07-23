namespace ETrafficViolationSystem.Entities.Dto
{
    public class VehicleClassDto : BaseDto
    {
        public byte? ClassId { get; set; }

        public string ClassTitle { get; set; }
    }

    public class VehicleClassInsertDto : BaseInsertDto
    {
        public string ClassTitle { get; set; }
    }

    public class VehicleClassUpdateDto : BaseUpdateDto
    {
        public string ClassTitle { get; set; }
    }
}