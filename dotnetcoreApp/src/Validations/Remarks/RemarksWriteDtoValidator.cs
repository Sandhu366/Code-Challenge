using Common.Dtos.Write;
using FluentValidation;

namespace Validations.Remarks
{
    public class RemarksWriteDtoValidator : ControllerValidator<RemarkWriteDto>
    {
        public RemarksWriteDtoValidator()
        {
            RuleFor(x => x.ShoutId).NotEmpty();
            RuleFor(x => x.Body).NotEmpty();
            RuleFor(x => x.Body).NotNull();
        }
    }
}
