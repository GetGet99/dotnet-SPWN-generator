namespace SPWN.DataTypes;
using InternalImplementation;
using Utilities.Wrapper;
using SPWN.DataTypes.Base;
using System.Text;

[SPWNType("@string")]
public class String : SPWNValueBase, IRangeImplemented, ICanBeConstant, ICanBeMutable
{
    static string ToLiteral(string input)
    {
        StringBuilder literal = new (input.Length + 2);
        literal.Append('"');
        foreach (var c in input)
        {
            switch (c)
            {
                case '\"': literal.Append("\\\""); break;
                case '\\': literal.Append(@"\\"); break;
                case '\0': literal.Append(@"\0"); break;
                case '\a': literal.Append(@"\a"); break;
                case '\b': literal.Append(@"\b"); break;
                case '\f': literal.Append(@"\f"); break;
                case '\n': literal.Append(@"\n"); break;
                case '\r': literal.Append(@"\r"); break;
                case '\t': literal.Append(@"\t"); break;
                case '\v': literal.Append(@"\v"); break;
                default:
                    // ASCII printable character
                    if (c >= 0x20 && c <= 0x7e)
                    {
                        literal.Append(c);
                        // As UTF16 escaped character
                    }
                    else
                    {
                        literal.Append(@"\u");
                        literal.Append(((int)c).ToString("x4"));
                    }
                    break;
            }
        }
        literal.Append('"');
        return literal.ToString();
    }
    public override string ValueAsString { get; protected set; }
    public String(string Value, bool AutoEscape = true) => ValueAsString = AutoEscape ? ToLiteral(Value) : $"\"{Value}\"";
    public String(SPWNExpr<String> Value) => ValueAsString = Value.CreateCode();
    public static implicit operator String(string str) => new(str);

    public Boolean IsEmpty
        => new SPWNMethodCallBuilder<String>(ValueAsString, "is_empty")
        .Build<Boolean>();

    public String SubStr(Number Start, Number End)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "substr")
        .AddParameter("start", Start)
        .AddParameter("end", End)
        .Build<String>();

    public String Join(Array List)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "join")
        .AddParameter("list", List)
        .Build<String>();

    public String Split(String SpStr)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "split")
        .AddParameter("spstr", SpStr)
        .Build<String>();

    public Boolean StartsWith(String Substring)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "starts_with")
        .AddParameter("substr", Substring)
        .Build<Boolean>();

    public Boolean EndsWith(String Substring)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "ends_with")
        .AddParameter("substr", Substring)
        .Build<Boolean>();

    public Number Index(String SubString)
    => new SPWNMethodCallBuilder<String>(ValueAsString, "index")
    .AddParameter("substr", SubString)
    .Build<Number>();

    public Number IndexOf(String SubString)
        => Index(SubString);

    public Boolean Contains(String Substring)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "contains")
        .AddParameter("substr", Substring)
        .Build<Boolean>();

    public String Reverse()
        => new SPWNMethodCallBuilder<String>(ValueAsString, "reverse")
        .Build<String>();

    public String Lowercase()
        => new SPWNMethodCallBuilder<String>(ValueAsString, "lowercase")
        .Build<String>();

    public String ToLowercase()
        => Lowercase();

    public String Uppercase()
        => new SPWNMethodCallBuilder<String>(ValueAsString, "uppercase")
        .Build<String>();

    public String ToUppercase()
        => Uppercase();

    public Boolean IsUpper
        => new SPWNMethodCallBuilder<String>(ValueAsString, "is_upper")
        .Build<Boolean>();

    public Boolean IsLower
        => new SPWNMethodCallBuilder<String>(ValueAsString, "is_lower")
        .Build<Boolean>();

    public String LPad(Number Times, String? Sequence = null)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "l_pad")
        .AddParameter("times", Times)
        .AddParameter("seq", Sequence)
        .Build<String>();

    public String LeftPad(Number Times, String? Sequence = null)
        => LPad(Times: Times, Sequence: Sequence);

    public String RPad(Number Times, String? Sequence = null)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "r_pad")
        .AddParameter("times", Times)
        .AddParameter("seq", Sequence)
        .Build<String>();

    public String RightPad(Number Times, String? Sequence = null)
        => RPad(Times: Times, Sequence: Sequence);

    public String LTrim(UnionTypes<String,Array<String>>? Tokens = null)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "l_trim")
        .AddParameter("tokens", Tokens)
        .Build<String>();

    public String LeftTrim(UnionTypes<String, Array<String>>? Tokens = null)
        => LTrim(Tokens: Tokens);

    public String RTrim(UnionTypes<String, Array<String>>? Tokens = null)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "r_trim")
        .AddParameter("tokens", Tokens)
        .Build<String>();

    public String RightTrim(UnionTypes<String, Array<String>>? Tokens = null)
        => RTrim(Tokens: Tokens);

    public String Trim(UnionTypes<String, Array<String>>? Tokens = null)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "trim")
        .AddParameter("tokens", Tokens)
        .Build<String>();

    public String Fmt(UnionTypes<SPWNValueBase, Array<SPWNValueBase>> Subtitude)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "fmt")
        .AddParameter("subs", Subtitude)
        .Build<String>();

    public String Fmt(SPWNValueBase Subtitude) => Fmt((UnionTypes<SPWNValueBase, Array<SPWNValueBase>>)Subtitude);

    public String Fmt(Array<SPWNValueBase> Subtitude) => Fmt((UnionTypes<SPWNValueBase, Array<SPWNValueBase>>)Subtitude);

    public String Format(UnionTypes<SPWNValueBase, Array<SPWNValueBase>> Subtitude)
        => Fmt(Subtitude);

    public String Format(SPWNValueBase Subtitude)
        => Fmt(Subtitude);

    public String Format(Array<SPWNValueBase> Subtitude)
        => Fmt(Subtitude);

    public Boolean Find(String Regex)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "find")
        .AddParameter("re", Regex)
        .Build<Boolean>();

    public Array<String> FindAll(String Regex)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "find_all")
        .AddParameter("re", Regex)
        .Build<Array<String>>();

    public String Replace(String Regex, String Replacement)
        => new SPWNMethodCallBuilder<String>(ValueAsString, "replace")
        .AddParameter("re", Regex)
        .AddParameter("replacement", Replacement)
        .Build<String>();

    public Object ToObject()
        => new SPWNMethodCallBuilder<String>(ValueAsString, "to_obj")
        .Build<Object>();

    public Boolean IsDigit()
        => new SPWNMethodCallBuilder<String>(ValueAsString, "isdigit")
        .Build<Boolean>();


    public static String operator +(String a, String b)
        => new SPWNOperatorOverloadBuilder<String>("+", a, b)
        .Build<String>();

    public static String operator *(String a, Number n)
        => new SPWNOperatorOverloadBuilder<String>("*", a, n)
        .Build<String>();
}