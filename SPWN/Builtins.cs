namespace SPWN.Builtins;
using DataTypes;
using DataTypes.Base;
using SPWN.InternalImplementation;
using Utilities.Wrapper;
static class Base
{
    public static readonly string Prefix = "$";
}
public static class Math
{
    // In the newest SPWN, you can do these operations with the number,
    // but you can't rn so I define it as extension method.
    public static Number Abs(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "abs")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Acos(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "acos")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Acosh(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "acosh")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Asin(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "asin")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Asinh(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "asinh")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Atan(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "atan")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Atan2(Number X, Number Y)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "atan2")
        .AddParameter("x", X)
        .AddParameter("y", Y)
        .Build<Number>();

    public static Number Atanh(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "atanh")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Cbrt(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "cbrt")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Ceil(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "ceil")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Cos(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "cos")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Cosh(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "cosh")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Exp(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "exp")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Exp2(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "exp2")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number ExpM1(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "exp_m1")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Floor(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "floor")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Fract(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "fract")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number GetFractionalPart(this Number N)
        => N.Fract();

    public static Number Hypot(Number A, Number B)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "hypot")
        .AddParameter("a", A)
        .AddParameter("b", B)
        .Build<Number>();

    public static Number Hypotenuse(Number A, Number B)
        => Hypot(A: A, B: B);

    public static Number Ln(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "ln")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Log(this Number N, Number Base)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Builtins.Base.Prefix, "floor")
        .AddParameter("n", N)
        .AddParameter("base", Base)
        .Build<Number>();

    public static Number Max(Number A, Number B)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "max")
        .AddParameter("a", A)
        .AddParameter("b", B)
        .Build<Number>();

    public static Number Min(Number A, Number B)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "min")
        .AddParameter("a", A)
        .AddParameter("b", B)
        .Build<Number>();

    public static Number Random()
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "random")
        .Build<Number>();

    public static T Random<T>(Array<T> Array) where T : SPWNValueBase
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "random")
        .AddNoNameParameter(Array)
        .Build<T>();

    public static Number Random(Number Start, Number End)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "random")
        .AddNoNameParameter(Start)
        .AddNoNameParameter(End)
        .Build<Number>();

    public static Number Round(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "round")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Sin(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "sin")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Sinh(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "sinh")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Sqrt(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "sqrt")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Tan(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "tan")
        .AddParameter("n", N)
        .Build<Number>();

    public static Number Tanh(this Number N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "tanh")
        .AddParameter("n", N)
        .Build<Number>();

}
public static class GeometryDash
{
    public static SPWNCode Add(Object N)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "add")
        .AddParameter("n", N)
        .Build();

    public static SPWNCode EditObj(Object O, ObjectKeys Key, SPWNValueBase Value)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "edit_obj")
        .AddParameter("o", O)
        .AddParameter("key", Key)
        .AddParameter("value", Value)
        .Build();

    public static SPWNCode EditObject(Object O, ObjectKeys Key, SPWNValueBase Value)
        => EditObj(O: O, Key: Key, Value: Value);

}
public static class Arrays
{
    public static SPWNCode Append<T>(Array<T> Array, T Value) where T : SPWNValueBase
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "append")
        .AddParameter("arr", Array)
        .AddParameter("val", Value)
        .Build();

    public static T Pop<T>(Array<T> Array) where T : SPWNValueBase
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "pop")
        .AddParameter("arr", Array)
        .Build<T>();

    public static T RemoveIndex<T>(Array<T> Array, Number Index) where T : SPWNValueBase
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "remove_index")
        .AddParameter("arr", Array)
        .AddParameter("index", Index)
        .Build<T>();
}

public static class Base64
{
    public static String Decode(String Base64String)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "b64decode")
        .AddParameter("s", Base64String)
        .Build<String>();
    public static String Encode(String String)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "b64encode")
        .AddParameter("s", String)
        .Build<String>();
}

public static class Strings
{
    public static String Regex()
        => throw new System.NotImplementedException();

    public static String SplitString(String S, String SubString)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "split_str")
        .AddParameter("s", S)
        .AddParameter("substr", SubString)
        .Build<String>();

    public static String Substr(String Value, Number StartIndex, Number EndIndex)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "substr")
        .AddParameter("val", Value)
        .AddParameter("start_index", StartIndex)
        .AddParameter("end_index", EndIndex)
        .Build<String>();
}

