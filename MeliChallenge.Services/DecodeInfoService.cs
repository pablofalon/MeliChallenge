using MeliChallenge.Domain;
using MeliChallenge.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MeliChallenge.Services
{
    public class DecodeInfoService : IDecodeInfoService
    {
        private const string KENOBI = "Kenobi";
        private const string SKYWALKER = "Skywalker";
        private const string SATO = "Sato";

        public static IList<Satellite> _list;
        public readonly ILocationService _locationService;
        public readonly IMessageService _messageService;
        public readonly ISatelliteRepository _satelliteRepository;

        public DecodeInfoService(ILocationService locationService, IMessageService messageService, ISatelliteRepository satelliteRepository)
        {
            _satelliteRepository = satelliteRepository;
             _locationService = locationService;
            _messageService = messageService;

        }

        /// <summary>
        /// Este metodo recupera la posicion y mensaje en base a toda la informacion recibida desde todos los satelites
        /// </summary>
        /// <param name="messagePositionInfo"></param>
        /// <returns></returns>
        public Spaceship GetInformationAboutSingleStarship(MessagePositionInfo messagePositionInfo)
        {
            float[] distances = new float[3];
            float[] finalLocation = new float[2];            
            string finalString = string.Empty;
            string[] mensaje1, mensaje2, mensaje3 = new string[5];


            var satellite = messagePositionInfo.Name;
            var anotherSatelliteInfo = _satelliteRepository.GetAll().Where(x => x.Name != satellite).ToList();

            if (anotherSatelliteInfo.Any(x=>x.SavedDistance==0))
            {
                return null;
            }

            //Actualiza la info en el repositorio 
            _satelliteRepository.UpdateDistance(messagePositionInfo.Name, messagePositionInfo.Distance);
            _satelliteRepository.UpdateMessage(messagePositionInfo.Name, messagePositionInfo.message);

            distances[0] = messagePositionInfo.Distance;

            int i = 0;
            foreach (var item in _satelliteRepository.GetAll())
            {
                distances[i] = item.SavedDistance;
                i++;
            }                

            mensaje1 = _satelliteRepository.GetAll().SingleOrDefault(x => x.Name == KENOBI).SavedMessage;
            mensaje2 = _satelliteRepository.GetAll().SingleOrDefault(x => x.Name == SKYWALKER).SavedMessage;
            mensaje3 = _satelliteRepository.GetAll().SingleOrDefault(x => x.Name == SATO).SavedMessage;

            //Resolucion de Informacion
            finalLocation = _locationService.GetLocation(distances);
            finalString = _messageService.GetMessage(mensaje1,mensaje2,mensaje3);

            var spaceShip = new Spaceship(finalLocation[0], finalLocation[1], finalString);      
            return spaceShip;
                
        }
        /// <summary>
        /// Este metodo recupera la posicion y el mensaje de la nave en base a la informacion enviada y la guardada en el repositorio
        /// </summary>
        /// <param name="ListOfMessagePositionInfo"></param>
        /// <returns></returns>
        public Spaceship GetInformationAboutStarship(IList<MessagePositionInfo> ListOfMessagePositionInfo)
        {
            float[] distances= new float[3];
            float[] finalLocation;
            string finalString;

            int i = 0;
            foreach (var item in ListOfMessagePositionInfo)
            {
                distances[i] = item.Distance;
                i++;
            }
           
            finalLocation= _locationService.GetLocation(distances);

            finalString = _messageService.GetMessage(ListOfMessagePositionInfo[0].message,
                ListOfMessagePositionInfo[1].message,
                ListOfMessagePositionInfo[2].message);

            //Actualizar informacion del repositorio
            foreach (var info in ListOfMessagePositionInfo)
            {
                _satelliteRepository.UpdateDistance(info.Name, info.Distance);
                _satelliteRepository.UpdateMessage(info.Name, info.message);
            }

            var spaceShip = new Spaceship(finalLocation[0], finalLocation[1], finalString);
            return spaceShip;
        }


    }
}
