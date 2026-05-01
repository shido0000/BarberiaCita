using API.Data.Entidades;
using API.Data.IUnitOfWorks.Interfaces.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces.Seguridad;

namespace API.Data.IUnitOfWorks.Interfaces
{
    public interface IUnitOfWork<TEntity> : IDisposable where TEntity : EntidadBase
    {
        IPermisoRepository Permisos { get; }
        IRolPermisoRepository RolesPermisos { get; }
        IRolRepository Roles { get; }
        IUsuarioRepository Usuarios { get; }
        IBaseRepository<TEntity> BasicRepository { get; }
        ITrazaRepository Trazas { get; }

        ICategoriaRepository Categorias { get; }
        IOrigenRepository Origenes { get; }

        IGrupoRepository Grupos { get; }
        IFamiliaRepository Familias { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
