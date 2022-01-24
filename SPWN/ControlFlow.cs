namespace SPWN;
using DataTypes.Base;
using DataTypes;
using Utilities.Wrapper;
using InternalImplementation;
using Basics;
public static class ControlFlow
{
    public static SPWNCode Wait(UnionTypes<Number, Number.Epsilon>? Time = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>("wait")
        .AddParameter("time", Time)
        .Build();

    public static SPWNCode CallWithDelay(UnionTypes<Number, Number.Epsilon>? Time, UnionTypes<TriggerFunction, Group> Function)
        => new SPWNMethodCallBuilder<SPWNValueBase>("wait")
        .AddParameter("time", Time)
        .AddParameter("function", Function)
        .Build();

    public static SPWNCode SupressSignal(Number Delay)
        => new SPWNMethodCallBuilder<SPWNValueBase>("supress_signal")
        .AddParameter("delay", Delay)
        .Build();
    public static SPWNCode SupressSignalForever()
        => new SPWNMethodCallBuilder<SPWNValueBase>("supress_signal_forever")
        .Build();

    public static SPWNCode CompileTimeForLoop<T>(Range<T> Range, string VarName, System.Func<T, SPWNCode> Code) where T : SPWNValueBase, IRangeImplemented
        => new StringSPWNCode($"for {VarName} in {Range.ValueAsString} {{\n{Code.Invoke(new StringSPWNExpr<T>(VarName).AsValue())}\n}}");

    public static SPWNCode CompileTimeForLoop<T>(Array<T> Range, string VarName, System.Func<T, SPWNCode> Code) where T : SPWNValueBase
        => new StringSPWNCode($"for {VarName} in {Range.ValueAsString} {{\n{Code.Invoke(new StringSPWNExpr<T>(VarName).AsValue()).CreateCode().IndentOnce()}\n}}");

    public static SPWNCode RuntimeForLoop<T>(Range<T> Range, string VarName, MacroAction<T> Code, UnionTypes<Number, Number.Epsilon>? Delay = null, Boolean? Reset = null) where T : SPWNValueBase, IRangeImplemented
        => new SPWNMethodCallBuilder<SPWNValueBase>("for_loop")
        .AddParameter("range", Range)
        .AddParameter("code", Code)
        .AddParameter("delay", Delay)
        .AddParameter("reset", Reset)
        .Build();

    public static SPWNCode CompileTimeWhileLoop<T>(Boolean Boolean, SPWNCode Code) where T : SPWNValueBase, IRangeImplemented
        => new StringSPWNCode($"while {Boolean.ValueAsString} {{\n{Code}\n}}");
}
