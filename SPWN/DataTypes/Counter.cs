namespace SPWN.DataTypes;
using Basics;
using InternalImplementation;
using static Basics.Extensions;

using BooleanExpr = InternalImplementation.ISPWNExpr<Boolean>;
using StrBooleanExpr = InternalImplementation.StringSPWNExpr<Boolean>;

public class Counter : ISPWNValue, ICanBeMutable
{
    public string ValueAsString { get; private set; }

    public Counter(double Value) => this.ValueAsString = $"counter({Value})";
    public Counter(ISPWNExpr<Counter> Value) => ValueAsString = Value.CreateCode().AddParenthesis();

    public ISPWNCode Add(Number Num) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("num", Num)
        .Build();

    public ISPWNCode AddTo(Counter Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public ISPWNCode AddTo(Item Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public ISPWNCode AddTo(Array<Counter> Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public ISPWNCode AddTo(Array<Item> Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public ISPWNCode AddToMultifactor(Array<Array<Counter>> Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public ISPWNCode AddToMultifactor(Array<Array<Item>> Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public ISPWNCode Reset() =>
        new SPWNMethodCallBuilder($"{ValueAsString}.reset")
        .Build();

    public ISPWNExpr<Counter> Clone() =>
        new SPWNMethodCallBuilder($"{ValueAsString}.clone").BuildExpr<Counter>();

    //public ISPWNCode SetTo(Number n) => new StringSPWNCode($"{ValueAsString} = {n.ValueAsString}");

    public BooleanExpr IsGreaterThan(Number n) => new StrBooleanExpr($"{ValueAsString} > {n.ValueAsString}");
    public BooleanExpr IsGreaterThanOrEqual(Number n) => new StrBooleanExpr($"{ValueAsString} >= {n.ValueAsString}");
    public BooleanExpr IsLessThan(Number n) => new StrBooleanExpr($"{ValueAsString} < {n.ValueAsString}");
    public BooleanExpr IsLessThanOrEqual(Number n) => new StrBooleanExpr($"{ValueAsString} <= {n.ValueAsString}");

    public static BooleanExpr operator >(Counter c, Number other) => c.IsGreaterThan(other);
    public static BooleanExpr operator >=(Counter c, Number other) => c.IsGreaterThanOrEqual(other);
    public static BooleanExpr operator <(Counter c, Number other) => c.IsLessThan(other);
    public static BooleanExpr operator <=(Counter c, Number other) => c.IsLessThanOrEqual(other);
    public ISPWNExpr<Number> ToConst(Range<Number> r)
    {
        return new StringSPWNExpr<Number>($"{ValueAsString}.to_const({r.ValueAsString})");
    }
}



