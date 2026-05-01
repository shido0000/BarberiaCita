using API.Data.Entidades.Seguridad;
using API.Data.Enum.Nomencladores;

namespace API.Data.Entidades.Nomencladores
{
    /// <summary>
    /// Tabla que guarda datos de los grupos
    /// </summary>
    public class Grupo : EntidadBase
    {
        public required string codigo;

        public required string Codigo { get => codigo.PadLeft(2, '0'); set => codigo = value; }

        public required string Descripcion { get; set; }
        public required TipoDeGrupo TipoDeGrupo { get; set; }

        public required decimal Desgaste { get; set; }

        public required bool Reservado { get; set; } = false;
        public required bool Activo { get; set; } = true;

        public required Guid OrigenId { get; set; }
        public Origen Origen { get; set; } = null!;

        public List<Familia> Familias { get; set; } = new();

    }
}