using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Domain.Entities
{
    public class UserRegister : IdentityUser
    {
        public int RollNumberId { get; set; }
        public int CityId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Images { get; set; }
        public string PinCode { get; set; }
        public City? city { get; set; }
        public RollNumber? RollNumber { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDateAndTime { get; set; }
        public DateTime? UpdatedDateAndTime { get; set; }
        public DateTime? DeletedDateAndTime { get; set; }

        public ICollection<PostBusiness> postBusinesses { get; set; }
        public UserPersonalInformation PersonalInformation { get; set; }    



    }
}