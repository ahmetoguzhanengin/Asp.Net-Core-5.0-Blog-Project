using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidaitonRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {

            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklamasını boş geçemezsiniz!");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapınız.!");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Lütfen 2 karakterden daha fazla veri girişi yapınız!");


        }

       
    }
}
