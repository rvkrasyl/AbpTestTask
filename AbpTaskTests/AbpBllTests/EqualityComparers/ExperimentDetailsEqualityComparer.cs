using AbpBll.Entities.Models;
using System.Diagnostics.CodeAnalysis;

namespace AbpTaskTests.AbpBllTests.EqualityComparers
{
    public class ExperimentDetailsEqualityComparer : IEqualityComparer<ExperimentDetails>
    {
        public bool Equals(ExperimentDetails x, ExperimentDetails y)
        {
            return (x == null && y == null)
                || (x != null && y != null
                && x.ExperimentName == y.ExperimentName
                && x.DevicesInExperimentCount == y.DevicesInExperimentCount);
        }

        public int GetHashCode([DisallowNull] ExperimentDetails obj)
            => obj.GetHashCode();
    }
}
