using System;

namespace ETrafficViolationSystem.Entities.Models
{
    public abstract class BaseEntity
    {
        public bool IsActive { get; set; } = true;

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}