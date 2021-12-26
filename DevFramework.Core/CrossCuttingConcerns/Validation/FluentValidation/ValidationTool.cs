using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.TestHelper;

namespace DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var validationContext = new ValidationContext<object>(entity);
            var result = validator.Validate(validationContext);
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }

    
}
