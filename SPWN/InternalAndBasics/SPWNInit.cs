using SPWN.DataTypes;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using SPWN.DataTypes.Base;
namespace SPWN.Basics
{
    using SPWN.DataTypes;
    using SPWN.InternalImplementation;

    //public class SPWNLibrary
    //{
    //}
    //public class SPWNClassesImplementation
    //{

    //}
    public class SPWNCodes : List<SPWNCode?>
    {
        public IReadOnlySet<Type> TypesMentioned
        {
            get
            {
                var list = new HashSet<Type>();
                foreach (var code in this)
                {
                    if (code == null) continue;
                    foreach (var type in code.TypesMentioned)
                        list.Add(type);
                }
                return list;
            }
        }
        public SPWNCodes(params SPWNCode?[] codes)
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
        public override string ToString() => CreateCode();
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
        public static string ForceAddParenthesis(this string s)
        {
            return s.Contains(' ') ? $"({s})" : s;
        }
        public static string AddParenthesis(this string s)
        {
            if (s.StartsWith('(') && s.EndsWith(')'))
            {
                var OpenBracketCount = 0;
                var CloseBracketCount = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];
                    if (c == '(') OpenBracketCount++;
                    if (c == ')') CloseBracketCount++;
                    if (OpenBracketCount > 0 && OpenBracketCount == CloseBracketCount)
                        goto Add;
                }
                goto DoNotAdd; // Already Has Parenthesis
            }

            if (!s.Contains(' ')) goto DoNotAdd; // A Variable OR Function Call with 1 args

            if (System.Text.RegularExpressions.Regex.IsMatch(s, @"^(\w+(\.((\w+\([^\)]*\))|(\w+)))*)$",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase)) goto DoNotAdd; // It's the method call and/or property (not perfect but works most of the time)

            goto Add;
        Add:
            return s.ForceAddParenthesis();
        DoNotAdd:
            return s;
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
        where T : SPWNValueBase, ICanBeMutable
        {
            VariableToGetValue = Variable;
            return Variable.GetInitializationCode(Mutable: true);
        }
        public static SPWNCode InitConstant<T>(this Variable<T> Variable, [NotNull] out T Value)
        where T : SPWNValueBase, ICanBeConstant
        {
            Value = Variable.Value;
            return Variable.GetInitializationCode(Mutable: false);
        }

        public static T AsValue<T>(this SPWNExpr<T> expr) where T : SPWNValueBase
        {
            Type t = typeof(T);
            var constructor = t.GetConstructor(new Type[] { typeof(SPWNExpr<T>) });
            if (constructor == null) throw new ArgumentException("T does not have constructor with T(SPWNExpr<T>)");
            if (constructor.Invoke(new object[] { expr }) is not T toreturn) throw new ArgumentException("Error when creating, returning <null>");

            foreach (var type in expr.TypesMentioned) toreturn.AddTypeMentioned(type);

            return toreturn;
        }

    }
}
namespace SPWN.InternalImplementation
{
    public abstract class SPWNCode
    {
        public IReadOnlySet<Type> TypesMentioned => _TypesMentioned;
        private readonly HashSet<Type> _TypesMentioned = new();
        public void AddTypeMentioned<T>() => AddTypeMentioned(typeof(T));
        public void AddTypeMentioned(Type t) => _TypesMentioned.Add(t);

        public abstract string CreateCode();
        public static implicit operator Basics.SPWNCodes(SPWNCode code) => new(code);

        public override string ToString() => CreateCode();
    }

    
    public interface ICanBeConstant
    {

    }
    public interface ICanBeMutable
    {

    }
    public abstract class SPWNExpr<T> where T : SPWNValueBase
    {
        public string ValueAsString { get; set; } = "";
        public IReadOnlySet<Type> TypesMentioned => _TypesMentioned;
        private readonly HashSet<Type> _TypesMentioned = new();
        public void AddTypeMentioned<T1>() where T1 : SPWNValueBase
        {
            Type t = typeof(T1);
            _TypesMentioned.Add(t);
        }
        public void AddTypeMentioned(Type t)
        {
            _TypesMentioned.Add(t);
        }
        public abstract string CreateCode();
    }
    class StringSPWNExpr<T> : SPWNExpr<T> where T : SPWNValueBase
    {
        readonly string code;
        public StringSPWNExpr() => throw new NotImplementedException();
        public StringSPWNExpr(string Code) => code = Code;
        public override string CreateCode() => code;
    }
    // Only use internally
    class StringSPWNCode : SPWNCode
    {
        readonly string code;
        public StringSPWNCode(string Code) => code = Code;



        public override string CreateCode() => code;

    }
    public class UnsafeStringSPWNCode : SPWNCode
    {
        /**
         * <summary>
         * By using the UnsafeStringSPWNCode, you agree that the code might come out as unexpected. And you can inject any code you want.
         * Even if it does not have correct syntax.
         * </summary>
         */
        public static bool AllowUnsafeCodeFromString { get; set; } = false;
        readonly string code;
        public UnsafeStringSPWNCode(string Code)
        {
            if (!AllowUnsafeCodeFromString) throw new NotSupportedException("You should avoid using UnsafeCodeFromString class, as it can inject any code you want. " +
                "Even if it does not have a correct Syntax\n" +
                "If you're sure about using this, set UnsafeStringSPWNCode.AllowUnsafeCodeFromString to true");
            code = Code;
        }
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