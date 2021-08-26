namespace ETrafficViolationSystem.Entities.Dto
{
    public class CarMakeDto : BaseDto
    {
        public short MakeId { get; set; }

        public string MakeTitle { get; set; }

        public int OriginCountryId { get; set; }
    }

    public class CarMakeInsertDto
    {
        public string MakeTitle { get; set; }

        public int? OriginCountryId { get; set; }
    }

    public class CarMakeUpdateDto : BaseUpdateDto
    {
        public string MakeTitle { get; set; }

        public int? OriginCountryId { get; set; }
    }
}