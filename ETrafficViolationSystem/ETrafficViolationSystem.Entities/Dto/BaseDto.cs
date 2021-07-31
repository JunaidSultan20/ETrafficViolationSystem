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
    /// Base Insert Dto
    /// </summary>
    public abstract class BaseInsertDto
    {
        [JsonIgnore]
        public bool IsActive { get; set; } = true;

        [JsonIgnore]
        public int CreatedBy { get; set; }

        [JsonIgnore]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

    /// <summary>
    /// Base Update Dto
    /// </summary>
    public abstract class BaseUpdateDto
    {
        [JsonIgnore]
        public bool? IsActive { get; set; }

        [JsonIgnore]
        public int? UpdatedBy { get; set; }

        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }
}