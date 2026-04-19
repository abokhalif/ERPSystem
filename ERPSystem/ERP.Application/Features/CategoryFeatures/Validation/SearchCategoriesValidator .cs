using ERP.Application.Features.CategoryFeatures.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Application.Features.CategoryFeatures.Validation
{
    public class SearchCategoriesValidator : AbstractValidator<SearchCategoriesRequest>
    {
        public SearchCategoriesValidator()
        {
            RuleFor(x => x.PageNumber)
                .GreaterThanOrEqualTo(1)
                .WithMessage("Page number must be >= 1");

            RuleFor(x => x.PageSize)
                .InclusiveBetween(1, 100)
                .WithMessage("Page size must be between 1 and 100");

            RuleFor(x => x.PageNumber)
                .LessThanOrEqualTo(10000)
                .WithMessage("Page number is too large");

            RuleFor(x => x.SearchTerm)
                .MaximumLength(100)
                .When(x => !string.IsNullOrWhiteSpace(x.SearchTerm))
                .WithMessage("Search term too long");
        }
    }
}
