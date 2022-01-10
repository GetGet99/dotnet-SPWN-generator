namespace SPWN.DataTypes;
using InternalImplementation;
using Basics;

public class MacroAction : ISPWNValue
{
    public string ValueAsString { get; set; }
    public MacroAction(SPWNCodes MacroCode) => ValueAsString = $"!{{\n{MacroCode.CreateCodes().IndentOnce()}\n}}";
    public MacroAction(ISPWNExpr<MacroAction> Value) => ValueAsString = Value.CreateCode().IndentOnce();
    public ISPWNCode Invoke()
    {
        return new StringSPWNCode($"{ValueAsString}.()");
    }
}
public class MacroAction<T1> : ISPWNValue where T1 : class, ISPWNValue
{
    public string ValueAsString { get; set; }
    public MacroAction(string Var1Name, System.Func<T1, SPWNCodes> MacroCode)
    {
        StringSPWNExpr<T1> var1 = new(Var1Name);
        ValueAsString = $"({Var1Name}) {{\n{MacroCode.Invoke(var1.AsValue()).CreateCodes().IndentOnce()}\n}}";
    }
    public MacroAction(ISPWNExpr<MacroAction> Value) => ValueAsString = Value.CreateCode().IndentOnce();
    public ISPWNCode Invoke(T1 param)
    {
        return new StringSPWNCode($"{ValueAsString}.({param.ValueAsString})");
    }
}
public class MacroAction<T1,T2> : ISPWNValue where T1 : class, ISPWNValue where T2 : class, ISPWNValue
{
    public string ValueAsString { get; set; }
    public MacroAction(string Var1Name, string Var2Name, System.Func<T1, T2, SPWNCodes> MacroCode)
    {
        StringSPWNExpr<T1> var1 = new(Var1Name);
        StringSPWNExpr<T2> var2 = new(Var2Name);
        ValueAsString = $"({Var1Name}, {Var2Name}) {{\n{MacroCode.Invoke(var1.AsValue(), var2.AsValue()).CreateCodes().IndentOnce()}\n}}";
    }
    public MacroAction(ISPWNExpr<MacroAction> Value) => ValueAsString = Value.CreateCode().IndentOnce();
    public ISPWNCode Invoke(T1 param)
    {
        return new StringSPWNCode($"{ValueAsString}.({param.ValueAsString})");
    }
}
public class MacroAction<T1, T2, T3> : ISPWNValue where T1 : class, ISPWNValue where T2 : class, ISPWNValue where T3 : class, ISPWNValue
{
    public string ValueAsString { get; set; }
    public MacroAction(string Var1Name, string Var2Name, string Var3Name, System.Func<T1, T2, T3, SPWNCodes> MacroCode)
    {
        StringSPWNExpr<T1> var1 = new(Var1Name);
        StringSPWNExpr<T2> var2 = new(Var2Name);
        StringSPWNExpr<T3> var3 = new(Var3Name);
        ValueAsString = $"({Var1Name}, {Var2Name}, {Var3Name}) {{\n{MacroCode.Invoke(var1.AsValue(), var2.AsValue(), var3.AsValue()).CreateCodes().IndentOnce()}\n}}";
    }
    public MacroAction(ISPWNExpr<MacroAction> Value) => ValueAsString = Value.CreateCode().IndentOnce();
    public ISPWNCode Invoke(T1 param)
    {
        return new StringSPWNCode($"{ValueAsString}.({param.ValueAsString})");
    }
}
//public class MacroAction<T1,T2> : ISPWNValue where T1 : ISPWNValue where T2 : ISPWNValue
//{
//    public string ValueAsString { get; set; }
//    public MacroAction(SPWNCodes MacroCode) => ValueAsString = $"!{{\n{MacroCode.CreateCodes().IndentOnce()}\n}}";
//    public MacroAction(ISPWNExpr<MacroAction> Value) => ValueAsString = Value.CreateCode().IndentOnce();
//    public ISPWNCode Invoke(T1 param, T2 param2)
//    {
//        return new StringSPWNCode($"{ValueAsString}.({param.ValueAsString},{param2.ValueAsString})");
//    }
//}

//public class Macro<T> : ISPWNValue
//{
//    public string ValueAsString { get; set; }
//    public Macro(SPWNCodes MacroCode) => ValueAsString = $"!{{\n{MacroCode.CreateCodes().IndentOnce()}\n}}";
//    public Macro(ISPWNExpr<MacroAction> Value) => ValueAsString = Value.CreateCode().IndentOnce();
//}