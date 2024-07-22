
namespace ISTCOSA.Application.Common.DTOs
{
    public class CountryDTO:IMapping<Domain.Entities.Country>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
