namespace SPWN.DataTypes;
using InternalImplementation;
using System.Diagnostics.CodeAnalysis;
using SysColGen = System.Collections.Generic;
using SPWN.Basics;
using static System.Linq.Enumerable;
using static Basics.Extensions;
public class Array<Value> : ISPWNValue, ICanBeConstant, ICanBeMutable where Value : class, ISPWNValue
{
    public Array(SysColGen.IEnumerable<Value> collection) => ValueAsString = $"[{string.Join(",", collection.ToArray().Apply(x => x == null ? "" : x.ValueAsString))}]";
    public Array(ISPWNExpr<Array<Value>> Value) => ValueAsString = Value.CreateCode().AddParenthesis();
    public string ValueAsString { get; set; }
    public static implicit operator Array<Value>(Value[] values)
    {
        return new Array<Value>(values);
    }
    public Number Length
        => new SPWNPropertySyntaxBuilder(ValueAsString, "length")
        .Build<Number>();

    public Value this[Number n]
        => new SPWNArraySyntaxBuilder(ValueAsString)
        .AddParameter(n)
        .Build<Value>();
}