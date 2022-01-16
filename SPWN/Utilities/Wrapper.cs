using System;
using System.Collections.Generic;

namespace SPWN.Utilities.Wrapper;
using InternalImplementation;
using SPWN.DataTypes.Base;
using static SPWN.Basics.Extensions;

public struct SPWNMethodCallBuilder<SPWNType> where SPWNType : SPWNValueBase
{
    string MethodName { get; }
    List<string> ParamList { get; } = new List<string>();
    HashSet<Type> Types { get; } = new();
    public SPWNMethodCallBuilder(string MethodName)
    {
        this.MethodName = MethodName;
        AddTypeRef<SPWNType>();
    }
    public SPWNMethodCallBuilder(string ValueAsString, string MethodName)
    {
        this.MethodName = $"{ValueAsString}.{MethodName}";
        AddTypeRef<SPWNType>();
    }
    public SPWNMethodCallBuilder<SPWNType> AddParameter<T>(string ParamName, T? Value) where T : SPWNValueBase
    {
        if (Value == null) goto Return;
        AddTypeRef<T>();
        ParamList.Add($"{ParamName} = {Value.ValueAsString}");
    Return:
        return this;
    }
    public SPWNMethodCallBuilder<SPWNType> AddParameter(string ParamName, Enum? Value)
    {
        if (Value == null) goto Return;
        ParamList.Add($"{ParamName} = {Value}");
    Return:
        return this;
    }
    public SPWNMethodCallBuilder<SPWNType> AddTypeRef<T>()
    {
        Types.Add(typeof(T));
        return this;
    }
    public SPWNMethodCallBuilder<SPWNType> AddTypeRef(Type t)
    {
        Types.Add(t);
        return this;
    }
    public SPWNCode Build()
    {
        var code = new StringSPWNCode($"{MethodName}({ParamList.JoinString(",")})");

        foreach (var type in Types) code.AddTypeMentioned(type);

        return code;
    }
    private StringSPWNExpr<T> BuildExpr<T>() where T : SPWNValueBase
    {
        var expr = new StringSPWNExpr<T>($"{MethodName}({ParamList.JoinString(",")})");

        foreach (var type in Types) expr.AddTypeMentioned(type);
        expr.AddTypeMentioned(typeof(T));

        return expr;
    }
    public T Build<T>() where T : SPWNValueBase
    {
        return BuildExpr<T>().AsValue();
    }
}
public struct SPWNPropertySyntaxBuilder<SPWNType> where SPWNType : SPWNValueBase
{
    string PropertyName { get; }
    HashSet<Type> Types { get; } = new();
    public SPWNPropertySyntaxBuilder(string PropertyName)
    {
        this.PropertyName = PropertyName;
        AddTypeRef<SPWNType>();
    }
    public SPWNPropertySyntaxBuilder(string ValueAsString, string PropertyName)
    {
        this.PropertyName = $"{ValueAsString}.{PropertyName}";
        AddTypeRef<SPWNType>();
    }

    public SPWNPropertySyntaxBuilder<SPWNType> AddTypeRef<T>()
    {
        Types.Add(typeof(T));
        return this;
    }
    public SPWNPropertySyntaxBuilder<SPWNType> AddTypeRef(Type t)
    {
        Types.Add(t);
        return this;
    }

    private StringSPWNExpr<T> BuildExpr<T>() where T : SPWNValueBase
    {
        var expr = new StringSPWNExpr<T>($"{PropertyName}");
        AddTypeRef<T>();

        foreach (var type in Types) expr.AddTypeMentioned(type);

        return expr;
    }
    public T Build<T>() where T : SPWNValueBase
    {
        return BuildExpr<T>().AsValue();
    }
}
public struct SPWNArraySyntaxBuilder<SPWNType> where SPWNType : SPWNValueBase
{
    string ValueAsString { get; }
    List<string> ParamList { get; } = new List<string>();
    HashSet<Type> Types { get; } = new();
    public SPWNArraySyntaxBuilder(string ValueAsString)
    {
        this.ValueAsString = ValueAsString;
        AddTypeRef<SPWNType>();
    }
    public SPWNArraySyntaxBuilder<SPWNType> AddParameter<T>(string ParamName, T? Value) where T : SPWNValueBase
    {
        if (Value == null) goto Return;
        AddTypeRef<T>();
        ParamList.Add($"{ParamName} = {Value.ValueAsString}");
    Return:
        return this;
    }
    public SPWNArraySyntaxBuilder<SPWNType> AddParameter(string ParamName, Enum? Value)
    {
        if (Value == null) goto Return;
        ParamList.Add($"{ParamName} = {Value}");
    Return:
        return this;
    }
    public SPWNArraySyntaxBuilder<SPWNType> AddParameter(Enum? Value)
    {
        if (Value == null) goto Return;
        ParamList.Add(Value.ToString());
    Return:
        return this;
    }
    public SPWNArraySyntaxBuilder<SPWNType> AddParameter<T>(T? Value) where T : SPWNValueBase
    {
        if (Value == null) goto Return;
        ParamList.Add(Value.ValueAsString);
    Return:
        return this;
    }
    public SPWNArraySyntaxBuilder<SPWNType> AddTypeRef<T>()
    {
        Types.Add(typeof(T));
        return this;
    }
    public SPWNArraySyntaxBuilder<SPWNType> AddTypeRef(Type t)
    {
        Types.Add(t);
        return this;
    }
    private StringSPWNExpr<T> BuildExpr<T>() where T : SPWNValueBase
    {
        return new StringSPWNExpr<T>($"{ValueAsString}[{ParamList.JoinString(",")}]");
    }
    public T Build<T>() where T : SPWNValueBase
    {
        return BuildExpr<T>().AsValue();
    }
}
public struct SPWNOperatorOverloadBuilder<SPWNType> where SPWNType : SPWNValueBase
{
    HashSet<Type> Types { get; } = new();
    string ValueAsString { get; }
    public SPWNOperatorOverloadBuilder(string Operator, SPWNValueBase Left, SPWNValueBase Right)
    {
        ValueAsString = $"{Left.ValueAsString.AddParenthesis()} {Operator} {Right.ValueAsString.AddParenthesis()}";
        AddTypeRef<SPWNType>();
        AddTypeRef(Left.GetType());
        AddTypeRef(Right.GetType());
    }
    public SPWNOperatorOverloadBuilder<SPWNType> AddTypeRef<T>()
    {
        Types.Add(typeof(T));
        return this;
    }
    public SPWNOperatorOverloadBuilder<SPWNType> AddTypeRef(Type t)
    {
        Types.Add(t);
        return this;
    }
    private StringSPWNExpr<T> BuildExpr<T>() where T : SPWNValueBase => new (ValueAsString.ForceAddParenthesis());
    public T Build<T>() where T : SPWNValueBase => BuildExpr<T>().AsValue();
}
