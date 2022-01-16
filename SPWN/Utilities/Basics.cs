namespace SPWN.Utilities;

using CodeAnalysis = System.Diagnostics.CodeAnalysis;
using CompilerServices = System.Runtime.CompilerServices;

using SPWN.Basics;
using InternalImplementation;
using SPWN.DataTypes.Base;

public static class Basics
{
    public static SPWNCode NewLine(ushort times = 1) => new StringSPWNCode(new string('\n', times - 1));
    public static SPWNCode Comment(string s) => new StringSPWNCode($"// {s}");
    public static SPWNCode RunParallel(SPWNCode code) => new SPWNCodeParallel(code);
    //[System.Runtime.CompilerServices.CallerArgumentExpression("Variable")] 

    public static SPWNCode CreateConstantVariable<T>(string VariableName, [CodeAnalysis.NotNull] out T Constant, T Value) where T : SPWNValueBase, ICanBeConstant
    {
        //if (VariableName == null) throw new ArgumentNullException(null, nameof(VariableName));
        var newvar = new Variable<T>(Value, VariableName);
        SPWNCode code = newvar.InitConstant(out Constant);
        return code;
    }
    public static SPWNCode CreateMutableVariable<T>(string VariableName, [CodeAnalysis.NotNull] out Variable<T> Variable, T Value) where T : SPWNValueBase, ICanBeMutable
    {
        //if (VariableName == null) throw new ArgumentNullException(null, nameof(VariableName));
        var newvar = new Variable<T>(Value, VariableName);
        SPWNCode code = newvar.InitMutable(out Variable);
        return code;
    }
    public static SPWNCode? RunDotNetCode(System.Action Action)
    {
        Action.Invoke();
        return null;
    }
    public static SPWNCode? RunDotNetCode(System.Func<SPWNCode> Function)
    {
        return Function.Invoke();
    }
}

public static class ExperimentalFeatures
{
    public static SPWNCode CreateConstantVariable<T>(out T Constant, T Value, [CompilerServices.CallerArgumentExpression("Constant")] string? VariableName = null) where T : SPWNValueBase, ICanBeConstant
    {
        if (VariableName == null) throw new System.ArgumentNullException(nameof(VariableName));
        VariableName = VariableName.Split(" ")[^1];

        var newvar = new Variable<T>(Value, VariableName);
        SPWNCode code = newvar.InitConstant(out Constant);
        return code;
    }
    public static SPWNCode CreateMutableVariable<T>([CodeAnalysis.NotNull] out Variable<T> OutVariable, T Value, [CompilerServices.CallerArgumentExpression("OutVariable")] string? VariableName = null) where T : SPWNValueBase, ICanBeMutable
    {
        if (VariableName == null) throw new System.ArgumentNullException(nameof(VariableName));
        VariableName = VariableName.Split(" ")[^1];

        var newvar = new Variable<T>(Value, VariableName);
        SPWNCode code = newvar.InitMutable(out OutVariable);
        return code;
    }
}