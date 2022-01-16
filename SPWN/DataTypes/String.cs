namespace SPWN.DataTypes;
using InternalImplementation;
using Utils.Wrapper;
using SPWN.DataTypes.Base;
[SPWNType("@string")]
public class String : SPWNValueBase, IRangeImplemented, ICanBeConstant, ICanBeMutable
{
    public override string ValueAsString { get; protected set; }
    public String(string Value) => ValueAsString = $"\"{Value}\"";
    public String(SPWNExpr<String> Value) => ValueAsString = Value.CreateCode();
    public static implicit operator String(string str) => new(str);

    public Boolean Contains(String Substring)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "contains")
        .AddParameter("substr", Substring)
        .Build<Boolean>();

    public Boolean EndsWith(String Substring)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "ends_with")
        .AddParameter("substr", Substring)
        .Build<Boolean>();

    public Boolean Find(String Regex)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "find")
        .AddParameter("re", Regex)
        .Build<Boolean>();

    public Array<String> FindAll(String Regex)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "find_all")
        .AddParameter("re", Regex)
        .Build<Array<String>>();

    public String Fmt(String Subtitude)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "fmt")
        .AddParameter("subs", Subtitude)
        .Build<String>();

    public String Fmt(Array<String> Subtitude)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "fmt")
        .AddParameter("subs", Subtitude)
        .Build<String>();

    public String Format(String Subtitude)
        => Fmt(Subtitude);

    public String Format(Array<String> Subtitude)
        => Fmt(Subtitude);

    public Number Index(String SubString)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "index")
        .AddParameter("substr", SubString)
        .Build<Number>();

    public Number IndexOf(String SubString)
        => Index(SubString);


    public Boolean StartsWith(String Substring)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "starts_with")
        .AddParameter("substr", Substring)
        .Build<Boolean>();
}
