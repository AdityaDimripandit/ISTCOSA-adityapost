 

namespace ISTCOSA.Application.Common.DTOs
{
    public class UserRegisterDTOs:IMapping<Domain.Entities.UserRegister>
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        
        public int BatchId { get; set; }
        public int BatchNumber { get; set; }
        public int RollNumberId { get; set; }
        public int RollNumbers {  get; set; }
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Images { get; set; }
        public string ImagePath { get; set; }
        public string PinCode { get; set; }
        
        public string Address { get; set; }
        
        
        public string ISTCNickName { get; set; }
        public string ISTCFriend { get; set; }
        public string ISTCAbout { get; set; }
        public string Comments { get; set; }
        public string AboutYourself { get; set; }
       
        public PostBusiness postBusiness { get; set; }  
    


    }
}
