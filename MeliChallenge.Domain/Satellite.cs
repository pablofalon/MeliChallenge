namespace MeliChallenge.Domain

{
    public class Satellite
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        //Campo para salvar la distancia a medida que se fueron realizando las consultas
        public float SavedDistance { get; set; }
        //Campo para salvar el mensaje a medida que se fueron realizando las consultas
        public string[] SavedMessage { get; set; }
    }
}
