using AutoMapper;
 
namespace ISTCOSA.Application.Common.Mapping
{
    public interface IMapping<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
