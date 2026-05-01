using API.Data.Entidades.Nomencladores;
using API.Domain.Validators.Nomencladores;
using Microsoft.EntityFrameworkCore.Query;

namespace API.Domain.Interfaces.Nomencladores
{
    public interface ICategoriaService : IBaseService<Categoria, CategoriaValidator>
    {
   
    }
}