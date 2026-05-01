using API.DTOs.Multibarbero;
using FluentValidation;

namespace API.Validators.Multibarbero
{
    public class CrearProductoValidator : AbstractValidator<CrearProductoDto>
    {
        public CrearProductoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres");

            RuleFor(x => x.Precio)
                .GreaterThanOrEqualTo(0).WithMessage("El precio debe ser mayor o igual a 0");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock debe ser mayor o igual a 0");

            RuleFor(x => x.Categoria)
                .MaximumLength(50).WithMessage("La categoría no puede exceder los 50 caracteres");

            RuleFor(x => x.Marca)
                .MaximumLength(100).WithMessage("La marca no puede exceder los 100 caracteres");
        }
    }

    public class ActualizarProductoValidator : AbstractValidator<ActualizarProductoDto>
    {
        public ActualizarProductoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre del producto es obligatorio")
                .MaximumLength(100).WithMessage("El nombre no puede exceder los 100 caracteres");

            RuleFor(x => x.Descripcion)
                .MaximumLength(500).WithMessage("La descripción no puede exceder los 500 caracteres");

            RuleFor(x => x.Precio)
                .GreaterThanOrEqualTo(0).WithMessage("El precio debe ser mayor o igual a 0");

            RuleFor(x => x.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("El stock debe ser mayor o igual a 0");

            RuleFor(x => x.Categoria)
                .MaximumLength(50).WithMessage("La categoría no puede exceder los 50 caracteres");

            RuleFor(x => x.Marca)
                .MaximumLength(100).WithMessage("La marca no puede exceder los 100 caracteres");
        }
    }
}
