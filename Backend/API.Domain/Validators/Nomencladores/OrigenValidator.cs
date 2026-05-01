using API.Data.Entidades.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using FluentValidation;

namespace API.Domain.Validators.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class OrigenValidator : AbstractValidator<Origen>
    {
        private readonly IUnitOfWork<Origen> _repositorios;

        public OrigenValidator(IUnitOfWork<Origen> repositorios)
        {
            _repositorios = repositorios;


            RuleFor(m => m.Codigo).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                  .MaximumLength(1).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                  .NotNull().WithMessage("Es un campo obligatorio.")
                                  .Must(codigo => codigo.All(char.IsDigit) && codigo.Length >= 1 && codigo.Length <= 8).WithMessage("Debe ser un carácter numérico entre 1 y 8.");



            RuleFor(m => m.Descripcion).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                     .MaximumLength(50).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                     .NotNull().WithMessage("Es un campo obligatorio.");

            RuleFor(m => m.Tipo).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                .NotNull().WithMessage("Es un campo obligatorio.");
                                  


            RuleFor(m => m).MustAsync(async (origen, cancelacion) => await _repositorios.Origenes.AnyAsync(e => e.Id != origen.Id && e.Codigo == origen.Codigo))
                                        .WithMessage("Ya existe un origen con ese código.");
        }

    }
}
