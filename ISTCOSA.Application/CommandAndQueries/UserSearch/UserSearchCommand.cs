using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.UserSearch
{
    public class UserSearchCommand : IRequest<PaginatedResponseDTO<UserRegisterDTOs>>
    {
        public int? BatchNumber { get; set; }
        public int? RollNumbers { get; set; }
        public int? CountryId { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PinCode { get; set; }

        // Pagination properties
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
