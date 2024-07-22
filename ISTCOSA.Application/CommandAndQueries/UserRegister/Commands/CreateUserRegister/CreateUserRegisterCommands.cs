using ISTCOSA.Application.Common.DTOs;
using ISTCOSA.Domain.Entities;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserRegister.Commands.CreateUserRegister
{
    public class CreateUserRegisterCommands : IRequest<UserRegisterDTOs>
    {
        public int RollNumberId { get; set; }
        public int CityId { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Pincode { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Images { get; set; }
        public string? ImageType { get; set; }



    }
}
