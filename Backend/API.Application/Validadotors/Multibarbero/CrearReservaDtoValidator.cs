using FluentValidation;
using API.Application.Dtos.Multibarbero.Reserva;

namespace API.Application.Validadotors.Multibarbero
{
    public class CrearReservaDtoValidator : AbstractValidator<CrearReservaInputDto>
    {
        public CrearReservaDtoValidator()
        {
            RuleFor(x => x.UsuarioClienteId)
                .NotEmpty().WithMessage("El cliente es obligatorio");

            RuleFor(x => x.ServicioId)
                .NotEmpty().WithMessage("El servicio es obligatorio");

            RuleFor(x => x.FechaInicio)
                .NotEmpty().WithMessage("La fecha de inicio es obligatoria")
                .GreaterThan(DateTime.Now).WithMessage("La fecha de inicio debe ser futura");

            RuleFor(x => x)
                .Must(x => x.UsuarioBarberoId.HasValue || x.UsuarioBarberiaId.HasValue)
                .WithMessage("Debe especificar un barbero o una barbería");
        }
    }
}
