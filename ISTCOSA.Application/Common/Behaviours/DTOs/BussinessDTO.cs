using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.Common.Behaviours.DTOs
{
    public class BussinessDTO:IMapping<PostBusiness>
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserRegisterDTOs User { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Images { get; set; }
        public string ImagePath { get; set; }
        public string JobDescription { get; set; }
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }
        public IndustryDTO industry { get; set; }
        public DateTime? CreatedDateAndTime { get; set; }
        public DateTime? UpdatedDateAndTime { get; set; }
        public DateTime? DeletedDateAndTime { get; set; }



    }
}
