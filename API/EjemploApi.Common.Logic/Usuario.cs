namespace EjemploApi.Common.Logic
{
    public class Usuario : IModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
    }
}
