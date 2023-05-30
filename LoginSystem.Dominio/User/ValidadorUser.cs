using System;
using FluentValidation;

namespace LoginSystem.Dominio.User
{
    public class ValidadorUser : AbstractValidator<User>
    {
        public ValidadorUser()
        {
            RuleFor(x => x.UserName)
               .NotNull()
               .NotEmpty()
               .WithMessage("Horário de ínicio deve ser menor que Horário de Términio");

            RuleFor(x => x.Password)
               .NotNull()
               .NotEmpty()
               .WithMessage("Horário de ínicio deve ser menor que Horário de Términio");
        }
    }
}
