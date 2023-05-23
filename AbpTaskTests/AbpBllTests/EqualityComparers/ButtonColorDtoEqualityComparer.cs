using AbpBll.Entities.DTOs;
using System.Diagnostics.CodeAnalysis;

namespace AbpTaskTests.AbpBllTests.EqualityComparers
{
    public class ButtonColorDtoEqualityComparer : IEqualityComparer<ButtonColorDto>
    {
        public bool Equals(ButtonColorDto x, ButtonColorDto y)
        {
            return (x == null && y == null)
                || (x != null && y != null
                && x.Key == y.Key
                && x.Value == y.Value);
        }

        public int GetHashCode([DisallowNull] ButtonColorDto obj)
            => obj.GetHashCode();
    }
}
