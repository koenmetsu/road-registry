namespace RoadRegistry.BackOffice.Core
{
    using FluentValidation;

    public class RoadNodeGeometryValidator : AbstractValidator<Messages.RoadNodeGeometry>
    {
        public RoadNodeGeometryValidator()
        {
            RuleFor(c => c.SpatialReferenceSystemIdentifier).GreaterThanOrEqualTo(0);
            RuleFor(c => c.Point).NotNull();
        }
    }
}
