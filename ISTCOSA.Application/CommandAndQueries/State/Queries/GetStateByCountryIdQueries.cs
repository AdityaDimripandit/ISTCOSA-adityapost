using ISTCOSA.Application.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISTCOSA.Application.CommandAndQuries.State.Queries
{
    public class GetStateByCountryIdQueries : IRequest<List<StateDTO>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public CountryDTO? Country { get; set; }
    }
}
