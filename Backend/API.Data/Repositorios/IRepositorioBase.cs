using API.Data.IUnitOfWorks.Interfaces;
using API.Dominio.Entidades.Multibarbero;

namespace API.Data.Repositorios
{
    /// <summary>
    /// Alias para IBaseRepository específico para entidades Multibarbero
    /// </summary>
    public interface IRepositorioBase<TEntity> : IBaseRepository<TEntity> where TEntity : EntidadBaseMultibarbero
    {
    }
}
