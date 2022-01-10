namespace SPWNCreator.SPWN.DataTypes;
using Basics;
using InternalImplementation;

using BooleanExpr = InternalImplementation.ISPWNExpr<Boolean>;
using StrBooleanExpr = InternalImplementation.StringSPWNExpr<Boolean>;

public class Counter : ISPWNValue
{
    public string ValueAsString { get; private set; }

    public Counter(double Value) => this.ValueAsString = $"counter({Value})";
    public Counter(ISPWNExpr<Counter> Value) => ValueAsString = Value.CreateCode().AddParenthesis();

    public ISPWNCode SetAdd(Number n) => new StringSPWNCode($"{ValueAsString} += {n.ValueAsString}");

    public ISPWNCode SetTo(Number n) => new StringSPWNCode($"{ValueAsString} = {n.ValueAsString}");

    public BooleanExpr IsGreaterThan(Number n) => new StrBooleanExpr($"{ValueAsString} > {n.ValueAsString}");
    public BooleanExpr IsGreaterThanOrEqual(Number n) => new StrBooleanExpr($"{ValueAsString} >= {n.ValueAsString}");
    public BooleanExpr IsLessThan(Number n) => new StrBooleanExpr($"{ValueAsString} < {n.ValueAsString}");
    public BooleanExpr IsLessThanOrEqual(Number n) => new StrBooleanExpr($"{ValueAsString} <= {n.ValueAsString}");

    public static BooleanExpr operator >(Counter c, Number other) => c.IsGreaterThan(other);
    public static BooleanExpr operator >=(Counter c, Number other) => c.IsGreaterThanOrEqual(other);
    public static BooleanExpr operator <(Counter c, Number other) => c.IsLessThan(other);
    public static BooleanExpr operator <=(Counter c, Number other) => c.IsLessThanOrEqual(other);
    public ISPWNExpr<Number> ToConst(Range r)
    {
        return new StringSPWNExpr<Number>($"{ValueAsString}.to_const({r.ValueAsString})");
    }
}
public class Range : ISPWNValue
{
    public string ValueAsString { get; set; }

    public Range(Number Start, Number End) => ValueAsString = $"{Start.ValueAsString}..{End.ValueAsString}";
    public Range(ISPWNExpr<Range> Value) => ValueAsString = Value.CreateCode().AddParenthesis();

    public static implicit operator Range(System.Range a)
    {
        if (a.Start.IsFromEnd || a.End.IsFromEnd) throw new System.NotImplementedException();
        return new(a.Start.Value, a.End.Value);
    }
    public static implicit operator Range((Number?, Number) value) => new(value.Item1 ?? 0, value.Item2);

}


