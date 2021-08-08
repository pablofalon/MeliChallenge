using MeliChallenge.API.DTOs;
using MeliChallenge.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeliChallenge.Test
{
    public static class FakeData
    {
        public static MessageRequestDTO GetValidMessageRequestInputData()
        {
            return new MessageRequestDTO() {
                Satellites = new List<SatelliteDTO>()
                     {
                       new SatelliteDTO { Distance = 15,Name="Kunabi",Message =new string[5]{"Hola","","","","mensaje" } },
                       new SatelliteDTO { Distance = 15,Name="Skywalker",Message =new string[5]{"Hola","es","","","mensaje" } },
                       new SatelliteDTO { Distance = 15,Name="Sato",Message =new string[5]{"Hola","","","","mensaje" } }
                     }
            };
            
        }

        public static MessageRequestDTO GetInvalidMessageRequestInputData()
        {
            return new MessageRequestDTO()
            {
                Satellites = new List<SatelliteDTO>()
                     {
                       new SatelliteDTO { Distance = 15,Name="Kunabi",Message =new string[5]{"","","","","" } },
                       new SatelliteDTO { Distance = 15,Name="Skywalker",Message =new string[5]{"","","","","mensaje" } },
                       new SatelliteDTO { Distance = 15,Name="Sato",Message =new string[5]{"","","","","" } }
                     }
            };

        }

        public static IList<MessagePositionInfo> GetMessagePositionInfoInputData()
        {
            return new List<MessagePositionInfo>
            {
                new MessagePositionInfo(){ Distance = 15,Name="Sato",message =new string[5]{"Hola","","","","mensaje" }},
                new MessagePositionInfo(){ Distance = 15,Name="Sato",message =new string[5]{"Hola","","","","mensaje" }},
                new MessagePositionInfo(){ Distance = 15,Name="Sato",message =new string[5]{"Hola","","","","mensaje" }}
            };
        }

        public static Spaceship GetValidSpaceship()
        {
            return new Spaceship(4f, 2.1f, "Mensaje Valido");
        }
    }
}
