using SysColGen = System.Collections.Generic;
using static System.Linq.Enumerable;

namespace SPWN.DataTypes;
using InternalImplementation;
using Basics;
using static Utils.Wrapper.Extension;

public class Array<Value> : ISPWNValue, ICanBeConstant, ICanBeMutable where Value : class, ISPWNValue
{
    public Array(SysColGen.IEnumerable<Value> collection) => ValueAsString = $"[{string.Join(",", collection.ToArray().Apply(x => x == null ? "" : x.ValueAsString))}]";
    public Array(ISPWNExpr<Array<Value>> Value) => ValueAsString = Value.CreateCode();
    protected Array() { }

    public string ValueAsString { get; set; } = "";
    public static implicit operator Array<Value>(Value[] values)
    {
        return new Array<Value>(values);
    }
    public Number Length
        => new SPWNPropertySyntaxBuilder(ValueAsString, "length")
        .Build<Number>();

    public Value this[Number n]
    {
        get => new SPWNArraySyntaxBuilder(ValueAsString)
        .AddParameter(n)
        .Build<Value>();
    }
}
public class Array : Array<ISPWNValue>
{
    public Array(SysColGen.IEnumerable<ISPWNValue> collection) : base(collection) { }
    public Array(ISPWNExpr<Array> Value) => ValueAsString = Value.CreateCode();
}