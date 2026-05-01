using API.Data.Entidades.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using FluentValidation;

namespace API.Domain.Validators.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class FamiliaValidator : AbstractValidator<Familia>
    {
        private readonly IUnitOfWork<Familia> _repositorios;

        public FamiliaValidator(IUnitOfWork<Familia> repositorios)
        {
            _repositorios = repositorios;


            RuleFor(m => m.Codigo).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                  .MaximumLength(2).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                  .NotNull().WithMessage("Es un campo obligatorio.")
                                 // .Must(codigo => codigo.All(char.IsDigit) && codigo.Length <= 3).WithMessage("Debe ser un carácter numérico entre 2 dígitos.");
                                 .Must((model, codigo) => codigo.All(char.IsDigit) && (codigo.Length == 2 || (codigo.Length == 1 && codigo.StartsWith("0"))))
                                 .WithMessage("Debe ser un carácter numérico de 2 dígitos o rellenarse con un '0' a la izquierda si es un solo dígito.");

            RuleFor(m => m.Descripcion).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                     .MaximumLength(50).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                     .NotNull().WithMessage("Es un campo obligatorio.");                                  


            RuleFor(m => m).MustAsync(async (familia, cancelacion) => await _repositorios.Familias.AnyAsync(e => e.Id != familia.Id && e.Codigo == familia.Codigo))
                                 .WithMessage("Ya existe una familia con ese código.");

        }

    }
}
