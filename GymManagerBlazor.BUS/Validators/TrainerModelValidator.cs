﻿using FluentValidation;
using GymManagerBlazor.BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Validators
{
    public class TrainerModelValidator : AbstractValidator<TrainerModel>
    {
        public TrainerModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tên không được để trống")
                .MaximumLength(100).WithMessage("Tên tối đa 100 ký tự");

            RuleFor(x => x.Specialty)
                .NotEmpty().WithMessage("Chuyên môn không được để trống")
                .MaximumLength(50).WithMessage("Chuyên môn tối đa 50 ký tự");

            RuleFor(x => x.ExperienceYears)
                .GreaterThanOrEqualTo(0).WithMessage("Số năm kinh nghiệm không được là số âm");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email không được để trống")
                .EmailAddress().WithMessage("Email không hợp lệ");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Số điện thoại không được để trống")
                .Matches(@"^\d+$").WithMessage("Số điện thoại chỉ chứa số")
                .MaximumLength(15).WithMessage("Số điện thoại tối đa 15 ký tự");
        }
    }
}
