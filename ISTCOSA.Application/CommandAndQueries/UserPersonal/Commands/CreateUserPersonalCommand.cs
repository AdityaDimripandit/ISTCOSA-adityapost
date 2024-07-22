using ISTCOSA.Application.Common.DTOs;
using System.ComponentModel.DataAnnotations;
namespace ISTCOSA.Application.CommandAndQuries.UserPersonal.Commands
{
    public class CreateUserPersonalCommand : IRequest<UserPersonalDTO>
    {


        [Required(ErrorMessage = "UserId is required.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "ProfessionId is required.")]
        public int ProfessionId { get; set; }

        public string Address { get; set; }

       
        public string MaritalStatus { get; set; }

       
        public string FatherName { get; set; }

        
     
        public string SpouseName { get; set; }

        [Display(Name = "Anniversary Date")]
        
        public DateTime? AnniversaryDate { get; set; }

       
        public string FamilyDetails { get; set; }

        
       
        public string PreviousDesignation { get; set; }

      
        
        public string PreviousCompanyName { get; set; }

        
        public string PreviousJobDescription { get; set; }

       
        public string ISTCNickName { get; set; }
       
        public string ISTCFriend { get; set; }

        [Required]
        public string ISTCAbout { get; set; }

        
        public string Comments { get; set; }

        
        public string AboutYourself { get; set; }

        [Phone(ErrorMessage = "Invalid Whatsapp Number.")]
        public string WhatsappNumber { get; set; }

       
        public string MembershipType { get; set; }
       
        public string Designation { get; set; }

        [Phone(ErrorMessage = "Invalid Contact Number.")]
        public string ContactNumber { get; set; }

        [Display(Name = "From Date")]

        public DateTime? FromDate { get; set; }

        [Display(Name = "To Date")]
        public DateTime? ToDate { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string EmailID { get; set; }

        [StringLength(500)]
        public string WorkProfile { get; set; }

        [StringLength(100)]
        public string CollegeName { get; set; }

        [StringLength(100)]
        public string Degree { get; set; }

        [StringLength(200)]
        public string Skills { get; set; }

       
        public DateTime? JoiningYear { get; set; }

        public DateTime? ExpectedComplitionYear { get; set; }

       
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "CityId is required.")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Company Id is required.")]
        public int? CompanyId { get; set; }

        
        public string CompanyAddress { get; set; }

        [Phone(ErrorMessage = "Invalid Company Phone Number.")]
        public string CompanyPhoneNumber { get; set; }
      
        [EmailAddress(ErrorMessage = "Invalid Company Email Address.")]
        public string CompanyEmailAddress { get; set; }
    }


}
