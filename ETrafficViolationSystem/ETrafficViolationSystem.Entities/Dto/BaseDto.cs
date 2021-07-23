using System;

namespace ETrafficViolationSystem.Entities.Dto
{
    // Base Data Transfer Object
    public abstract class BaseDto
    {
        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        
        public int? UpdatedBy { get; set; }
        
        public DateTime? UpdatedDate { get; set; }
    }

    // Base Insert Data Transfer Object
    public abstract class BaseInsertDto
    {
        public bool IsActive { get; set; } = true;

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }

    // Base Update Data Transfer Object
    public abstract class BaseUpdateDto
    {
        public bool? IsActive { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; } = DateTime.Now;
    }
}