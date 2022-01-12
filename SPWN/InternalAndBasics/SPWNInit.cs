using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
namespace SPWN.Basics
{
    using SPWN.InternalImplementation;

    public class SPWNLibrary
    {
    }
    public class SPWNClassesImplementation
    {

    }
    public class SPWNCodes : List<SPWNCode>
    {
        public SPWNCodes(params SPWNCode[] codes)
        {
            AddRange(codes);
        }
        public SPWNCodes(Func<IEnumerable<SPWNCode>> lambda)
        {
            AddRange(lambda.Invoke());
        }

        public string CreateCode()
        {
            return string.Join("\n", this.Apply(code => code == null ? "// [null command]" : code.CreateCode()));
        }
    }

    public static class SPWNUtils
    {
        public static SPWNCode NewLine(ushort times = 1) => new StringSPWNCode(new string('\n',times - 1));
        public static SPWNCode Comment(string s) => new StringSPWNCode($"// {s}");
        public static SPWNCode RunParallel(SPWNCode code) => new SPWNCodeParallel(code);
        //[System.Runtime.CompilerServices.CallerArgumentExpression("Variable")] 

        public static SPWNCode CreateConstantVariable<T>(string VariableName, [NotNull] out T Constant, T Value) where T : class, ISPWNValue, ICanBeConstant, ICanBeMutable
        {
            //if (VariableName == null) throw new ArgumentNullException(null, nameof(VariableName));
            var newvar = new Variable<T>(Value, VariableName);
            SPWNCode code = newvar.InitConstant(out Constant);
            return code;
        }
        public static SPWNCode CreateMutableVariable<T>(string VariableName, [NotNull] out Variable<T> Variable, T Value) where T : class, ISPWNValue, ICanBeMutable
        {
            //if (VariableName == null) throw new ArgumentNullException(null, nameof(VariableName));
            var newvar = new Variable<T>(Value, VariableName);
            SPWNCode code = newvar.InitMutable(out Variable);
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
        public static SPWNCodes ContinueWith(this SPWNCode SPWNCode, SPWNCode AnotherSPWNCode) => new()
        {
            SPWNCode,
            AnotherSPWNCode
        };
        public static SPWNCodes End(this SPWNCode SPWNCode) => new()
        {
            SPWNCode
        };
        public static SPWNCodes End(this SPWNCodes SPWNCodes) => SPWNCodes;
        public static SPWNCodes ContinueWith(this SPWNCodes SPWNCodes, SPWNCode AnotherSPWNCode)
        {
            SPWNCodes.Add(AnotherSPWNCode);
            return SPWNCodes;
        }
        public static SPWNCodes ContinueWithNoWait(this SPWNCodes SPWNCodes, SPWNCode AnotherSPWNCode)
        {
            SPWNCodes.Add(new SPWNCodeParallel(AnotherSPWNCode));
            return SPWNCodes;
        }
        public static SPWNCode InitMutable<T>(this Variable<T> Variable, [NotNull] out Variable<T> VariableToGetValue)
        where T : class, ISPWNValue, ICanBeMutable
        {
            VariableToGetValue = Variable;
            return Variable.GetInitializationCode();
        }
        public static SPWNCode InitConstant<T>(this Variable<T> Variable, [NotNull] out T Value)
        where T : class, ISPWNValue, ICanBeConstant, ICanBeMutable
        {
            Value = Variable.Value;
            return Variable.GetInitializationCode();
        }
        public static SPWNCode InitModule(this Variable<DataTypes.Module> Variable, out Variable<DataTypes.Module> Value)
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
        public struct SPWNMethodCallBuilder
        {
            string MethodName { get; }
            List<string> ParamList { get; } = new List<string>();
            public SPWNMethodCallBuilder(string MethodName)
            {
                this.MethodName = MethodName;
            }
            public SPWNMethodCallBuilder(string ValueAsString, string MethodName)
            {
                this.MethodName = $"{ValueAsString}.{MethodName}";
            }
            public SPWNMethodCallBuilder AddParameter<T>(string ParamName, T? Value) where T : ISPWNValue
            {
                if (Value == null) goto Return;
                ParamList.Add($"{ParamName} = {Value.ValueAsString}");
            Return:
                return this;
            }
            public SPWNMethodCallBuilder AddParameter(string ParamName, Enum? Value)
            {
                if (Value == null) goto Return;
                ParamList.Add($"{ParamName} = {Value}");
            Return:
                return this;
            }
            public StringSPWNCode Build()
            {
                return new StringSPWNCode($"{MethodName}({ParamList.JoinString(",")})");
            }
            private StringSPWNExpr<T> BuildExpr<T>() where T : ISPWNValue
            {
                return new StringSPWNExpr<T>($"{MethodName}({ParamList.JoinString(",")})");
            }
            public T Build<T>() where T : class, ISPWNValue
            {
                return BuildExpr<T>().AsValue();
            }
        }
        public struct SPWNPropertySyntaxBuilder
        {
            string MethodName { get; }
            public SPWNPropertySyntaxBuilder(string MethodName)
            {
                this.MethodName = MethodName;
            }
            public SPWNPropertySyntaxBuilder(string ValueAsString, string PropertyName)
            {
                this.MethodName = $"{ValueAsString}.{PropertyName}";
            }
            private StringSPWNExpr<T> BuildExpr<T>() where T : ISPWNValue
            {
                return new StringSPWNExpr<T>($"{MethodName}");
            }
            public T Build<T>() where T : class, ISPWNValue
            {
                return BuildExpr<T>().AsValue();
            }
        }
        public struct SPWNArraySyntaxBuilder
        {
            string ValueAsString { get; }
            List<string> ParamList { get; } = new List<string>();
            public SPWNArraySyntaxBuilder(string ValueAsString)
            {
                this.ValueAsString = ValueAsString;
            }
            public SPWNArraySyntaxBuilder AddParameter<T>(string ParamName, T? Value) where T : ISPWNValue
            {
                if (Value == null) goto Return;
                ParamList.Add($"{ParamName} = {Value.ValueAsString}");
            Return:
                return this;
            }
            public SPWNArraySyntaxBuilder AddParameter(string ParamName, Enum? Value)
            {
                if (Value == null) goto Return;
                ParamList.Add($"{ParamName} = {Value}");
            Return:
                return this;
            }
            public SPWNArraySyntaxBuilder AddParameter(Enum? Value)
            {
                if (Value == null) goto Return;
                ParamList.Add(Value.ToString());
            Return:
                return this;
            }
            public SPWNArraySyntaxBuilder AddParameter<T>(T? Value) where T : ISPWNValue
            {
                if (Value == null) goto Return;
                ParamList.Add(Value.ValueAsString);
            Return:
                return this;
            }
            private StringSPWNExpr<T> BuildExpr<T>() where T : ISPWNValue
            {
                return new StringSPWNExpr<T>($"{ValueAsString}[{ParamList.JoinString(",")}]");
            }
            public T Build<T>() where T : class, ISPWNValue
            {
                return BuildExpr<T>().AsValue();
            }
        }
    }
}
namespace SPWN.InternalImplementation
{
    public abstract class SPWNCode
    {
        public abstract string CreateCode();
        public static implicit operator Basics.SPWNCodes(SPWNCode code) => new(code);
    }
    
    public interface ISPWNValue
    {
        string ValueAsString { get; }
    }
    public interface ICanBeConstant
    {
        
    }
    public interface ICanBeMutable
    {

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
    public class StringSPWNCode : SPWNCode
    {
        readonly string code;
        public StringSPWNCode() => throw new NotImplementedException();
        public StringSPWNCode(string Code) => code = Code;
        public override string CreateCode() => code;
    }
    public class SPWNCodeParallel : SPWNCode
    {
        public override string CreateCode() => $"-> {CodeToRun.CreateCode()}";
        SPWNCode CodeToRun { get; set; }
        public SPWNCodeParallel() => throw new NotImplementedException();
        public SPWNCodeParallel(SPWNCode Code) => CodeToRun = Code;
    }
}