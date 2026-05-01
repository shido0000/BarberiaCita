using API.Application.Dtos.Nomencladores.Origen;
using FluentValidation;

namespace API.Application.Validadotors.Nomencladores
{
    public class CrearOrigenDtoValidator : AbstractValidator<CrearOrigenInputDto>
    {

        public CrearOrigenDtoValidator()
        {
          /*  RuleFor(m => m.PermisoIds).NotEmpty().WithMessage("No puede ser una lista vacia.")
                                      .NotNull().WithMessage("Es un campo obligatorio.");
          */
        }
    }
}
