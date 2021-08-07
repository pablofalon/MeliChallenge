using MeliChallenge.Domain;
using System.Collections.Generic;

namespace MeliChallenge.Services.Interfaces
{
    public interface IDecodeInfoService
    {
        Spaceship GetInformationAboutStarship(IList<MessagePositionInfo> ListOfMessagePositionInfo);
        Spaceship GetInformationAboutSingleStarship(MessagePositionInfo messagePositionInfo);
    }
}
