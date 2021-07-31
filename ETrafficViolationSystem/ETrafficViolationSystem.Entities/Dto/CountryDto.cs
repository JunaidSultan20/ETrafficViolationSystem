namespace ETrafficViolationSystem.Entities.Dto
{
    /// <summary>
    /// Country Dto
    /// </summary>
    public class CountryDto : BaseDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortCode { get; set; }

        public string CountryCode { get; set; }

        public string DialingCode { get; set; }
    }

    /// <summary>
    /// Dto For Updating Country
    /// </summary>
    public class CountryUpdateDto : BaseUpdateDto
    {
        public string Title { get; set; }

        public string ShortCode { get; set; }

        public string CountryCode { get; set; }

        public string DialingCode { get; set; }
    }
}