public static class CompileTime
{
    public static SPWNCode Assert(Boolean Boolean)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "assert")
        .AddParameter("b", Boolean)
        .Build();

    public static SPWNCode Display(this SPWNValueBase Value)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "display")
        .AddParameter("a", Value)
        .Build();

    public static SPWNCode ExtendTriggerFunc(Group Group, Macro Macro)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "extend_trigger_func")
        .AddParameter("group", Group)
        .AddParameter("mac", Macro)
        .Build();

    public static String GetInput(String? Prompt = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "get_input")
        .AddParameter("prompt", Prompt)
        .Build<String>();

    public static String HttpRequest(String Method, String Url, Dictionary Headers, String Body)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "http_request")
        .AddParameter("method", Method)
        .AddParameter("url", Url)
        .AddParameter("headers", Headers)
        .AddParameter("body", Body)
        .Build<String>();

    public static Boolean Matches(SPWNValueBase Value, Pattern Pattern)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "matches")
        .AddParameter("val", Value)
        .AddParameter("pattern", Pattern)
        .Build<Boolean>();

    public static Number Mutability(this SPWNValueBase Var)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "mutability")
        .AddParameter("var", Var)
        .Build<Number>();

    public static SPWNCode Print(this SPWNValueBase Value)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "print")
        .AddNoNameParameter(Value)
        .Build();

    public static String ReadFile(String FileName, String? FileFormat = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "readfile")
        .AddNoNameParameter(FileName)
        .AddNoNameParameter(FileFormat)
        .Build<String>();
   
    public static String SPWNVersion()
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "spwn_version")
        .Build<String>();

    public static Number Time()
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "time")
        .Build<Number>();

    public static Group TriggerFunctionContext()
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "trigger_fn_context")
        .Build<Group>();

    public static String WriteFile(String Path, String Data)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "writefile")
        .AddParameter("path", Path)
        .AddParameter("data", Data)
        .Build<String>();
}
public static class Operator
{
    public static SPWNCode Add(SPWNValueBase A, SPWNValueBase B)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_add_")
        .AddParameter("a", A)
        .AddParameter("b", B)
        .Build();

    public static SPWNValueBase And(SPWNValueBase A, SPWNValueBase B)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_and_")
        .AddParameter("a", A)
        .AddParameter("b", B)
        .Build<SPWNValueBase>();

    public static SPWNValueBase As(SPWNValueBase A, TypeIndicator Type)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_as_")
        .AddParameter("a", A)
        .AddParameter("t", Type)
        .Build<SPWNValueBase>();

    public static SPWNCode Assign(SPWNValueBase A, SPWNValueBase B)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_assign_")
        .AddParameter("a", A)
        .AddParameter("b", B)
        .Build();

    public static SPWNCode Decrement(Number A)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_decrement_")
        .AddParameter("a", A)
        .Build();

    public static String Display(SPWNValueBase A)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_display_")
        .AddParameter("a", A)
        .Build<String>();

    public static SPWNCode Divide(Number A, Number B)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_divide_")
        .AddParameter("a", A)
        .AddParameter("b", B)
        .Build();

    public static Number DividedBy(Number A, Number B)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_divided_by_")
        .AddParameter("a", A)
        .AddParameter("b", B)
        .Build<Number>();

    public static SPWNValueBase Either(SPWNValueBase A, SPWNValueBase B)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_either_")
        .AddParameter("a", A)
        .AddParameter("b", B)
        .Build<SPWNValueBase>();

    public static SPWNValueBase Equal(SPWNValueBase A, SPWNValueBase B)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_equal_")
        .AddParameter("a", A)
        .AddParameter("b", B)
        .Build<SPWNValueBase>();

    public static SPWNCode Exponate(SPWNValueBase A, SPWNValueBase B)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_exponate_")
        .AddParameter("a", A)
        .AddParameter("b", B)
        .Build();

    public static SPWNValueBase Has(SPWNValueBase A, SPWNValueBase B)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_has_")
        .AddParameter("a", A)
        .AddParameter("b", B)
        .Build<SPWNValueBase>();

    public static SPWNCode Increment(Number A)
        => new SPWNMethodCallBuilder<SPWNValueBase>(Base.Prefix, "_increment_")
        .AddParameter("a", A)
        .Build();
}