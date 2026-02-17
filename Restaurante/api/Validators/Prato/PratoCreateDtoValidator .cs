using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Prato;
using FluentValidation;

namespace api.Validators.Prato
{
    public class PratoCreateDtoValidator : AbstractValidator<PratoCreateDto> 
    {
        public PratoCreateDtoValidator ()
        {
            RuleFor(p => p.Preco).GreaterThan(0)
                .WithMessage("O preço deve ser maior que zero.");
        }
    }
}