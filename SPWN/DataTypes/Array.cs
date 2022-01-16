using SysColGen = System.Collections.Generic;
using static System.Linq.Enumerable;

namespace SPWN.DataTypes;
using InternalImplementation;
using Basics;
using Base;
using Utilities.Wrapper;
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

    public Number IsEmpty
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "is_empty")
        .Build<Number>();

    public Value Max(MacroFunc<SPWNValueBase, Value>? Key = null)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "max")
        .AddParameter("max", Key)
        .Build<Value>();

    public Value Min(MacroFunc<SPWNValueBase, Value>? Key = null)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "min")
        .AddParameter("max", Key)
        .Build<Value>();

    public Boolean Contains(Value Element)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "contains")
        .AddParameter("el", Element)
        .Build<Boolean>();

    public Boolean Has(Value Element)
        => new SPWNOperatorOverloadBuilder<Array<Value>>("has", this, Element)
        .Build<Boolean>();

    public Number Index(Value Element, Number? From = null)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "index")
        .AddParameter("el", Element)
        .AddParameter("from", From)
        .Build<Number>();

    public Number IndexOf(Value Element, Number? From = null)
        => Index(Element: Element, From: From);

    public Number IndexLast(Value Element, Number? Until = null)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "index_last")
        .AddParameter("el", Element)
        .AddParameter("until", Until)
        .Build<Number>();

    public Number LastIndexOf(Value Element, Number? Until = null)
        => IndexLast(Element: Element, Until: Until);

    public Array<Number> IndexAll(Value Element)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "index_last")
        .AddParameter("el", Element)
        .Build<Array<Number>>();

    public SPWNCode Clear()
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "clear")
        .Build();

    public Array<Value> Reverse()
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "reverse")
        .Build<Array<Value>>();

    public SPWNCode Push(Value Value)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "push")
        .AddParameter("value",Value)
        .Build();

    public Value Pop(Number? Index = null)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "pop")
        .AddParameter("index",Index)
        .Build<Value>();

    public Value Pop(System.Index Index)
        => Pop((Number)(Index.IsFromEnd ? -Index.Value : Index.Value));

    public Array<Value> Remove(Number Index)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "remove")
        .AddParameter("index", Index)
        .Build<Array<Value>>();

    // NEXT: map

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