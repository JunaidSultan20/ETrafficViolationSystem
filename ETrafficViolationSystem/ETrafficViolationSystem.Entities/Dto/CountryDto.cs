namespace ETrafficViolationSystem.Entities.Dto
{
    public class CountryDto : BaseDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortCode { get; set; }

        public string CountryCode { get; set; }

        public string DialingCode { get; set; }
    }

    public class CountryUpdateDto : BaseUpdateDto
    {
        public string Title { get; set; }

        public string ShortCode { get; set; }

        public string CountryCode { get; set; }

        public string DialingCode { get; set; }
    }
}