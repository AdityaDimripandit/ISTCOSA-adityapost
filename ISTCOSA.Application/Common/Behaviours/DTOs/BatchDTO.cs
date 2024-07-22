 

namespace ISTCOSA.Application.Common.DTOs
{
    public class BatchDTO : IMapping<Domain.Entities.Batch>
    {
        public int BatchId { get; set; }
        public int BatchNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
