using MeliChallenge.Domain;
using MeliChallenge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MeliChallenge.Services
{
    public class LocationService:ILocationService
    {
        public static IList<Satellite> _list;
        public ISatelliteRepository _satelliteRepository;
        public LocationService(ISatelliteRepository satelliteRepository)
        {
            _satelliteRepository = satelliteRepository;
            _list = _satelliteRepository.GetAll();
        }
     
        #region Metodo de Trilateracion
        public static double[] CalculateDistance(Point p1, Point p2, Point p3)
        {
            double[] a = new double[3];
            double[] b = new double[3];
            double c, d, f, g, h;
            double[] i = new double[2];
            double k;
            c = p2.PositionX - p1.PositionX;
            d = p2.PositionY - p1.PositionY;
            f = (180 / Math.PI) * Math.Acos(Math.Abs(c) / Math.Abs(Math.Sqrt(Math.Pow(c, 2) + Math.Pow(d, 2))));
            if ((c > 0 && d > 0)) { f = 360 - f; }
            else if ((c < 0 && d > 0)) { f = 180 + f; }
            else if ((c < 0 && d < 0)) { f = 180 - f; }
            a = C(c, d, B(A(D(p2.Distance))), f);
            b = C(p3.PositionX - p1.PositionX, p3.PositionY - p1.PositionY, B(A(D(p3.Distance))), f);
            g = (Math.Pow(B(A(D(p1.Distance))), 2) - Math.Pow(a[2], 2) + Math.Pow(a[0], 2)) / (2 * a[0]);
            h = (Math.Pow(B(A(D(p1.Distance))), 2) - Math.Pow(b[2], 2) - Math.Pow(g, 2) + Math.Pow(g - b[0], 2) + Math.Pow(b[1], 2)) / (2 * b[1]);
            i = C(g, h, 0, -f);
            i[0] = i[0] + p1.PositionX - 0.086;
            i[1] = i[1] + p1.PositionY - 0.004;
            k = E(i[0], i[1], p1.PositionX, p1.PositionY);
            if (k > p1.Distance * 2) { i = null; }
            else
            {
                if (i[0] < -90 || i[0] > 90 || i[1] < -180 || i[1] > 180) { i = null; }
            }
            return i;
        }
        private static double A(double a) { return a * 7.2; }
        private static double B(double a) { return a / 900000; }
        private static double[] C(double a, double b, double c, double d) { return new double[] { a * Math.Cos((Math.PI / 180) * d) - b * Math.Sin((Math.PI / 180) * d), a * Math.Sin((Math.PI / 180) * d) + b * Math.Cos((Math.PI / 180) * d), c }; }
        private static double D(double a) { return 730.24198315 + 52.33325511 * a + 1.35152407 * Math.Pow(a, 2) + 0.01481265 * Math.Pow(a, 3) + 0.00005900 * Math.Pow(a, 4) + 0.00541703 * 180; }
        private static double E(double a, double b, double c, double d) { double e = Math.PI, f = e * a / 180, g = e * c / 180, h = b - d, i = e * h / 180, j = Math.Sin(f) * Math.Sin(g) + Math.Cos(f) * Math.Cos(g) * Math.Cos(i); if (j > 1) { j = 1; } j = Math.Acos(j); j = j * 180 / e; j = j * 60 * 1.1515; j = j * 1.609344; return j; }
        #endregion
        public float[] GetLocation(float[] Distances)
        {
            float[] coordinates = new float[2];

                var p1 = new Point()
            {
                PositionX = _list.SingleOrDefault(x => x.Name == "Kenobi").Location.PositionX,
                PositionY = _list.SingleOrDefault(x => x.Name == "Kenobi").Location.PositionY,
                Distance = Distances[0]
            };

            var p2 = new Point()
            {
                PositionX = _list.SingleOrDefault(x => x.Name == "Skywalker").Location.PositionX,
                PositionY = _list.SingleOrDefault(x => x.Name == "Skywalker").Location.PositionY,
                Distance = Distances[1]
            };

            var p3 = new Point()
            {
                PositionX = _list.SingleOrDefault(x => x.Name == "Sato").Location.PositionX,
                PositionY = _list.SingleOrDefault(x => x.Name == "Sato").Location.PositionY,
                Distance = Distances[2]
            };

            var res = CalculateDistance(p1, p2, p3);

            if (res != null)
            {
                float lat = Convert.ToSingle(res[0]);
                float Lng = Convert.ToSingle(res[1]);

                coordinates[0] = lat;
                coordinates[1] = Lng;
            }
            else 
            {
                coordinates[0] = 0;
                coordinates[1] = 0;
            }
            return coordinates;
        }
    }
       
}
