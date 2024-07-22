 

namespace ISTCOSA.Application.CommandAndQuries.Batches.Validators
{
    public class CreateBatchCommandValidator:AbstractValidator<CreateBatchCommand>
    {
        public CreateBatchCommandValidator()
        {
            RuleFor(v => v.BatchNumber)
                .NotEmpty().WithMessage("Batch number is required.")
                .InclusiveBetween(1, int.MaxValue).WithMessage("Batch number must be a positive integer.");
        }
    }
}
