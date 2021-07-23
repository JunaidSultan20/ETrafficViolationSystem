using System;

namespace ETrafficViolationSystem.Entities.Models
{
    public class Officers : BaseEntity
    {
        public int UserId { get; set; }

        public string OfficerId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string Cnic { get; set; }

        public DateTime Dob { get; set; }

        public byte Gender { get; set; }

        public string Religion { get; set; }

        public string PostalAddress { get; set; }

        public int CityId { get; set; }

        public string PermanentAddress { get; set; }

        public string MobileNumber { get; set; }

        public string HomePhone { get; set; }

        public string Email { get; set; }

        public byte BloodGroupId { get; set; }

        public byte DesignationId { get; set; }

        public string OfficerImage { get; set; }

        public virtual City City { get; set; }

        public virtual Designation Designation { get; set; }

        public virtual Users User { get; set; }
    }
}