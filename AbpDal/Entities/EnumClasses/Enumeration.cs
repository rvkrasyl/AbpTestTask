namespace AbpDal.Entities.EnumClasses
{
    public class Enumeration
    {
        protected Enumeration(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public static bool operator ==(Enumeration left, Enumeration right)
            => left is null
                ? right is null
                : left.Equals(right);

        public static bool operator !=(Enumeration left, Enumeration right)
            => !(left == right);

        public static bool operator <(Enumeration left, Enumeration right)
            => left is null
                ? right is not null
                : left.CompareTo(right) < 0;

        public static bool operator <=(Enumeration left, Enumeration right)
            => left is null || left.CompareTo(right) <= 0;

        public static bool operator >(Enumeration left, Enumeration right)
            => left is not null && left.CompareTo(right) > 0;

        public static bool operator >=(Enumeration left, Enumeration right)
            => left is null
                ? right is null
                : left.CompareTo(right) >= 0;

        public int CompareTo(object obj)
            => Id.CompareTo(((Enumeration)obj).Id);

        public override bool Equals(object obj)
        {
            if (obj is not Enumeration otherValue)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => throw new NotImplementedException();

        public override string ToString() => Name;
    }
}
