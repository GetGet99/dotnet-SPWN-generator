namespace SPWN.DataTypes;

using InternalImplementation;
using Basics;

public class Range<T> : ISPWNValue, ICanBeConstant, ICanBeMutable where T : ISPWNValue, IRangeImplemented
{
    public string ValueAsString { get; set; }

    public Range(T Start, T End) => ValueAsString = $"{Start.ValueAsString}..{End.ValueAsString}";
    public Range(ISPWNExpr<Range<T>> Value) => ValueAsString = Value.CreateCode();
    public static implicit operator Range<T>((T, T) value) => new(value.Item1, value.Item2);
}
public static class Ranges
{
    public class NumberRange : Range<Number>
    {
        public NumberRange(ISPWNExpr<Range<Number>> Value) : base(Value)
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