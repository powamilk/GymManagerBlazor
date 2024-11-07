﻿using FluentValidation;
using GymManagerBlazor.BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Validators
{
    public class ClassModelValidator : AbstractValidator<ClassModel>
    {
        public ClassModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tên lớp học không được để trống")
                .MaximumLength(100).WithMessage("Tên lớp học tối đa 100 ký tự");

            RuleFor(x => x.TrainerId)
                .GreaterThan(0).WithMessage("Huấn luyện viên không hợp lệ");

            RuleFor(x => x.Schedule)
                .NotEmpty().WithMessage("Lịch học không được để trống");

            RuleFor(x => x.MaxMembers)
                .GreaterThan(0).WithMessage("Số lượng học viên tối đa phải lớn hơn 0");
        }
    }
}
