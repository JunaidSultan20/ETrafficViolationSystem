using System;

namespace ETrafficViolationSystem.Entities.Dto
{
    public class DriverDetailsDto : BaseDto
    {
        public int? DriverId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string CNIC { get; set; }

        public DateTime Dob { get; set; }

        public byte Gender { get; set; }

        public byte Religion { get; set; }

        public string PostalAddress { get; set; }

        public int CityId { get; set; }

        public string PermanentAddress { get; set; }

        public string MobileNumber { get; set; }

        public string HomePhone { get; set; }

        public string Email { get; set; }

        public byte BloodGroupId { get; set; }

        public string Height { get; set; }

        public string Mark { get; set; }

        public bool Disability { get; set; }

        public string DisabilityDescription { get; set; }
    }

    public class DriverDetailsInsertDto
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string CNIC { get; set; }

        public DateTime? Dob { get; set; }

        public byte? Gender { get; set; }

        public byte? Religion { get; set; }

        public string PostalAddress { get; set; }

        public int? CityId { get; set; }

        public string PermanentAddress { get; set; }

        public string MobileNumber { get; set; }

        public string HomePhone { get; set; }

        public string Email { get; set; }

        public byte? BloodGroupId { get; set; }

        public string Height { get; set; }

        public string Mark { get; set; }

        public bool? Disability { get; set; }

        public string DisabilityDescription { get; set; }
    }

    public class DriverDetailsUpdateDto : BaseUpdateDto
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string CNIC { get; set; }

        public DateTime? Dob { get; set; }

        public byte? Gender { get; set; }

        public byte? Religion { get; set; }

        public string PostalAddress { get; set; }

        public int? CityId { get; set; }

        public string PermanentAddress { get; set; }

        public string MobileNumber { get; set; }

        public string HomePhone { get; set; }

        public string Email { get; set; }

        public byte? BloodGroupId { get; set; }

        public string Height { get; set; }

        public string Mark { get; set; }

        public bool? Disability { get; set; }

        public string DisabilityDescription { get; set; }
    }
}