using System;
using System.Collections.Generic;
namespace SPWN.DataTypes.Base;

using Utils.Wrapper;

[SPWNType("@object")]
public abstract class SPWNValueBase
{
    public abstract string ValueAsString { get; protected set; }

    public IReadOnlySet<Type> TypesMentioned => _TypesMentioned;
    private readonly HashSet<Type> _TypesMentioned = new();
    public void AddTypeMentioned<T>() => AddTypeMentioned(typeof(T));
    public void AddTypeMentioned(Type t) => _TypesMentioned.Add(t);

    public String Type
        => new SPWNPropertySyntaxBuilder<SPWNValueBase>(ValueAsString, "type")
        .Build<String>();
}
