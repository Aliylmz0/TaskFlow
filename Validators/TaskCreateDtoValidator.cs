using FluentValidation;
using TaskFlow.DTOs;

namespace TaskFlow.Validators
{
    public class TaskCreateDtoValidator : AbstractValidator<TaskCreateDto>
    {
        public TaskCreateDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MaximumLength(100);

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Kullanıcı bilgisi zorunludur.");
        }
    }
}