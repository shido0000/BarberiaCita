namespace API.Data.Entidades.Nomencladores
{
    /// <summary>
    /// Tabla que guarda datos de las categorias
    /// </summary>
    public class Origen : EntidadBase
    {
        public required string Codigo { get; set; }

        public required string Descripcion { get; set; }
        public required char Tipo { get; set; }
 
        public bool Reservado { get; set; } = false;
        public required bool Activo { get; set; } = true;

        public required Guid CategoriaId { get; set; }
        public required Categoria Categoria { get; set; } = null!;

        public List<Grupo> Grupos { get; set; } = new();

    }
}