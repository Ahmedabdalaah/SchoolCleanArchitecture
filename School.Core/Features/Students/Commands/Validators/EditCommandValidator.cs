using FluentValidation;
using School.Core.Features.Students.Commands.Models;
using School.Service.Abstracts;

namespace School.Core.Features.Students.Commands.Validators
{
    public class EditCommandValidator : AbstractValidator<EditStudentCommand>
    {
        #region Fields 
        private IStudentService _studentService;
        #endregion
        #region Constructor
        public EditCommandValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRule();
            ApplyCustomValidationRule();
        }
        #endregion
        #region Actions
        public void ApplyValidationRule()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Error , Name must not be empty ")
                .MaximumLength(50)
                .NotNull();
        }
        public void ApplyCustomValidationRule()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExistExclude(Key, model.Id))
                .WithMessage("Name is Exist");
        }
        #endregion
    }
}
