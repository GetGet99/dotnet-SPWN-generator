namespace SPWN.DataTypes;

using InternalImplementation;
using Basics;
using Base;

[SPWNType("@range")]
public class Range<T> : SPWNValueBase, ICanBeConstant, ICanBeMutable where T : SPWNValueBase, IRangeImplemented
{
    public override string ValueAsString { get; protected set; }

    public Range(T Start, T End) => ValueAsString = $"{Start.ValueAsString}..{End.ValueAsString}";
    public Range(SPWNExpr<Range<T>> Value) => ValueAsString = Value.CreateCode();
    public static implicit operator Range<T>((T, T) value) => new(value.Item1, value.Item2);
}
public static class Ranges
{
    public class NumberRange : Range<Number>
    {
        public NumberRange(SPWNExpr<Range<Number>> Value) : base(Value)
        {

        }

        public NumberRange(Number Start, Number End) : base(Start, End)
        {

        }

        public static implicit operator NumberRange(System.Range sysRange)
        {
            if (sysRange.End.IsFromEnd || sysRange.Start.IsFromEnd) throw new System.ArgumentException("Range.Start.IsFromEnd and Range.End.IsFromEnd cannot be true");
            return new(sysRange.Start.Value, sysRange.End.Value);
        }

        public static implicit operator NumberRange((Number?, Number) value) => new(value.Item1 ?? 0, value.Item2);
        public static implicit operator NumberRange((int?, Number) value) => new(value.Item1 ?? 0, value.Item2);
        public static implicit operator NumberRange((double?, Number) value) => new(value.Item1 ?? 0, value.Item2);
        public static implicit operator NumberRange((Number?, int) value) => new(value.Item1 ?? 0, value.Item2);
        public static implicit operator NumberRange((Number?, double) value) => new(value.Item1 ?? 0, value.Item2);
    }
}
public interface IRangeImplemented
{

}