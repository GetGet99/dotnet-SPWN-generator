namespace SPWN.Utils;

using CodeAnalysis = System.Diagnostics.CodeAnalysis;

using Basics;
using InternalImplementation;
public static class Extension
{
    public static SPWNCode NewLine(ushort times = 1) => new StringSPWNCode(new string('\n', times - 1));
    public static SPWNCode Comment(string s) => new StringSPWNCode($"// {s}");
    public static SPWNCode RunParallel(SPWNCode code) => new SPWNCodeParallel(code);
    //[System.Runtime.CompilerServices.CallerArgumentExpression("Variable")] 

    public static SPWNCode CreateConstantVariable<T>(string VariableName, [CodeAnalysis.NotNull] out T Constant, T Value) where T : class, ISPWNValue, ICanBeConstant, ICanBeMutable
    {
        //if (VariableName == null) throw new ArgumentNullException(null, nameof(VariableName));
        var newvar = new Variable<T>(Value, VariableName);
        SPWNCode code = newvar.InitConstant(out Constant);
        return code;
    }
    public static SPWNCode CreateMutableVariable<T>(string VariableName, [CodeAnalysis.NotNull] out Variable<T> Variable, T Value) where T : class, ISPWNValue, ICanBeMutable
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
