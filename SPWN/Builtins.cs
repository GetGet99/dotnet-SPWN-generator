namespace SPWN.Builtins;
using DataTypes;
using DataTypes.Base;
using SPWN.InternalImplementation;
using Utilities.Wrapper;
static class Base
{
    public static readonly string Prefix = "$";
}
public static class Math
{
    public static Number Abs(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "abs")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Acos(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "acos")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Acosh(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "acosh")
        .AddParameter("n", N)
        .Build<Number>();
}
public static class GeometryDash
{
    public static SPWNCode Add(Object N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "add")
        .AddParameter("n", N)
        .Build();
}

