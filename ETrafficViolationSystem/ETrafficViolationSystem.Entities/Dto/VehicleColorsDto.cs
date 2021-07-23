namespace ETrafficViolationSystem.Entities.Dto
{
    public class VehicleColorsDto : BaseDto
    {
        public short? ColorId { get; set; }

        public byte ColorTypeId { get; set; }

        public string ColorName { get; set; }

        public string ColorCode { get; set; }
    }

    public class VehicleColorsInsertDto : BaseInsertDto
    {
        public byte? ColorTypeId { get; set; }

        public string ColorName { get; set; }

        public string ColorCode { get; set; }
    }

    public class VehicleColorsUpdateDto : BaseUpdateDto
    {
        public byte? ColorTypeId { get; set; }

        public string ColorName { get; set; }

        public string ColorCode { get; set; }
    }
}