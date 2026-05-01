using API.DTOs.Multibarbero;
using FluentValidation;

namespace API.Validators.Multibarbero
{
    public class CrearPlanSuscripcionValidator : AbstractValidator<CrearPlanSuscripcionDto>
    {
        public CrearPlanSuscripcionValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del plan es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres");

            RuleFor(x => x.Precio)
                .GreaterThanOrEqualTo(0).WithMessage("El precio debe ser mayor o igual a 0");

            RuleFor(x => x.DuracionDias)
                .GreaterThan(0).WithMessage("La duración debe ser mayor a 0 días");

            RuleFor(x => x.TipoPeriodo)
                .NotEmpty().WithMessage("El tipo de período es obligatorio");

            RuleFor(x => x.MaxBarberos)
                .GreaterThan(0).WithMessage("El máximo de barberos debe ser mayor a 0");

            RuleFor(x => x.MaxReservasDia)
                .GreaterThan(0).WithMessage("El máximo de reservas por día debe ser mayor a 0");
        }
    }

    public class ActualizarPlanSuscripcionValidator : AbstractValidator<ActualizarPlanSuscripcionDto>
    {
        public ActualizarPlanSuscripcionValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del plan es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres");

            RuleFor(x => x.Precio)
                .GreaterThanOrEqualTo(0).WithMessage("El precio debe ser mayor o igual a 0");

            RuleFor(x => x.DuracionDias)
                .GreaterThan(0).WithMessage("La duración debe ser mayor a 0 días");

            RuleFor(x => x.TipoPeriodo)
                .NotEmpty().WithMessage("El tipo de período es obligatorio");

            RuleFor(x => x.MaxBarberos)
                .GreaterThan(0).WithMessage("El máximo de barberos debe ser mayor a 0");

            RuleFor(x => x.MaxReservasDia)
                .GreaterThan(0).WithMessage("El máximo de reservas por día debe ser mayor a 0");
        }
    }
}
