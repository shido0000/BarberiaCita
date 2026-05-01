using API.DTOs.Multibarbero;
using FluentValidation;

namespace API.Validators.Multibarbero
{
    public class CrearReservaValidator : AbstractValidator<CrearReservaDto>
    {
        public CrearReservaValidator()
        {
            RuleFor(x => x.FechaHora)
                .GreaterThan(DateTime.Now).WithMessage("La fecha y hora deben ser futuras");

            RuleFor(x => x.DuracionMinutos)
                .GreaterThan(0).WithMessage("La duración debe ser mayor a 0 minutos");

            RuleFor(x => x.PrecioTotal)
                .GreaterThanOrEqualTo(0).WithMessage("El precio total debe ser mayor o igual a 0");

            RuleFor(x => x.ClienteId)
                .GreaterThan(0).WithMessage("El cliente es obligatorio");

            RuleFor(x => x.Notas)
                .MaximumLength(500).WithMessage("Las notas no pueden exceder los 500 caracteres");
        }
    }

    public class ActualizarReservaValidator : AbstractValidator<ActualizarReservaDto>
    {
        public ActualizarReservaValidator()
        {
            RuleFor(x => x.FechaHora)
                .GreaterThan(DateTime.Now.AddHours(-1)).WithMessage("La fecha y hora no pueden ser muy antiguas");

            RuleFor(x => x.DuracionMinutos)
                .GreaterThan(0).WithMessage("La duración debe ser mayor a 0 minutos");

            RuleFor(x => x.PrecioTotal)
                .GreaterThanOrEqualTo(0).WithMessage("El precio total debe ser mayor o igual a 0");

            RuleFor(x => x.Estado)
                .NotEmpty().WithMessage("El estado es obligatorio")
                .Must(estado => 
                    estado == "Pendiente" || 
                    estado == "Confirmada" || 
                    estado == "Cancelada" || 
                    estado == "Completada")
                .WithMessage("El estado debe ser uno de: Pendiente, Confirmada, Cancelada, Completada");

            RuleFor(x => x.Notas)
                .MaximumLength(500).WithMessage("Las notas no pueden exceder los 500 caracteres");
        }
    }

    public class CancelarReservaValidator : AbstractValidator<CancelarReservaDto>
    {
        public CancelarReservaValidator()
        {
            RuleFor(x => x.MotivoCancelacion)
                .MaximumLength(500).WithMessage("El motivo de cancelación no puede exceder los 500 caracteres");
        }
    }
}
