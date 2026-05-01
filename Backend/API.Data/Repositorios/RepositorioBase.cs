using API.Data.DbContexts;
using API.Data.IUnitOfWorks.Repositorios;
using API.Dominio.Entidades.Multibarbero;

namespace API.Data.Repositorios
{
    /// <summary>
    /// Clase base para repositorios de entidades Multibarbero
    /// </summary>
    public class RepositorioBase<TEntity> : BaseRepository<TEntity>, IRepositorioBase<TEntity> where TEntity : EntidadBaseMultibarbero
    {
        public RepositorioBase(ApiDbContext context) : base(context)
        {
        }
    }
}
