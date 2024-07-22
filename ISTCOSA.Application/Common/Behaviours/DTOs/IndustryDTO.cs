namespace ISTCOSA.Application.Common.DTOs
{
    public class IndustryDTO:IMapping<Domain.Entities.Industry>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }

        public PostBusiness postBusiness { get; set; }  
    }
}
