using FluentValidation;
using System;

namespace LiquidPoc.Domain.Entities
{
    public abstract class _BaseEntity
    {
        public Guid Id { get; init; }

        public DateTime CreateAt { get; init; }

        public DateTime? UpdatedAt { get; init; }

        public bool Deleted { get; init; }

        public bool Active { get; init; }
    }

    public class _BaseEntityValidator : AbstractValidator<_BaseEntity>
    {
        public _BaseEntityValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.CreateAt).NotEmpty().Must(date => date != default(DateTime));
            RuleFor(x => x.Deleted).NotEmpty();
            RuleFor(x => x.Active).NotEmpty();
        }
    }
}
