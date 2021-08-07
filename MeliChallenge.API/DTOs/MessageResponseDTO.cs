using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeliChallenge.API.DTOs
{
    public class MessageResponseDTO
    {
        public CoordinateDTO Position { get; set; }
        public string Message { get; set; }

        public MessageResponseDTO(float x, float y, string message)
        {
            Position = new CoordinateDTO()
            {
                X = x,
                Y = y
            };
            Message = message;
        }
    }
}
