using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
namespace SPWNCreator.SPWN.Basics
{
    using SPWNCreator.SPWN.InternalImplementation;

    public class SPWNLibrary
    {
    }
    public class SPWNClassesImplementation
    {

    }
    public class SPWNCodes : List<ISPWNCode>
    {
        public SPWNCodes(params ISPWNCode[] codes)
        {
            AddRange(codes);
        }
        public SPWNCodes(Func<IEnumerable<ISPWNCode>> lambda)
        {
            AddRange(lambda.Invoke());
        }
        public string CreateCodes()
        {
            return string.Join("\n", this.Apply(code => code == null ? "// [null command]" : code.CreateCode()));
        }
    }

    public static class SPWNUtils
    {
        public static ISPWNCode NewLine(ushort times = 1) => new StringSPWNCode(new string('\n',times - 1));
        public static ISPWNCode Comment(string s) => new StringSPWNCode($"// {s}");
        public static ISPWNCode NewVariable<T>(out T Variable, T Value, [System.Runtime.CompilerServices.CallerArgumentExpression("Variable")] string? VariableName = null) where T : class, ISPWNValue
        {
            var newvar = new Variable<T>(Value, VariableName);
            ISPWNCode code = newvar.Init(out Variable);
            return code;
        }
    }

    public static partial class Extensions
    {
        public static IEnumerable<TOut> Apply<TIn, TOut>([NotNull] this IEnumerable<TIn> In, [NotNull] Func<TIn?, TOut> Function)
        {
            foreach (var input in In) yield return Function.Invoke(input);
        }
        public static IEnumerable<TOut> Apply<TIn, TOut>([NotNull] this List<TIn> In, [NotNull] Func<TIn?, TOut> Function)
        {
            return (In as IEnumerable<TIn>).Apply(Function);
        }
        public static string IndentOnce(this string s)
        {
            return s.Split('\n').Apply(x => $"\t{x}").JoinString("\n");
        }
        public static string AddParenthesis(this string s)
        {
            return s.Contains(' ') ? $"({s})" : s;
        }
        public static string JoinString(this IEnumerable<object?> objects, string s)
        {
            return string.Join(s, objects);
        }
        public static SPWNCodes ContinueWith(this ISPWNCode SPWNCode, ISPWNCode AnotherSPWNCode) => new()
        {
            SPWNCode,
            AnotherSPWNCode
        };
        public static SPWNCodes End(this ISPWNCode SPWNCode) => new()
        {
            SPWNCode
        };
        public static SPWNCodes End(this SPWNCodes SPWNCodes) => SPWNCodes;
        public static SPWNCodes ContinueWith(this SPWNCodes SPWNCodes, ISPWNCode AnotherSPWNCode)
        {
            SPWNCodes.Add(AnotherSPWNCode);
            return SPWNCodes;
        }
        public static SPWNCodes ContinueWithNoWait(this SPWNCodes SPWNCodes, ISPWNCode AnotherSPWNCode)
        {
            SPWNCodes.Add(new SPWNCodeParallel(AnotherSPWNCode));
            return SPWNCodes;
        }
        public static ISPWNCode Init<T>(this Variable<T> Variable, out T Value)
        where T : class, ISPWNValue
        {
            Value = Variable.AsValue();
            return Variable.GetInitializationCode();
        }
        public static ISPWNCode InitModule(this Variable<DataTypes.Module> Variable, out Variable<DataTypes.Module> Value)
        {
            Value = Variable;
            return Variable.GetInitializationCode();
        }
        public static T AsValue<T>(this ISPWNExpr<T> expr) where T : class, ISPWNValue
        {
            Type t = typeof(T);
            var constructor = t.GetConstructor(new Type[] { typeof(ISPWNExpr<T>) });
            if (constructor == null) throw new ArgumentException("T does not have constructor with T(ISPWNExpr<T>)");
            if (constructor.Invoke(new object[] { expr }) is not T toreturn) throw new ArgumentException("Error when creating, returning <null>");
            return toreturn;
        }
    }
}
namespace SPWNCreator.SPWN.InternalImplementation
{
    public interface ISPWNCode
    {
        public string CreateCode();
    }
    public interface ISPWNVariable
    {
        ISPWNCode GetInitializationCode();
    }
    public interface ISPWNValue
    {
        string ValueAsString { get; }
    }
    public interface ISPWNExpr<T> where T : ISPWNValue
    {
        public string CreateCode();
    }
    public struct StringSPWNExpr<T> : ISPWNExpr<T> where T : ISPWNValue
    {
        readonly string code;
        public StringSPWNExpr() => throw new NotImplementedException();
        public StringSPWNExpr(string Code) => code = Code;
        public string CreateCode() => code;
    }
    public struct StringSPWNCode : ISPWNCode
    {
        readonly string code;
        public StringSPWNCode() => throw new NotImplementedException();
        public StringSPWNCode(string Code) => code = Code;
        public string CreateCode() => code;
    }
    public struct SPWNCodeParallel : ISPWNCode
    {
        public string CreateCode() => $"-> {CodeToRun.CreateCode()}";
        ISPWNCode CodeToRun { get; set; }
        public SPWNCodeParallel() => throw new NotImplementedException();
        public SPWNCodeParallel(ISPWNCode Code) => CodeToRun = Code;
    }
}