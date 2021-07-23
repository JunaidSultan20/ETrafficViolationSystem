using System;
using System.Collections.Generic;

namespace ETrafficViolationSystem.Entities.Models
{
    public class OwnerDetails : BaseEntity
    {
        public OwnerDetails()
        {
            TaxDetails = new HashSet<TaxDetails>();
            VehicleDetails = new HashSet<VehicleDetails>();
        }

        public int OwnerId { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string CNIC { get; set; }

        public DateTime Dob { get; set; }

        public byte Gender { get; set; }

        public string Religion { get; set; }

        public string PostalAddress { get; set; }

        public int CityId { get; set; }

        public string PermanentAddress { get; set; }

        public string MobileNumber { get; set; }

        public string HomePhone { get; set; }

        public string Email { get; set; }

        public string OwnerImage { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<TaxDetails> TaxDetails { get; set; }

        public virtual ICollection<VehicleDetails> VehicleDetails { get; set; }
    }
}