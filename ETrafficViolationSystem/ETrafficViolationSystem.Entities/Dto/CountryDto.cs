using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Dto
{
    /// <summary>
    /// Country Dto
    /// </summary>
    public class CountryDto : BaseDto
    {
        public CountryDto()
        {
            States = new HashSet<StatesDto>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string ShortCode { get; set; }

        public string CountryCode { get; set; }

        public string DialingCode { get; set; }

        public virtual ICollection<StatesDto> States { get; set; }
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