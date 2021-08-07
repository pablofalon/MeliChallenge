using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeliChallenge.API.DTOs
{
    public class MessageRequestDTO
    {
        public List<SatelliteDTO> Satellites { get; set; }
    }

    public class SingleMessageRequestDTO
    {
        SatelliteDTO Satellite { get; set; }
    }
}
