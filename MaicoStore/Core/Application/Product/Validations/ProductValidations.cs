using Application.Product.DTO;
using FluentValidation;

namespace Application.Product.Validations
{
    public class ProductValidations : AbstractValidator<ProductDTO>
    {
        public ProductValidations()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(10);
            RuleFor(x => x.Price)
                .NotNull()
                .GreaterThanOrEqualTo(1);
            RuleFor(x => x.ImageUrl)
                .NotEmpty();
            RuleFor(x => x.ReleaseDate)
                .NotNull();
        }
    }
}
