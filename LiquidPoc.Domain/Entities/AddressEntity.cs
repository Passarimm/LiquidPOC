using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidPoc.Domain.Entities
{
    public class AddressEntity : _BaseEntity
    {
        public string ZipCode { get; init; }
        public string LineOne { get; init; }
        public string LineTwo { get; init; }
        public int Number { get; init; }
        public string Neighborhood { get; init; }
        public string City { get; init; }
        public string District { get; init; }
        public string Country { get; init; }
    }

    public class AddressEntityValidator : AbstractValidator<AddressEntity>
    {
        public AddressEntityValidator()
        {
            RuleFor(x => x.ZipCode).NotEmpty().MaximumLength(12);
            RuleFor(x => x.LineOne).NotEmpty();
            RuleFor(x => x.Neighborhood).NotEmpty();
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.District).NotEmpty();
        }
    }
}
