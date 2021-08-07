using MeliChallenge.Domain;
using System.Collections.Generic;

namespace MeliChallenge.Services.Interfaces
{
    public interface ISatelliteRepository
    {
        IList<Satellite> GetAll();
        void UpdateDistance(string Name, float updatedDistance);
        void UpdateMessage(string Name, string[] updatedMessage);
    }
}
