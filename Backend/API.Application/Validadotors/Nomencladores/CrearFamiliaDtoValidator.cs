using API.Application.Dtos.Nomencladores.Categoria;
using FluentValidation;

namespace API.Application.Validadotors.Nomencladores
{
    public class CrearFamiliaDtoValidator : AbstractValidator<CrearCategoriaInputDto>
    {

        public CrearFamiliaDtoValidator()
        {
          /*  RuleFor(m => m.PermisoIds).NotEmpty().WithMessage("No puede ser una lista vacia.")
                                      .NotNull().WithMessage("Es un campo obligatorio.");
          */
        }
    }
}
