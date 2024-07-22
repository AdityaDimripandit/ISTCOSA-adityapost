 

namespace ISTCOSA.Application.Common.DTOs
{
    public class CityDTO:IMapping<Domain.Entities.City>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public StateDTO? State { get; set; }
    }
}
