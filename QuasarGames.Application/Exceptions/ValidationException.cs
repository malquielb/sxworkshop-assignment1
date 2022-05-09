using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuasarGames.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();

            validationResult.Errors.ForEach(error =>
                ValidationErrors.Add(error.ErrorMessage));
        }

        public List<string> ValidationErrors { get; set; }
    }
}
