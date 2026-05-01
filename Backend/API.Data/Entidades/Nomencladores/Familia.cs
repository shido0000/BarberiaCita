using API.Data.Enum.Nomencladores;

namespace API.Data.Entidades.Nomencladores
{
    /// <summary>
    /// Tabla que guarda datos de las Familias
    /// </summary>
    public class Familia : EntidadBase
    {
        public required string codigo;

        public required string Codigo { get => codigo.PadLeft(2, '0'); set => codigo = value; }

        public required string Descripcion { get; set; }
      
        public required bool Reservado { get; set; }
        public required bool Activo { get; set; } = true;

        public required Guid GrupoId { get; set; }
        public Grupo Grupo { get; set; } = null!;

        /*  public required Guid EspecialidadId { get; set; }
          public Especialidad Especialidad { get; set; } = null!;*/

    }
}