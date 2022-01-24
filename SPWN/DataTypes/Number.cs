namespace SPWN.DataTypes;
using SPWN.InternalImplementation;
using Utilities.Wrapper;
using Base;

[SPWNType("@number")]
public class Number : SPWNValueBase, IRangeImplemented, ICanBeConstant, ICanBeMutable
{
    public class Epsilon : Number
    {
        public Epsilon() => ValueAsString = double.Epsilon.ToString();
        public Epsilon(SPWNExpr<Epsilon> Value) => ValueAsString = Value.CreateCode();
    }
    public override string ValueAsString { get; protected set; } = "";
    protected Number() { }
    public Number(double Value) => ValueAsString = Value.ToString();
    public Number(SPWNExpr<Number> Value) => ValueAsString = Value.CreateCode();
    public static implicit operator Number(double d) => new(d);

    public Number Constrain(Number Min, Number Max)
        => new SPWNMethodCallBuilder<Number>($"{ValueAsString}.constrain")
        .AddParameter("min", Min)
        .AddParameter("max", Max)
        .Build<Number>();

    public Number Map(Number IStart, Number IStop, Number OStart, Number OStop)
        => new SPWNMethodCallBuilder<Number>($"{ValueAsString}.map")
        .AddParameter("istart", IStart)
        .AddParameter("istop", IStop)
        .AddParameter("ostart", OStart)
        .AddParameter("ostop", OStop)
        .Build<Number>();

    public static Number operator +(Number a, Number b)
        => new SPWNOperatorOverloadBuilder<Number>("+", a, b)
        .Build<Number>();

    public static Number operator -(Number a, Number b)
        => new SPWNOperatorOverloadBuilder<Number>("-", a, b)
        .Build<Number>();

    public static Number operator *(Number a, Number b)
        => new SPWNOperatorOverloadBuilder<Number>("*", a, b)
        .Build<Number>();

    public static Number operator /(Number a, Number b)
        => new SPWNOperatorOverloadBuilder<Number>("/", a, b)
        .Build<Number>();
}