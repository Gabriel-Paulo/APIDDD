using APIDDD.Application.DTOs;

using FluentValidation;


namespace APIDDD.Application.Validations
{
    public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidator() 
        {
            RuleFor(x => x.CodErp).NotEmpty().NotNull().WithMessage("CodErp deve ser informado!");
            RuleFor(x => x.Document).NotEmpty().NotNull().WithMessage("Document deve ser informado!");
        }
    }
}
