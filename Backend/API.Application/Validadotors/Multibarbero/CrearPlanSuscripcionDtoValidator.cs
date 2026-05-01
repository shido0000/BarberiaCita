using FluentValidation;
using API.Application.Dtos.Multibarbero.PlanSuscripcion;

namespace API.Application.Validadotors.Multibarbero
{
    public class CrearPlanSuscripcionDtoValidator : AbstractValidator<CrearPlanSuscripcionInputDto>
    {
        public CrearPlanSuscripcionDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder 100 caracteres");

            RuleFor(x => x.Descripcion)
                .NotEmpty().WithMessage("La descripción es obligatoria")
                .MaximumLength(500).WithMessage("La descripción no puede exceder 500 caracteres");

            RuleFor(x => x.Precio)
                .GreaterThanOrEqualTo(0).WithMessage("El precio debe ser mayor o igual a 0");

            RuleFor(x => x.DuracionDias)
                .GreaterThan(0).WithMessage("La duración debe ser mayor a 0 días");

            RuleFor(x => x.LimiteBarberosAfiliados)
                .GreaterThan(0).When(x => x.EsParaBarberia)
                .WithMessage("Las barberías deben tener un límite de barberos afiliados");
        }
    }
}
