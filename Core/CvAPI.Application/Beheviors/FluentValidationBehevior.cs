﻿using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvAPI.Application.Beheviors
{
    public class FluentValidationBehevior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validator;
        public FluentValidationBehevior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;   
        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failtures=_validator
                .Select(v=>v.Validate(context))
                .SelectMany(result=>result.Errors)
                .GroupBy(error=>error.ErrorMessage)
                .Select(x=>x.First())
                .Where(fail=>fail!=null)
                .ToList();

            if (failtures.Any())
                throw new ValidationException(failtures);

            return next();
        }
    }
}
