using System.Collections.Generic;

namespace EjemploApi.Common.Logic
{
    public class Usuario : IModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public override bool Equals(object obj)
        {
            var usuarioCasted = (Usuario)obj;

            return this.Id == usuarioCasted.Id
                && this.Nombre == usuarioCasted.Nombre
                && this.Apellidos == usuarioCasted.Apellidos;
        }

        public override int GetHashCode()
        {
            var hashCode = -624672384;
            hashCode = hashCode * -1521134295 + Id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Nombre);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Apellidos);
            return hashCode;
        }
    }
}
