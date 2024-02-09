﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Features.Commands.SocialMedia.Create
{
    public class SocialMediaCreateCommandValidator:AbstractValidator<SocialMediaCreateCommandRequest>
    {
        public SocialMediaCreateCommandValidator()
        {
            RuleFor(socialMedia => socialMedia.CvPartId)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0)
                .WithName("Cv Bölümü");

            RuleFor(socialMedia => socialMedia.Url)
                .NotEmpty()
                .NotNull()
                .MinimumLength(5)
                .MaximumLength(255)
                .WithName("Url");

            RuleFor(socialMedia => socialMedia.Order)
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithName("Sıra");
        }
    }
}
