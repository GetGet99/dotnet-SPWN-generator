namespace SPWN.DataTypes;
using InternalImplementation;
using static Utils.Wrapper.Extension;
public class String : ISPWNValue, IRangeImplemented, ICanBeConstant, ICanBeMutable
{
    public string ValueAsString { get; private set; }
    public String(string Value) => ValueAsString = Value;
    public String(ISPWNExpr<String> Value) => ValueAsString = Value.CreateCode();
    public static implicit operator String(string str) => new(str);

    public Boolean Contains(String Substring)
        => new SPWNMethodCallBuilder(ValueAsString, "contains")
        .AddParameter("substr", Substring)
        .Build<Boolean>();

    public Boolean EndsWith(String Substring)
        => new SPWNMethodCallBuilder(ValueAsString, "ends_with")
        .AddParameter("substr", Substring)
        .Build<Boolean>();

    public Boolean Find(String Regex)
        => new SPWNMethodCallBuilder(ValueAsString, "find")
        .AddParameter("re", Regex)
        .Build<Boolean>();

    public Array<String> FindAll(String Regex)
        => new SPWNMethodCallBuilder(ValueAsString, "find_all")
        .AddParameter("re", Regex)
        .Build<Array<String>>();

    public String Fmt(String Subtitude)
        => new SPWNMethodCallBuilder(ValueAsString, "fmt")
        .AddParameter("subs", Subtitude)
        .Build<String>();

    public String Fmt(Array<String> Subtitude)
        => new SPWNMethodCallBuilder(ValueAsString, "fmt")
        .AddParameter("subs", Subtitude)
        .Build<String>();

    public String Format(String Subtitude)
        => Fmt(Subtitude);

    public String Format(Array<String> Subtitude)
        => Fmt(Subtitude);

    public Number Index(String SubString)
        => new SPWNMethodCallBuilder(ValueAsString, "index")
        .AddParameter("substr", SubString)
        .Build<Number>();

    public Number IndexOf(String SubString)
        => Index(SubString);


    public Boolean StartsWith(String Substring)
        => new SPWNMethodCallBuilder(ValueAsString, "starts_with")
        .AddParameter("substr", Substring)
        .Build<Boolean>();
}
