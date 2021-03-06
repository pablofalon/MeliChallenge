using MeliChallenge.API.DTOs;
using MeliChallenge.Domain;
using MeliChallenge.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MeliChallenge.API.Controllers
{
    [ApiController]
    [Route("/")]
    public class StarshipInfoController : ControllerBase
    {
        #region Const
        private const string ERROR_MESSAGE_INDETERMINADO = "No se ha podido determinar mensaje o posicion";
        private const string ERROR_MESSAGE_OBJETOERRONEO = "No se ha podido determinar mensaje o posicion";
        private const string ERROR_MESSAGE_FALTAINFO = "No se ha podido determinar mensaje o posicion";


        #endregion

        #region private members
        private readonly IDecodeInfoService _service;
        private readonly IList<MessagePositionInfo> listOfInfoFromSatellites;
        #endregion

        #region Constructor
        public StarshipInfoController(IDecodeInfoService service)
        {
            _service = service;
            listOfInfoFromSatellites = new List<MessagePositionInfo>();
        }
        #endregion

        #region endpoints
        [HttpPost("topsecret")]
        public ActionResult<MessageResponseDTO> GetInfo(MessageRequestDTO request)
        {
            if (request == null) return BadRequest(ERROR_MESSAGE_OBJETOERRONEO);
            if (request.Satellites.Count < 3) return BadRequest(ERROR_MESSAGE_FALTAINFO);

            foreach (var satellite in request.Satellites)
            {
                listOfInfoFromSatellites.Add(new MessagePositionInfo
                { Name = satellite.Name, Distance = satellite.Distance, message = satellite.Message });

            }
            var res = _service.GetInformationAboutStarship(listOfInfoFromSatellites);

            if (res == null || ((res.X == 0 && res.Y == 0) || string.IsNullOrWhiteSpace(res.Message)))
            {
                return BadRequest(ERROR_MESSAGE_INDETERMINADO);
            }

            return Ok(new MessageResponseDTO(res.X, res.Y, res.Message));

        }

        [HttpPost("topsecret_slip/{satelliteName}")]
        public ActionResult<MessageResponseDTO> GetInfoForSatellite([FromBody] SatelliteDTO request, string satelliteName)
        {
            var messageInfo = new MessagePositionInfo()
            {
                Name = satelliteName,
                message = request.Message,
                Distance = request.Distance,
            };

            var res = _service.GetInformationAboutSingleStarship(messageInfo);
            if (res != null)
            {
                if ((res.X == 0 && res.Y == 0) || res.Message == string.Empty)
                {
                    return BadRequest(ERROR_MESSAGE_INDETERMINADO);
                }

                return Ok(
                    new MessageResponseDTO(res.X, res.Y, res.Message)
                    );
            }
            return BadRequest(ERROR_MESSAGE_INDETERMINADO);
        }
        #endregion
    }
}
