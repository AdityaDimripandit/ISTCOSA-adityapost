 

namespace ISTCOSA.Application.Common.DTOs
{
    public class UserPersonalDTO:IMapping<UserPersonalInformation>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
          
        public string MaritalStatus { get; set; }
        public string FamilyDetails { get; set; }
        public string PreviousDesignation { get; set; }
        public string PreviousCompanyName { get; set; }
        public string PreviousJobDescription { get; set; }
        public string FatherName { get; set; }
        public string SpouseName { get; set; }
        public string AnniversaryDate { get; set; }
        public string ISTCNickName { get; set; }
        public string ISTCFriend { get; set; }
        public string ISTCAbout { get; set; }
        public string Comments { get; set; }
        public string AboutYourself { get; set; }
        public string WhatsappNumber { get; set; }
        public string MembershipType { get; set; }
        public string LastLoginDate { get; set; }
        public int UserWorkId { get; set; }
        public UserWork UserWork { get; set; }
        public int UserStudentId { get; set; }
        public UserStudent UserStudent { get; set; }


        public string Email { get; set; }
        public UserRegister UserRegister { get; set; }

        

        public string UserFullName { get; set; }
        public int UserBatchId { get; set; }
        public int UserBatchNumber { get; set; }
        public int UserRollNumberId { get; set; }
        public int UserRollNumbers { get; set; }
        public int UserCityId { get; set; }
        public string UserCityName { get; set; }
        public int UserStateId { get; set; }
        public string UserStateName { get; set; }
        public int UserCountryId { get; set; }
        public string UserCountryName { get; set; }
        public string UserGender { get; set; }
        public DateTime UserDateOfBirth { get; set; }
        public string UserPinCode { get; set; }
        public string UserPhoneNumber { get; set; }
        public int UserRegisterId { get; set; }
        public string Images { get; set; }
        public string ImagePath { get; set; }
    


    }
}
