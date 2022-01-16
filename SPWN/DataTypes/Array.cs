using SysColGen = System.Collections.Generic;
using static System.Linq.Enumerable;

namespace SPWN.DataTypes;
using InternalImplementation;
using Basics;
using Base;
using Utils.Wrapper;
[SPWNType("@array")]
public class Array<Value> : SPWNValueBase, ICanBeConstant, ICanBeMutable where Value : SPWNValueBase
{
    public Array(SysColGen.IEnumerable<Value> collection) => ValueAsString = $"[{string.Join(",", collection.ToArray().Apply(x => x == null ? "" : x.ValueAsString))}]";
    public Array(SPWNExpr<Array<Value>> Value) => ValueAsString = Value.CreateCode();
    protected Array() { }

    public override string ValueAsString { get; protected set; } = "";
    public static implicit operator Array<Value>(Value[] values)
    {
        return new Array<Value>(values);
    }
    public Number Length
        => new SPWNPropertySyntaxBuilder<Array<Value>>(ValueAsString, "length")
        .Build<Number>();

    public Value this[Number n]
    {
        get => new SPWNArraySyntaxBuilder<Array<Value>>(ValueAsString)
        .AddParameter(n)
        .Build<Value>();
    }
}
public class Array : Array<SPWNValueBase>
{
    public Array(SysColGen.IEnumerable<SPWNValueBase> collection) : base(collection) { }
    public Array(SPWNExpr<Array> Value) => ValueAsString = Value.CreateCode();
}