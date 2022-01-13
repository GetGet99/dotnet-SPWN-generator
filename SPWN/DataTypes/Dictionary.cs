using SysColGen = System.Collections.Generic;

namespace SPWN.DataTypes;
using InternalImplementation;
using Basics;
using static Utils.Wrapper.Extension;

public class Dictionary<Value> : ISPWNValue, ICanBeConstant, ICanBeMutable where Value : class, ISPWNValue
{
    public Dictionary(SysColGen.Dictionary<string, Value> collection) => ValueAsString = $"{{{string.Join(",", collection.Keys.Apply(x => (x == null) ? "" : $"{x}: {collection[x].ValueAsString}"))}}}";//.ToArray().Apply(x => x == null ? "" : x.ValueAsString))
    public Dictionary(ISPWNExpr<Dictionary<Value>> Value) => ValueAsString = Value.CreateCode();
    protected Dictionary() { }
    public string ValueAsString { get; set; } = "";
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
        => new SPWNMethodCallBuilder(ValueAsString, "clear")
        .Build();

    public Boolean ContainsValue(Value Value)
        => new SPWNMethodCallBuilder(ValueAsString, "contains_value")
        .AddParameter("value", Value)
        .Build<Boolean>();

    public Value Get(String Key, Value? Default = null)
        => new SPWNMethodCallBuilder(ValueAsString, "get")
        .AddParameter("key", Key)
        .AddParameter("default", Default)
        .Build<Value>();

    public Boolean IsEmpty
        => new SPWNMethodCallBuilder(ValueAsString, "is_empty")
        .Build<Boolean>();

    public Array<Tuple<String,Value>> Items
        => new SPWNMethodCallBuilder(ValueAsString, "items")
        .Build<Array<Tuple<String, Value>>>();

    public Array<String> Keys
        => new SPWNMethodCallBuilder(ValueAsString, "keys")
        .Build<Array<String>>();

    public Value Set(String Key, Value Value)
        => new SPWNMethodCallBuilder(ValueAsString, "get")
        .AddParameter("key", Key)
        .AddParameter("val", Value)
        .Build<Value>();

    public Array<String> Values
        => new SPWNMethodCallBuilder(ValueAsString, "values")
        .Build<Array<String>>();
}
class Dictionary : Dictionary<ISPWNValue>
{
    public Dictionary(SysColGen.Dictionary<string, ISPWNValue> collection) : base(collection) { }
    public Dictionary(ISPWNExpr<Dictionary> Value) => ValueAsString = Value.CreateCode();
}