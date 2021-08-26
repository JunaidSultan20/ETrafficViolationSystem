using System;
using System.Text.Json.Serialization;

namespace ETrafficViolationSystem.Entities.Dto
{
    /// <summary>
    /// Base DTO
    /// </summary>
    public abstract class BaseDto
    {
        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        
        public int? UpdatedBy { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
    }

    /// <summary>
    /// Base Update Dto
    /// </summary>
    public abstract class BaseUpdateDto
    {
        [JsonIgnore]
        public bool? IsActive { get; set; }
    }
}