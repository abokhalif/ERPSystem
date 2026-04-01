using Domain.Models;
using FluentValidation;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validation
{
    public class PostValidator:AbstractValidator<Post>
    {
        public PostValidator() 
        {
            RuleFor(post => post.Content).Length(5, 255).WithMessage("Enter a valid string Length");
            RuleFor(post=>post.DateCreated).NotEmpty().NotNull().LessThanOrEqualTo(post=>post.LastModified).WithMessage("Enter a valid Date");
            RuleFor(post => post.LastModified).NotEmpty().NotNull().WithErrorCode("000");

        }
    }
}
