using AbpBll.Entities.DTOs;
using System.Diagnostics.CodeAnalysis;

namespace AbpTaskTests.AbpBllTests.EqualityComparers
{
    public class PriceOptionDtoEqualityComparer : IEqualityComparer<PriceOptionDto>
    {
        public bool Equals(PriceOptionDto x, PriceOptionDto y)
        {
            return (x == null && y == null)
                || (x != null && y != null
                && x.Key == y.Key
                && x.Value == y.Value);
        }

        public int GetHashCode([DisallowNull] PriceOptionDto obj)
            => obj.GetHashCode();
    }
}
