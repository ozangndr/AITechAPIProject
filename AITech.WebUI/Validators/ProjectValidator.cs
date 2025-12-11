using AITech.WebUI.DTOs.ProjectDtos;
using FluentValidation;

namespace AITech.WebUI.Validators
{
    public class ProjectValidator : AbstractValidator<CreateProjectDto>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Proje başlığı boş geçilemez.");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Lütfen geçerli bir kategori seçiniz.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Proje görseli boş geçilemez.");
        }
    }
}
