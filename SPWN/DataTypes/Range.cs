namespace SPWN.DataTypes;

using InternalImplementation;
using Basics;

public class Range<T> : ISPWNValue, ICanBeConstant, ICanBeMutable where T : ISPWNValue, IRangeImplemented
{
    public string ValueAsString { get; set; }

    public Range(T Start, T End) => ValueAsString = $"{Start.ValueAsString}..{End.ValueAsString}";
    public Range(ISPWNExpr<Range<T>> Value) => ValueAsString = Value.CreateCode().AddParenthesis();

    //public static implicit operator Range<Number>(System.Range a)
    //{
    //    if (a.Start.IsFromEnd || a.End.IsFromEnd) throw new System.NotImplementedException();
    //    return new(a.Start.Value, a.End.Value);
    //}
    //public static implicit operator Range((Number?, Number) value) => new(value.Item1 ?? 0, value.Item2);

}
public interface IRangeImplemented
{

}