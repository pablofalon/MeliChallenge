namespace MeliChallenge.Domain
{
    public class Spaceship
    {
        public float X { get; set; }
        public float Y { get; set; }
        public string Message { get; set; }

        public Spaceship(float x, float y, string message)
        {
            X = x;
            Y = y;
            Message = message;
        }
    }
}
