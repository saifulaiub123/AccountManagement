﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Account.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(string message) : base("One or more validation failures have occured.")
        {
            Errors = new Dictionary<string, string[]>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : base()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; set; }
    }
}
