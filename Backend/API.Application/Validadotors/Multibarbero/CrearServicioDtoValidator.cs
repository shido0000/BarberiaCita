using FluentValidation;
using API.Application.Dtos.Multibarbero.Servicio;

namespace API.Application.Validadotors.Multibarbero
{
    public class CrearServicioDtoValidator : AbstractValidator<CrearServicioInputDto>
    {
        public CrearServicioDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

            RuleFor(x => x.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor a 0");

            RuleFor(x => x.DuracionMinutos)
                .GreaterThan(0).WithMessage("La duración debe ser mayor a 0 minutos");

            RuleFor(x => x)
                .Must(x => x.UsuarioBarberoId.HasValue || x.UsuarioBarberiaId.HasValue)
                .WithMessage("Debe especificar un barbero o una barbería para el servicio");
        }
    }
}
