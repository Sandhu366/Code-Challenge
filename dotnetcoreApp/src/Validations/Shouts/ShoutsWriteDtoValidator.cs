using Common.Dtos.Write;
using FluentValidation;

namespace Validations.Shouts
{
    public class ShoutsWriteDtoValidator : ControllerValidator<ShoutWriteDto>
    {
        public ShoutsWriteDtoValidator()
        {
            RuleFor(x => x.Body).NotEmpty();
            RuleFor(x => x.Body).NotNull();
        }
    }
}
