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
    public Array(SysColGen.IEnumerable<Value> collection) => ValueAsString = $"[{string.Join(",", collection.ToArray().Apply(x => x == default ? "" : x.ValueAsString))}]";
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

    public Value Max(MacroFunc<SPWNValueBase, Value>? Key = default)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "max")
        .AddParameter("max", Key)
        .Build<Value>();

    public Value Min(MacroFunc<SPWNValueBase, Value>? Key = default)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "min")
        .AddParameter("max", Key)
        .Build<Value>();

    public Boolean Contains(Value Element)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "contains")
        .AddParameter("el", Element)
        .Build<Boolean>();

    public Number Index(Value Element, Number? From = default)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "index")
    .AddParameter("el", Element)
    .AddParameter("from", From)
    .Build<Number>();

    public Number IndexOf(Value Element, Number? From = default)
        => Index(Element: Element, From: From);

    public Number IndexLast(Value Element, Number? Until = default)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "index_last")
        .AddParameter("el", Element)
        .AddParameter("until", Until)
        .Build<Number>();

    public Number LastIndexOf(Value Element, Number? Until = default)
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
        .AddParameter("value", Value)
        .Build();

    public Value Pop(Number? Index = default)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "pop")
        .AddParameter("index", Index)
        .Build<Value>();

    public Value Pop(System.Index Index)
        => Pop((Number)(Index.IsFromEnd ? -Index.Value : Index.Value));

    public Array<Value> Remove(Number Index)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "remove")
        .AddParameter("index", Index)
        .Build<Array<Value>>();


    public Array<T> Map<T>(MacroFunc<Value, T> Callback, Boolean InPlace) where T : SPWNValueBase
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "map")
        .AddParameter("cb", Callback)
        .AddParameter("in_place", InPlace)
        .Build<Array<T>>();

    public Array<T> MapIndex<T>(MacroFunc<Value, Number, T> Callback, Boolean? InPlace = default) where T : SPWNValueBase
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "map_index")
        .AddParameter("cb", Callback)
        .AddParameter("in_place", InPlace)
        .Build<Array<T>>();

    public Array<Value> Filter(MacroFunc<Value, Boolean> Callback)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "filter")
        .AddParameter("cb", Callback)
        .Build<Array<Value>>();

    public SPWNValueBase Reduce(MacroFunc<Value, SPWNValueBase> Callback)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "reduce")
        .AddParameter("cb", Callback)
        .Build<Array<Value>>();

    public Boolean Any(MacroFunc<Value, Boolean>? Map = default)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "any")
        .AddParameter("map", Map)
        .Build<Boolean>();

    public Boolean All(MacroFunc<Value, Boolean>? Map = default)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "all")
        .AddParameter("map", Map)
        .Build<Boolean>();

    public Value Sum()
        => new SPWNMethodCallBuilder<Value>(ValueAsString, "sum")
        .Build<Value>();

    public SPWNCode Sort(Number? Begin = default, Number? End = default, MacroFunc<Value, Value, Boolean>? Comparison = default)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "sort")
        .AddParameter("begin", Begin)
        .AddParameter("end", End)
        .AddParameter("comp", Comparison)
        .Build();

    public Array<Value> Sorted(Number? Begin = default, Number? End = default, MacroFunc<Value, Value, Boolean>? Comparison = default)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "sorted")
        .AddParameter("begin", Begin)
        .AddParameter("end", End)
        .AddParameter("comp", Comparison)
        .Build<Array<Value>>();

    public Value Shift()
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "shift")
        .Build<Value>();

    public Value Unshift(Value Value)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "unshift")
        .AddParameter("value", Value)
        .Build<Value>();

    public Array Flattern()
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "flatten")
        .Build<Array>();

    public Array<Tuple<Number, Value>> Enumerate()
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "enumerate")
        .Build<Array<Tuple<Number, Value>>>();

    public Array EnumerateAsDict()
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "enumerate")
        .Build<Array>();

    public Array<Array<Value>> Split(Array<Number> Indicies)
        => new SPWNMethodCallBuilder<Array<Value>>(ValueAsString, "split")
        .AddParameter("indicies", Indicies)
        .Build<Array<Array<Value>>>();

    public Boolean Has(Value Element)
        => new SPWNOperatorOverloadBuilder<Array<Value>>("has", this, Element)
        .Build<Boolean>();


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