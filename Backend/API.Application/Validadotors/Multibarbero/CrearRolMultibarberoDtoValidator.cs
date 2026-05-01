using FluentValidation;
using API.Application.Dtos.Multibarbero.RolMultibarbero;

namespace API.Application.Validators.Multibarbero
{
    public class CrearRolMultibarberoDtoValidator : AbstractValidator<CrearRolMultibarberoInputDto>
    {
        public CrearRolMultibarberoDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres");
        }
    }
}
