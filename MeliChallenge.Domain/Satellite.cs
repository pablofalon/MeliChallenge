namespace MeliChallenge.Domain

{
    public class Satellite
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public float SavedDistance { get; set; }
        public string[] SavedMessage { get; set; }
    }
}
