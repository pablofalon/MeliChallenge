using MeliChallenge.Domain;
using MeliChallenge.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MeliChallenge.Services
{
    public class SatelliteRepository:ISatelliteRepository
    {
        public IList<Satellite> _list;
        public SatelliteRepository()
        {
            _list = new List<Satellite> {
            new Satellite{Name="Kenobi", Location=new Point{PositionX=4,PositionY=5 } },
            new Satellite{Name="Skywalker", Location=new Point{PositionX=4,PositionY=7, } },
            new Satellite{Name="Sato", Location=new Point{PositionX=5,PositionY=7 } }
            };
        }

        public IList<Satellite> GetAll() {
            return _list;
        }

        public void UpdateDistance(string Name, float updatedDistance)
        {
            var updated=_list.SingleOrDefault(x=>x.Name.ToLower()==Name.ToLower());
            updated.SavedDistance = updatedDistance;

        }

        public void UpdateInfo(string Name, float updatedDistance, string[] updatedMessage)
        {
            var updated = _list.SingleOrDefault(x => x.Name.ToLower() == Name.ToLower());
            updated.SavedDistance = updatedDistance;
            updated.SavedMessage = updatedMessage;
        }

        public void UpdateMessage(string Name, string[] updatedMessage)
        {
            var updated = _list.SingleOrDefault(x => x.Name == Name);
            updated.SavedMessage = updatedMessage;

        }
    }
}
