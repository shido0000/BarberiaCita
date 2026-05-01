using API.DTOs.Multibarbero;
using FluentValidation;

namespace API.Validators.Multibarbero
{
    public class CrearUsuarioClienteValidator : AbstractValidator<CrearUsuarioClienteDto>
    {
        public CrearUsuarioClienteValidator()
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

            RuleFor(x => x.FechaNacimiento)
                .LessThan(DateTime.Now.AddYears(-18)).WithMessage("El cliente debe ser mayor de 18 años");

            RuleFor(x => x.Genero)
                .MaximumLength(20).WithMessage("El género no puede exceder los 20 caracteres");
        }
    }

    public class ActualizarUsuarioClienteValidator : AbstractValidator<ActualizarUsuarioClienteDto>
    {
        public ActualizarUsuarioClienteValidator()
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

            RuleFor(x => x.FechaNacimiento)
                .LessThan(DateTime.Now.AddYears(-18)).WithMessage("El cliente debe ser mayor de 18 años");

            RuleFor(x => x.Genero)
                .MaximumLength(20).WithMessage("El género no puede exceder los 20 caracteres");
        }
    }
}
