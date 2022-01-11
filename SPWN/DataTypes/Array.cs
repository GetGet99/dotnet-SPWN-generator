namespace SPWN.DataTypes;
using InternalImplementation;
using System.Diagnostics.CodeAnalysis;
using SysColGen = System.Collections.Generic;
using SPWN.Basics;
using static System.Linq.Enumerable;

public class Array<Value> : ISPWNValue, ICanBeConstant, ICanBeMutable where Value : ISPWNValue
{
    public Array(SysColGen.IEnumerable<Value> collection) => ValueAsString = $"[{string.Join(",", collection.ToArray().Apply(x => x == null ? "" : x.ValueAsString))}]";
    public Array(ISPWNExpr<Array<Value>> Value) => ValueAsString = Value.CreateCode().AddParenthesis();
    public string ValueAsString { get; set; }
    public static implicit operator Array<Value>(Value[] values)
    {
        return new Array<Value>(values);
    }
    public ISPWNExpr<Number> Length => new StringSPWNExpr<Number>($"{ValueAsString}.length");

    public ISPWNExpr<Value> this[Number n] => new StringSPWNExpr<Value>($"{ValueAsString}[{n.ValueAsString}]");
}