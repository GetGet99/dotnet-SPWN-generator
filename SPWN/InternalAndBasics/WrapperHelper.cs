using System;
using System.Collections.Generic;

namespace SPWN.Utils.Wrapper;
using InternalImplementation;
using static SPWN.Basics.Extensions;

public partial class Extension
{
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
    public struct SPWNOperatorOverloadBuilder
    {
        string ValueAsString { get; }
        public SPWNOperatorOverloadBuilder(string Operator, ISPWNValue Left, ISPWNValue Right)
        {
            ValueAsString = $"{Left.ValueAsString.AddParenthesis()} {Operator} {Right.ValueAsString.AddParenthesis()}";
        }
        private StringSPWNExpr<T> BuildExpr<T>() where T : ISPWNValue
        {
            return new StringSPWNExpr<T>(ValueAsString);
        }
        public T Build<T>() where T : class, ISPWNValue
        {
            return BuildExpr<T>().AsValue();
        }
    }
}
