using APIDDD.Application.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIDDD.Application.Validations
{
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(c => c.Document).NotEmpty().NotNull().WithMessage("Documento deve ser informado!");
            RuleFor(c => c.Name).NotEmpty().NotNull().WithMessage("Nome deve ser informado!");
            RuleFor(c => c.Phone).NotEmpty().NotNull().WithMessage("Celular deve ser informado!");
        }
    }
}
