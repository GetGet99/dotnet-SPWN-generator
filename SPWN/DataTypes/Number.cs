namespace SPWN.DataTypes;
using SPWN.InternalImplementation;
using static Utils.Wrapper.Extension;
public class Number : ISPWNValue, IRangeImplemented, ICanBeConstant, ICanBeMutable
{
    public string ValueAsString { get; private set; }
    public Number(double Value) => ValueAsString = Value.ToString();
    public Number(ISPWNExpr<Number> Value) => ValueAsString = Value.CreateCode();
    public static implicit operator Number(double d) => new(d);

    public Number Constrain(Number Min, Number Max)
        => new SPWNMethodCallBuilder($"{ValueAsString}.constrain")
        .AddParameter("min", Min)
        .AddParameter("max", Max)
        .Build<Number>();

    public Number Map(Number IStart, Number IStop, Number OStart, Number OStop)
        => new SPWNMethodCallBuilder($"{ValueAsString}.map")
        .AddParameter("istart", IStart)
        .AddParameter("istop", IStop)
        .AddParameter("ostart", OStart)
        .AddParameter("ostop", OStop)
        .Build<Number>();
}