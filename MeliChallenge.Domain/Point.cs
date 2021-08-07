namespace MeliChallenge.Domain
{
    public class Point
    {
        public double PositionX { get; set; }
        public double PositionY { get; set; }
        public double Distance { get; set; }

        public Point()
        {

        }
        public Point(double positionX, double positionY, double distance)
        {
            PositionX = positionX;
            PositionY = positionY;
            Distance = distance;
        }
    }
}
