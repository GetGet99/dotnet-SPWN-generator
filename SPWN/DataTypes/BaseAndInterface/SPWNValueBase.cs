using System;
using System.Collections.Generic;
namespace SPWN.DataTypes.Base;

using Utilities.Wrapper;

public abstract class SPWNValueBase
{
    public abstract string ValueAsString { get; protected set; }

    public IReadOnlySet<Type> TypesMentioned => _TypesMentioned;
    private readonly HashSet<Type> _TypesMentioned = new();
    public void AddTypeMentioned<T>() => AddTypeMentioned(typeof(T));
    public void AddTypeMentioned(Type t) => _TypesMentioned.Add(t);

    public TypeIndicator Type
        => new SPWNPropertySyntaxBuilder<SPWNValueBase>(ValueAsString, "type")
        .Build<TypeIndicator>();

    public override string ToString() => ValueAsString;
}
