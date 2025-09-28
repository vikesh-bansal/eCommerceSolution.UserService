using eCommerce.Core.ServiceContracts;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core.Services
{
    public class ValidatorService : IValidatorService
    {
        private readonly IServiceProvider _validatorService;

        public ValidatorService(IServiceProvider validatorService)
        {
            _validatorService = validatorService;
        }
        public ValidationResult Validate<T>(T model)
        {
            var validator = _validatorService.GetService<IValidator<T>>();
            if (validator == null) {
                throw new InvalidOperationException($"No validator registered for {typeof(T).Name}");
            }

            return validator.Validate(model);
        }
    }
}
