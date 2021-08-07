using System;
using System.Collections.Generic;
using System.Text;

namespace MeliChallenge.Services.Interfaces
{
    public interface ILocationService
    {
        float[] GetLocation(float[] Distances);
    }
}
