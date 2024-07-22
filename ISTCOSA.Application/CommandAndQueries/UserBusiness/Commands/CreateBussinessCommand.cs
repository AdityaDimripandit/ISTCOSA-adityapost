using ISTCOSA.Application.Common.Behaviours.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQueries.UserBusiness.Commands
{
    public class CreateBussinessCommand : IRequest<BussinessDTO>
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User ID is required.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Company name must be between 2 and 100 characters.")]


        public string Company { get; set; }

        [Required(ErrorMessage = "Contact information is required.")]
        public string ContactName { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
        public string? Images { get; set; }
        public string? ImageType { get; set; }
        public string JobDescription { get; set; }
        public string Industry { get; set; }

        [Required(ErrorMessage = "Industry ID is required.")]
        public int IndustryId { get; set; }
        public DateTime? CreatedDateAndTime { get; set; }
        public DateTime? UpdatedDateAndTime { get; set; }
        public DateTime? DeletedDateAndTime { get; set; }
    }
}
