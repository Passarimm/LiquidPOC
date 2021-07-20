using FluentValidation;
using LiquidPoc.Domain.Enum;
using System;

namespace LiquidPoc.Domain.Entities
{
    public class EmployeeEntity : _BaseEntity
    {

        public string Name { get; init; }

        public DateTime BirthDate { get; init; }

        public MaritalStatus MaritalStatus { get; init; }
        public Guid CompanyId { get; init; }

        public CompanyEntity Company { get; init; }
    }

    public class AssemblyEntityValidator : AbstractValidator<EmployeeEntity>
    {
        public AssemblyEntityValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(250);
            RuleFor(x => x.BirthDate).NotEmpty().Must(date => date != default(DateTime));
        }
    }
}
