using FluentValidation;
using TaskManager.API.Application.DTOs;

namespace TaskManager.API.Application.Validators;

public class CreateTaskDtoValidator : AbstractValidator<CreateTaskDto>
{
    public CreateTaskDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title boş olamaz")
            .MinimumLength(3).WithMessage("Title en az 3 karakter olmalıdır");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description en fazla 500 karakter olabilir");
    }
}
