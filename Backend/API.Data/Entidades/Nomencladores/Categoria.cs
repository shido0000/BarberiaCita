using API.Data.Entidades.Seguridad;
using API.Data.Enum.Nomencladores;

namespace API.Data.Entidades.Nomencladores
{
    /// <summary>
    /// Tabla que guarda datos de las categorias
    /// </summary>
    public class Categoria : EntidadBase
    {
        public required string Codigo { get; set; }

        public required string Descripcion { get; set; }
        public required TipoDeCodigo TipoDeCodigo { get; set; }
 
        public required bool Reservado { get; set; } = true;
        public required bool Activo { get; set; } = true;

        public List<Origen> Origenes { get; set; } = new();

    }
}