using API.DTOs.Multibarbero;
using FluentValidation;

namespace API.Validators.Multibarbero
{
    public class CrearServicioValidator : AbstractValidator<CrearServicioDto>
    {
        public CrearServicioValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del servicio es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres");

            RuleFor(x => x.Precio)
                .GreaterThanOrEqualTo(0).WithMessage("El precio debe ser mayor o igual a 0");

            RuleFor(x => x.DuracionMinutos)
                .GreaterThan(0).WithMessage("La duración debe ser mayor a 0 minutos");

            RuleFor(x => x.Categoria)
                .MaximumLength(50).WithMessage("La categoría no puede exceder los 50 caracteres");
        }
    }

    public class ActualizarServicioValidator : AbstractValidator<ActualizarServicioDto>
    {
        public ActualizarServicioValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del servicio es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres");

            RuleFor(x => x.Precio)
                .GreaterThanOrEqualTo(0).WithMessage("El precio debe ser mayor o igual a 0");

            RuleFor(x => x.DuracionMinutos)
                .GreaterThan(0).WithMessage("La duración debe ser mayor a 0 minutos");

            RuleFor(x => x.Categoria)
                .MaximumLength(50).WithMessage("La categoría no puede exceder los 50 caracteres");
        }
    }
}
