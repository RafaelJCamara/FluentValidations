using FluentValidation;
using FluentValidations.Models;
using FluentValidations.Utils.Validation.Error;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace FluentValidations.Filters
{
    public class ValidationFilter : ActionFilterAttribute, IAsyncActionFilter
    {
        private readonly IValidator<Developer> _validator;

        public ValidationFilter(IValidator<Developer> validator)
        {
            _validator = validator;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var modelToValidate = context.ActionArguments["developer"] as Developer;
            var validation = await _validator.ValidateAsync(modelToValidate);
            if (!validation.IsValid)
            {
                //populate error messages
                var errorResponse = new ErrorResponse();
                foreach (var error in validation.Errors)
                {
                    errorResponse.Errors.Add(new ErrorModel
                    {
                        Field = error.PropertyName,
                        ErrorMessage = error.ErrorMessage
                    });
                }
                context.Result = new BadRequestObjectResult(errorResponse.Errors);
                return;
            }
            await next();
        }
    }
}
