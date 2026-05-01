using API.Application.Dtos.Nomencladores.Categoria;
using FluentValidation;

namespace API.Application.Validadotors.Nomencladores
{
    public class CrearCategoriaDtoValidator : AbstractValidator<CrearCategoriaInputDto>
    {

        public CrearCategoriaDtoValidator()
        {
          /*  RuleFor(m => m.PermisoIds).NotEmpty().WithMessage("No puede ser una lista vacia.")
                                      .NotNull().WithMessage("Es un campo obligatorio.");
          */
        }
    }
}
