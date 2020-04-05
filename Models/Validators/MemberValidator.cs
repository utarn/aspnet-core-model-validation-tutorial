using System;
using FluentValidation;
using model_validation_tutorial.Services;

namespace model_validation_tutorial.Models.Validators
{
    public class MemberValidator : AbstractValidator<Member>
    {
        private readonly IDateTimeService _dateTimeService;
        public MemberValidator(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
            RuleFor(m => m.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("รหัสสมาชิกห้ามว่าง")
                .GreaterThanOrEqualTo(1)
                .WithMessage("รหัสสมาชิกควรมากกว่า 1");
            RuleFor(m => m.FirstName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("ชื่อห้ามว่าง")
                .MinimumLength(4)
                .WithMessage("ชื่อควรมีความยาวไม่น้อยกว่า 4 ตัวอักษร");
            RuleFor(m => m.LastName)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("นามสกุลห้ามว่าง")
                .MinimumLength(4)
                .WithMessage("นามสกุลควรมีความยาวไม่น้อยกว่า 4 ตัวอักษร");
            RuleFor(m => m.Email)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("อีเมลห้ามว่าง")
                .EmailAddress()
                .WithMessage("อีเมลที่กรอกไม่ถูกต้อง");
            RuleFor(m => m.DateOfBirth)
                .NotEmpty()
                .WithMessage("วันเกิดห้ามว่าง")
                .Must(m => AgeQualify(m))
                .WithMessage("อายุต่ำกว่า 18 ปีบริบูรณ์ไม่สามารถสมัครได้");
        }

        private bool AgeQualify(DateTime dob)
        {
            var today = _dateTimeService.CurrentTime().Date;
            int age = today.Year - dob.Year;
            if (dob > today.AddYears(-age))
                age--;
            return age >= 18;
        }
    }
}