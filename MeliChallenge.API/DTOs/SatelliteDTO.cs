using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeliChallenge.API.DTOs
{
    public class SatelliteDTO
    {
        public string Name { get; set; }
        public float Distance { get; set; }
        public string[] Message { get; set; }
    }
}
