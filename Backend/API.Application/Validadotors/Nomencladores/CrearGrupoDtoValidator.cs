using API.Application.Dtos.Nomencladores.Grupo;
using FluentValidation;

namespace API.Application.Validadotors.Nomencladores
{
    public class CrearGrupoDtoValidator : AbstractValidator<CrearGrupoInputDto>
    {

        public CrearGrupoDtoValidator()
        {
            /*  RuleFor(m => m.PermisoIds).NotEmpty().WithMessage("No puede ser una lista vacia.")
                                        .NotNull().WithMessage("Es un campo obligatorio.");
            */

            
        }
    }
}
