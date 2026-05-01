using API.Data.Entidades.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using FluentValidation;

namespace API.Domain.Validators.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class CategoriaValidator : AbstractValidator<Categoria>
    {
        private readonly IUnitOfWork<Categoria> _repositorios;

        public CategoriaValidator(IUnitOfWork<Categoria> repositorios)
        {
            _repositorios = repositorios;


            RuleFor(m => m.Codigo).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                  .MaximumLength(1).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                  .NotNull().WithMessage("Es un campo obligatorio.")
                                  .Must(codigo => codigo.All(char.IsDigit) && codigo.Length == 1).WithMessage("Debe ser un carácter numérico entre 0 y 9.");

          
            RuleFor(m => m.Descripcion).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                     .MaximumLength(150).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                     .NotNull().WithMessage("Es un campo obligatorio.");

            RuleFor(m => m.TipoDeCodigo).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                        .NotNull().WithMessage("Es un campo obligatorio.");
                                  

            RuleFor(m => m).MustAsync(async (categoria, cancelacion) => await _repositorios.Categorias.AnyAsync(e => e.Id != categoria.Id && e.Codigo == categoria.Codigo))
                                 .WithMessage("Ya existe una categoría con ese código.");


        }

    }
}
