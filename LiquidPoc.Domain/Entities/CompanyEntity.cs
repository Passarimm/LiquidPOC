using FluentValidation;
using System.Collections.Generic;

namespace LiquidPoc.Domain.Entities
{
    public class CompanyEntity : _BaseEntity
    {
        public string Name { get; init; }

        public ICollection<EmployeeEntity> Assemblies { get; init; }
    }

    public class CompanyEntityValidator : AbstractValidator<CompanyEntity>
    {
        public CompanyEntityValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(70);
        }
    }
}
