using API.DTOs.Multibarbero;
using FluentValidation;

namespace API.Validators.Multibarbero
{
    public class CrearRolMultibarberoValidator : AbstractValidator<CrearRolMultibarberoDto>
    {
        public CrearRolMultibarberoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del rol es obligatorio")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres");

            RuleFor(x => x.Descripcion)
                .MaximumLength(200).WithMessage("La descripción no puede exceder los 200 caracteres");
        }
    }

    public class ActualizarRolMultibarberoValidator : AbstractValidator<ActualizarRolMultibarberoDto>
    {
        public ActualizarRolMultibarberoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del rol es obligatorio")
                .MaximumLength(50).WithMessage("El nombre no puede exceder los 50 caracteres");

            RuleFor(x => x.Descripcion)
                .MaximumLength(200).WithMessage("La descripción no puede exceder los 200 caracteres");
        }
    }
}
