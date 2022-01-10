namespace SPWN.DataTypes;
using SPWN.Basics;
using SPWN.InternalImplementation;

public class Number : ISPWNValue, IRangeImplemented
{
    public string ValueAsString { get; private set; }
    public Number(double Value) => ValueAsString = Value.ToString();
    public Number(ISPWNExpr<Number> Value) => ValueAsString = Value.CreateCode().AddParenthesis();
    public static implicit operator Number(double d) => new(d);
}