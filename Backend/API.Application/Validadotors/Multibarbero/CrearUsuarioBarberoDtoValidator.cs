using FluentValidation;
using API.Application.Dtos.Multibarbero.UsuarioBarbero;

namespace API.Application.Validadotors.Multibarbero
{
    public class CrearUsuarioBarberoDtoValidator : AbstractValidator<CrearUsuarioBarberoInputDto>
    {
        public CrearUsuarioBarberoDtoValidator()
        {
            RuleFor(x => x.UsuarioId)
                .NotEmpty().WithMessage("El usuario es obligatorio");

            RuleFor(x => x.Biografia)
                .MaximumLength(1000).WithMessage("La biografía no puede exceder 1000 caracteres");

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede exceder 20 caracteres");
        }
    }
}
