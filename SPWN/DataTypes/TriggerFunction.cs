namespace SPWN.DataTypes;
using InternalImplementation;
using Basics;
using Base;
[SPWNType("@trigger_function")]
public class TriggerFunction : SPWNValueBase, ICanBeConstant, ICanBeMutable
{
    public override string ValueAsString { get; protected set; }
    public TriggerFunction(SPWNCodes MacroCode) => ValueAsString = $"!{{\n{MacroCode.CreateCode().IndentOnce()}\n}}";
    public TriggerFunction(SPWNExpr<TriggerFunction> Value) => ValueAsString = Value.CreateCode().IndentOnce();
    public SPWNCode Invoke()
    {
        return new StringSPWNCode($"{ValueAsString}.()");
    }
}

// These Macros will stay temperary

[SPWNType("@macro")]
public class Macro : SPWNValueBase
{
    public override string ValueAsString { get; protected set; }
    public Macro(System.Func<SPWNCodes> MacroCode)
    {
        ValueAsString = $"() {{\n{MacroCode.Invoke().CreateCode().IndentOnce()}\n}}";
    }
    public Macro(SPWNCodes MacroCode)
    {
        ValueAsString = $"() {{\n{MacroCode.CreateCode().IndentOnce()}\n}}";
    }
    public Macro(SPWNExpr<Macro> Value) => ValueAsString = Value.CreateCode().IndentOnce();
    public SPWNCode Invoke()
    {
        return new StringSPWNCode($"{ValueAsString}()");
    }
}
[SPWNType("@macro")]
public class MacroAction<T1> : SPWNValueBase where T1 : SPWNValueBase
{
    public override string ValueAsString { get; protected set; }
    public MacroAction(string Var1Name, System.Func<T1, SPWNCodes> MacroCode)
    {
        StringSPWNExpr<T1> var1 = new(Var1Name);
        ValueAsString = $"({Var1Name}) {{\n{MacroCode.Invoke(var1.AsValue()).CreateCode().IndentOnce()}\n}}";
    }
    public MacroAction(SPWNExpr<MacroAction<T1>> Value) => ValueAsString = Value.CreateCode().IndentOnce();
    public SPWNCode Invoke(T1 param)
    {
        return new StringSPWNCode($"{ValueAsString}.({param.ValueAsString})");
    }
}

// Not implemented yet
[SPWNType("@macro")]
public class MacroFunc<TOut> : SPWNValueBase where TOut : SPWNValueBase
{
    public override string ValueAsString { get; protected set; }
    //public MacroFunc(string Var1Name, System.Func<T1, SPWNCodes> MacroCode)
    //{
    //    StringSPWNExpr<T1> var1 = new(Var1Name);
    //    ValueAsString = $"({Var1Name}) {{\n{MacroCode.Invoke(var1.AsValue()).CreateCode().IndentOnce()}\n}}";
    //}
    public MacroFunc(SPWNExpr<MacroFunc<TOut>> Value) => ValueAsString = Value.CreateCode().IndentOnce();
    //public SPWNCode Invoke(T1 param)
    //{
    //    return new StringSPWNCode($"{ValueAsString}.({param.ValueAsString})");
    //}
}

// Not implemented yet
[SPWNType("@macro")]
public class MacroFunc<T1, TOut> : SPWNValueBase
    where T1 : SPWNValueBase
    where TOut : SPWNValueBase
{
    public override string ValueAsString { get; protected set; }
    //public MacroFunc(string Var1Name, System.Func<T1, SPWNCodes> MacroCode)
    //{
    //    StringSPWNExpr<T1> var1 = new(Var1Name);
    //    ValueAsString = $"({Var1Name}) {{\n{MacroCode.Invoke(var1.AsValue()).CreateCode().IndentOnce()}\n}}";
    //}
    public MacroFunc(SPWNExpr<MacroFunc<T1, TOut>> Value) => ValueAsString = Value.CreateCode().IndentOnce();
    //public SPWNCode Invoke(T1 param)
    //{
    //    return new StringSPWNCode($"{ValueAsString}.({param.ValueAsString})");
    //}
}
//public class MacroAction<T1,T2> : ISPWNValue where T1 : ISPWNValue where T2 : ISPWNValue
//{
//    public override string ValueAsString { get; protected set; }
//    public MacroAction(string Var1Name, string Var2Name, System.Func<T1, T2, SPWNCodes> MacroCode)
//    {
//        StringSPWNExpr<T1> var1 = new(Var1Name);
//        StringSPWNExpr<T2> var2 = new(Var2Name);
//        ValueAsString = $"({Var1Name}, {Var2Name}) {{\n{MacroCode.Invoke(var1.AsValue(), var2.AsValue()).CreateCodes().IndentOnce()}\n}}";
//    }
//    public MacroAction(SPWNExpr<MacroAction> Value) => ValueAsString = Value.CreateCode().IndentOnce();
//    public ISPWNCode Invoke(T1 param)
//    {
//        return new StringSPWNCode($"{ValueAsString}.({param.ValueAsString})");
//    }
//}
//public class MacroAction<T1, T2, T3> : ISPWNValue where T1 : ISPWNValue where T2 : ISPWNValue where T3 : ISPWNValue
//{
//    public override string ValueAsString { get; protected set; }
//    public MacroAction(string Var1Name, string Var2Name, string Var3Name, System.Func<T1, T2, T3, SPWNCodes> MacroCode)
//    {
//        StringSPWNExpr<T1> var1 = new(Var1Name);
//        StringSPWNExpr<T2> var2 = new(Var2Name);
//        StringSPWNExpr<T3> var3 = new(Var3Name);
//        ValueAsString = $"({Var1Name}, {Var2Name}, {Var3Name}) {{\n{MacroCode.Invoke(var1.AsValue(), var2.AsValue(), var3.AsValue()).CreateCodes().IndentOnce()}\n}}";
//    }
//    public MacroAction(SPWNExpr<MacroAction> Value) => ValueAsString = Value.CreateCode().IndentOnce();
//    public ISPWNCode Invoke(T1 param)
//    {
//        return new StringSPWNCode($"{ValueAsString}.({param.ValueAsString})");
//    }
//}
//public class MacroAction<T1,T2> : ISPWNValue where T1 : ISPWNValue where T2 : ISPWNValue
//{
//    public override string ValueAsString { get; protected set; }
//    public MacroAction(SPWNCodes MacroCode) => ValueAsString = $"!{{\n{MacroCode.CreateCodes().IndentOnce()}\n}}";
//    public MacroAction(SPWNExpr<MacroAction> Value) => ValueAsString = Value.CreateCode().IndentOnce();
//    public ISPWNCode Invoke(T1 param, T2 param2)
//    {
//        return new StringSPWNCode($"{ValueAsString}.({param.ValueAsString},{param2.ValueAsString})");
//    }
//}

//public class Macro<T> : ISPWNValue
//{
//    public override string ValueAsString { get; protected set; }
//    public Macro(SPWNCodes MacroCode) => ValueAsString = $"!{{\n{MacroCode.CreateCodes().IndentOnce()}\n}}";
//    public Macro(SPWNExpr<MacroAction> Value) => ValueAsString = Value.CreateCode().IndentOnce();
//}