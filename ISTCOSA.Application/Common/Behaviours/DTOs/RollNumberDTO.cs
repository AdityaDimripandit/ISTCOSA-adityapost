namespace ISTCOSA.Application.Common.DTOs
{
    public class RollNumberDTO:IMapping<RollNumber>
    {
        public int RollNumberId { get; set; }
        public int BatchId { get; set; }
        public string BatchNumber { get; set; }
        public int RollNumbers { get; set; }
        
    }
}
