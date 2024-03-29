﻿using FluentValidation;
using School.Core.Features.Students.Commands.Models;
using School.Service.Abstracts;

namespace School.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields 
        private readonly IStudentService _studentService;
        #endregion
        #region Constructor
        public AddStudentValidator(IStudentService studentService)
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
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
                .WithMessage("Name is exist");
        }
        #endregion

    }
}
