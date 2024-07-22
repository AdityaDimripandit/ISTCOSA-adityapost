using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserProfile.Commands
{
    public class UpdateUserProfileCommand : IRequest<UserRegisterDTOs>
    {
       //[Adi]
      
        public int Id { get; set; }
        public string? UserId { get; set; }  
        public int RollNumberId { get; set; }
     
       
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string? CityName { get; set; }
        public string? StateName { get; set; }
        public string? CountryName { get; set; }

        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Pincode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Images { get; set; }
        public string? ImageType { get; set; }
        public DateTime? UpdatedDate { get; set; }


        //[Adi]
        public string Address { get; set; }
      


        public string ISTCNickName { get; set; }
        public string ISTCFriend { get; set; }
        public string ISTCAbout { get; set; }
        public string Comments { get; set; }
        public string AboutYourself { get; set; }











       


    }
}
