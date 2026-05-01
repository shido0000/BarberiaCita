using API.Data.Entidades.Nomencladores;
using API.Data.IUnitOfWorks.Interfaces;
using FluentValidation;

namespace API.Domain.Validators.Nomencladores
{
    /// <summary>
    /// Valida que los datos de la entidad esten correctos antes de ser insertados a la BD
    /// </summary>
    public class GrupoValidator : AbstractValidator<Grupo>
    {
        private readonly IUnitOfWork<Grupo> _repositorios;

        public GrupoValidator(IUnitOfWork<Grupo> repositorios)
        {
            _repositorios = repositorios;


            RuleFor(m => m.Codigo).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                  .MaximumLength(2).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                  .NotNull().WithMessage("Es un campo obligatorio.");
            // .Must(codigo => codigo.All(char.IsDigit) && codigo.Length == 2).WithMessage("Debe ser 2 carácteres numérico.");



            RuleFor(m => m.Descripcion).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                     .MaximumLength(150).WithMessage("Debe tener {MaxLength} caracteres máximo.")
                                     .NotNull().WithMessage("Es un campo obligatorio.");

            RuleFor(m => m.TipoDeGrupo).NotEmpty().WithMessage("No puede ser un texto vacio.")
                                       .NotNull().WithMessage("Es un campo obligatorio.");

            RuleFor(m => m.Desgaste).NotNull().WithMessage("Es un campo obligatorio.")
                                    .Must(desgaste => desgaste >= 0 && desgaste <= 100).WithMessage("El desgaste debe estar entre 0 y 100.");


            RuleFor(m => m).MustAsync(async (grupo, cancelacion) => await _repositorios.Grupos.AnyAsync(e => e.Id != grupo.Id && e.Codigo == grupo.Codigo))
                                 .WithMessage("Ya existe un grupo con ese código.");
        }

    }
}
