namespace ETrafficViolationSystem.Entities.Dto
{
    public class CityDto : BaseDto
    {
        public int? CityId { get; set; }

        public string CityTitle { get; set; }

        public int PostalCode { get; set; }

        public short StateId { get; set; }
    }

    public class CityInsertDto
    {
        public string CityTitle { get; set; }

        public int? PostalCode { get; set; }

        public short? StateId { get; set; }
    }

    public class CityUpdateDto : BaseUpdateDto
    {
        public string CityTitle { get; set; }

        public int? PostalCode { get; set; }

        public short? StateId { get; set; }
    }
}