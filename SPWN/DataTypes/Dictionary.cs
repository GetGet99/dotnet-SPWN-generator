using SysColGen = System.Collections.Generic;

namespace SPWN.DataTypes;
using InternalImplementation;
using Basics;
using Utils.Wrapper;
using Base;
[SPWNType("@dictionary")]
public class Dictionary<Value> : SPWNValueBase, ICanBeConstant, ICanBeMutable where Value : SPWNValueBase
{
    public Dictionary(SysColGen.Dictionary<string, Value> collection) => ValueAsString = $"{{{string.Join(",", collection.Keys.Apply(x => (x == null) ? "" : $"{x}: {collection[x].ValueAsString}"))}}}";//.ToArray().Apply(x => x == null ? "" : x.ValueAsString))
    public Dictionary(SPWNExpr<Dictionary<Value>> Value) => ValueAsString = Value.CreateCode();
    protected Dictionary() { }
    public override string ValueAsString { get; protected set; } = "";
    public static implicit operator Dictionary<Value>(SysColGen.Dictionary<string, Value> values)
    {
        return new Dictionary<Value>(values);
    }

    public Value this[String Key]
    {
        get => Get(Key);
        set => Set(Key, value);
    }
    
    public SPWNCode Clear()
        => new SPWNMethodCallBuilder<Dictionary<Value>>(ValueAsString, "clear")
        .Build();

    public Boolean ContainsValue(Value Value)
        => new SPWNMethodCallBuilder<Dictionary<Value>>(ValueAsString, "contains_value")
        .AddParameter("value", Value)
        .Build<Boolean>();

    public Value Get(String Key, Value? Default = null)
        => new SPWNMethodCallBuilder<Dictionary<Value>>(ValueAsString, "get")
        .AddParameter("key", Key)
        .AddParameter("default", Default)
        .Build<Value>();

    public Boolean IsEmpty
        => new SPWNMethodCallBuilder<Dictionary<Value>>(ValueAsString, "is_empty")
        .Build<Boolean>();

    public Array<Tuple<String,Value>> Items
        => new SPWNMethodCallBuilder<Dictionary<Value>>(ValueAsString, "items")
        .Build<Array<Tuple<String, Value>>>();

    public Array<String> Keys
        => new SPWNMethodCallBuilder<Dictionary<Value>>(ValueAsString, "keys")
        .Build<Array<String>>();

    public Value Set(String Key, Value Value)
        => new SPWNMethodCallBuilder<Dictionary<Value>>(ValueAsString, "get")
        .AddParameter("key", Key)
        .AddParameter("val", Value)
        .Build<Value>();

    public Array<String> Values
        => new SPWNMethodCallBuilder<Dictionary<Value>>(ValueAsString, "values")
        .Build<Array<String>>();
}
class Dictionary : Dictionary<SPWNValueBase>
{
    public Dictionary(SysColGen.Dictionary<string, SPWNValueBase> collection) : base(collection) { }
    public Dictionary(SPWNExpr<Dictionary> Value) => ValueAsString = Value.CreateCode();
}