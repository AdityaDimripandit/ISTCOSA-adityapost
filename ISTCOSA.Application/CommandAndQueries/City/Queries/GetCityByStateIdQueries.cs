using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.City.Queries
{
    public class GetCityByStateIdQueries : IRequest<List<CityDTO>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public StateDTO? State { get; set; }
    }
}
