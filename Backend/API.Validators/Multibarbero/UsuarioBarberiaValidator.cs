using API.DTOs.Multibarbero;
using FluentValidation;

namespace API.Validators.Multibarbero
{
    public class CrearUsuarioBarberiaValidator : AbstractValidator<CrearUsuarioBarberiaDto>
    {
        public CrearUsuarioBarberiaValidator()
        {
            RuleFor(x => x.NombreComercial)
                .NotEmpty().WithMessage("El nombre comercial es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("El email no tiene un formato válido")
                .MaximumLength(100).WithMessage("El email no puede exceder los 100 caracteres");

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede exceder los 20 caracteres");

            RuleFor(x => x.Direccion)
                .MaximumLength(200).WithMessage("La dirección no puede exceder los 200 caracteres");

            RuleFor(x => x.Ciudad)
                .MaximumLength(100).WithMessage("La ciudad no puede exceder los 100 caracteres");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres");
        }
    }

    public class ActualizarUsuarioBarberiaValidator : AbstractValidator<ActualizarUsuarioBarberiaDto>
    {
        public ActualizarUsuarioBarberiaValidator()
        {
            RuleFor(x => x.NombreComercial)
                .NotEmpty().WithMessage("El nombre comercial es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio")
                .EmailAddress().WithMessage("El email no tiene un formato válido")
                .MaximumLength(100).WithMessage("El email no puede exceder los 100 caracteres");

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede exceder los 20 caracteres");

            RuleFor(x => x.Direccion)
                .MaximumLength(200).WithMessage("La dirección no puede exceder los 200 caracteres");

            RuleFor(x => x.Ciudad)
                .MaximumLength(100).WithMessage("La ciudad no puede exceder los 100 caracteres");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres");
        }
    }
}
