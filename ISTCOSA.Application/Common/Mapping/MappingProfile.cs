using AutoMapper;
using ISTCOSA.Application.Common.Behaviours.DTOs;

namespace ISTCOSA.Application.Common.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CompanyDTO,Company>().ReverseMap();
            CreateMap<ProfessionDTO,Profession>().ReverseMap();
            CreateMap<IndustryDTO,Industry>().ReverseMap();
            CreateMap<ProfessionDTO,Profession>().ReverseMap();

            CreateMap<UserRegisterDTOs, UserRegister>();
            CreateMap<UserRegister, UserRegisterDTOs>()

                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PersonalInformation.Id))
                 
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.BatchId, opt => opt.MapFrom(src => src.RollNumber.Batch.BatchId))
                .ForMember(dest => dest.BatchNumber, opt => opt.MapFrom(src => src.RollNumber.Batch.BatchNumber))
                .ForMember(dest => dest.RollNumberId, opt => opt.MapFrom(src => src.RollNumberId))
                .ForMember(dest => dest.RollNumbers, opt => opt.MapFrom(src => src.RollNumber.RollNumbers))
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.city.Name))
                .ForMember(dest => dest.StateId, opt => opt.MapFrom(src => src.city.StateId))
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.city.State.Name))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.city.State.CountryId))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.PersonalInformation.Address))
                .ForMember(dest => dest.ISTCNickName, opt => opt.MapFrom(src => src.PersonalInformation.ISTCNickName))
                .ForMember(dest => dest.ISTCAbout, opt => opt.MapFrom(src => src.PersonalInformation.ISTCAbout))
                .ForMember(dest => dest.ISTCFriend, opt => opt.MapFrom(src => src.PersonalInformation.ISTCFriend))
                .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.PersonalInformation.Comments))
                .ForMember(dest => dest.AboutYourself, opt => opt.MapFrom(src => src.PersonalInformation.AboutYourself))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.city.State.Country.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.PersonalInformation.User.Email))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));

                
         
            CreateMap<UserPersonalDTO, UserPersonalInformation>();
            CreateMap<UserPersonalInformation, UserPersonalDTO>()
           .ForMember(dest => dest.LastLoginDate, opt => opt.MapFrom(src => src.User.LastLoginDate))
           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
           .ForMember(dest => dest.UserFullName, opt => opt.MapFrom(src => src.User.FullName))
                .ForMember(dest => dest.UserBatchId, opt => opt.MapFrom(src => src.User.RollNumber.Batch.BatchId))
                .ForMember(dest => dest.UserBatchNumber, opt => opt.MapFrom(src => src.User.RollNumber.Batch.BatchNumber))
                .ForMember(dest => dest.UserRollNumberId, opt => opt.MapFrom(src => src.User.RollNumberId))
                .ForMember(dest => dest.UserRollNumbers, opt => opt.MapFrom(src => src.User.RollNumber.RollNumbers))
                .ForMember(dest => dest.UserCityName, opt => opt.MapFrom(src => src.User.city.Name))
                .ForMember(dest => dest.UserStateId, opt => opt.MapFrom(src => src.User.city.StateId))
                .ForMember(dest => dest.UserStateName, opt => opt.MapFrom(src => src.User.city.State.Name))
                .ForMember(dest => dest.UserCountryId, opt => opt.MapFrom(src => src.User.city.State.CountryId))
                .ForMember(dest => dest.UserCountryName, opt => opt.MapFrom(src => src.User.city.State.Country.Name))
                .ForMember(dest => dest.UserGender, opt => opt.MapFrom(src => src.User.Gender))
                .ForMember(dest => dest.UserDateOfBirth, opt => opt.MapFrom(src => src.User.DateOfBirth))
                .ForMember(dest => dest.UserPinCode, opt => opt.MapFrom(src => src.User.PinCode))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.User.Images))
                .ForMember(dest => dest.UserStudent, opt => opt.MapFrom(src => src.UserStudent))
                .ForMember(dest => dest.UserPhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.UserCityId, opt => opt.MapFrom(src => src.User.city.Id))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<UserStudent,UserStudentDTO>();
            CreateMap<UserWork, UserWorkDTO>();
            CreateMap<PostEmploymentDTO,PostEmployment>();
            CreateMap<PostEmployment, PostEmploymentDTO>()
                .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Company.Id))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Company.Name))
                .ForMember(dest => dest.CompanyAddress, opt => opt.MapFrom(src => src.Company.Address))
                .ForMember(dest => dest.CompanyPhoneNumber, opt => opt.MapFrom(src => src.Company.PhoneNumber))
                .ForMember(dest => dest.CompanyEmailAddress, opt => opt.MapFrom(src => src.Company.EmailAddress))
                .ForMember(dest => dest.IndustryId, opt => opt.MapFrom(src => src.Industry.Id))
                .ForMember(dest => dest.IndustryName, opt => opt.MapFrom(src => src.Industry.Name))
                .ForMember(dest => dest.EmploymentTypeId, opt => opt.MapFrom(src => src.EmploymentType.Id))
                .ForMember(dest => dest.EmploymentTypeName, opt => opt.MapFrom(src => src.EmploymentType.Name));

            CreateMap<RollNumberDTO, RollNumber>();
            CreateMap<RollNumber, RollNumberDTO>()
                .ForMember(dest => dest.BatchId, opt => opt.MapFrom(src => src.Batch.BatchId))
                .ForMember(dest => dest.BatchNumber, opt => opt.MapFrom(src => src.Batch.BatchNumber));

            CreateMap<BatchDTO, Domain.Entities.Batch>().ReverseMap();
            CreateMap<CountryDTO, Domain.Entities.Country>().ReverseMap();
            CreateMap<StateDTO, Domain.Entities.State>();
            CreateMap<Domain.Entities.State, StateDTO>()
           .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<CityDTO, Domain.Entities.City>().ReverseMap();


            CreateMap<BussinessDTO, PostBusiness>();
            CreateMap<PostBusiness,BussinessDTO> ()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.Company))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            //.ForMember(dest => dest.industry, opt => opt.MapFrom(src => src.industry))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.ContactName, opt => opt.MapFrom(src => src.ContactName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.JobDescription, opt => opt.MapFrom(src => src.JobDescription))
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
            .ForMember(dest => dest.CreatedDateAndTime, opt => opt.MapFrom(src => src.CreatedDateAndTime))
            .ForMember(dest => dest.IndustryName, opt => opt.MapFrom(src => src.industry.Name));


        }

    }
}
