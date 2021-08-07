using MeliChallenge.Domain;
using System.Collections.Generic;

namespace MeliChallenge.Services.Interfaces
{
    public interface ISatelliteRepository
    {
        IList<Satellite> GetAll();
        void UpdateInfo(string Name, float distance, string[] message);
    }
}
