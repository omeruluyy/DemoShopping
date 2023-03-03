using DemoShopping.Models;
using FluentValidation;

namespace DemoShopping.Validators
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Boş bırakılamaz")
                
                ;
            
        }
    }
}
