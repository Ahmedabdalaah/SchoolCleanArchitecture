using FluentValidation;
using School.Core.Features.Students.Commands.Models;

namespace School.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields 
        #endregion
        #region Constructor
        public AddStudentValidator()
        {
            ApplyValidationRule();
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
        #endregion

    }
}
