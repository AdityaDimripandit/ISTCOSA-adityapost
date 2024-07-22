using ISTCOSA.Application.Common.Behaviours.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQueries.UserBusiness.Commands
{
    public class UpdateBussinessCommand: IRequest<BussinessDTO>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Images { get; set; }
        public string? ImageType { get; set; }
        public string JobDescription { get; set; }
        public int IndustryId { get; set; }
        public DateTime? CreatedDateAndTime { get; set; }
        public DateTime? UpdatedDateAndTime { get; set; }
        public DateTime? DeletedDateAndTime { get; set; }
    }
}
