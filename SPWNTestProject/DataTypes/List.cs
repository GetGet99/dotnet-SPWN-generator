namespace SPWNCreator.SPWN.DataTypes;
using InternalImplementation;
using System.Diagnostics.CodeAnalysis;
using SysColGen = System.Collections.Generic;
using SPWN.Basics;
using static System.Linq.Enumerable;

public class List<Value> : ISPWNValue where Value : ISPWNValue
{
    public List(SysColGen.IEnumerable<Value> collection) => ValueAsString = $"[{string.Join(",", collection.ToArray().Apply(x => x == null ? "" : x.ValueAsString))}]";
    public List(ISPWNExpr<List<Value>> Value) => ValueAsString = Value.CreateCode().AddParenthesis();
    public string ValueAsString { get; set; }
    public static implicit operator List<Value>(Value[] values)
    {
        return new List<Value>(values);
    }
    public ISPWNExpr<Number> Length => new StringSPWNExpr<Number>($"{ValueAsString}.length");

    public ISPWNExpr<Value> this[Number n] => new StringSPWNExpr<Value>($"{ValueAsString}[{n.ValueAsString}]");
}