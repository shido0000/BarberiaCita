using API.DTOs.Multibarbero;
using FluentValidation;

namespace API.Validators.Multibarbero
{
    public class CrearUsuarioBarberoValidator : AbstractValidator<CrearUsuarioBarberoDto>
    {
        public CrearUsuarioBarberoValidator()
        {
            RuleFor(x => x.NombreCompleto)
                .NotEmpty().WithMessage("El nombre completo es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("El email no tiene un formato válido")
                .MaximumLength(100).WithMessage("El email no puede exceder los 100 caracteres");

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede exceder los 20 caracteres");

            RuleFor(x => x.Especialidad)
                .MaximumLength(100).WithMessage("La especialidad no puede exceder los 100 caracteres");

            RuleFor(x => x.PrecioBase)
                .GreaterThanOrEqualTo(0).WithMessage("El precio base debe ser mayor o igual a 0");
        }
    }

    public class ActualizarUsuarioBarberoValidator : AbstractValidator<ActualizarUsuarioBarberoDto>
    {
        public ActualizarUsuarioBarberoValidator()
        {
            RuleFor(x => x.NombreCompleto)
                .NotEmpty().WithMessage("El nombre completo es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("El email no tiene un formato válido")
                .MaximumLength(100).WithMessage("El email no puede exceder los 100 caracteres");

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede exceder los 20 caracteres");

            RuleFor(x => x.Especialidad)
                .MaximumLength(100).WithMessage("La especialidad no puede exceder los 100 caracteres");

            RuleFor(x => x.PrecioBase)
                .GreaterThanOrEqualTo(0).WithMessage("El precio base debe ser mayor o igual a 0");
        }
    }
}
