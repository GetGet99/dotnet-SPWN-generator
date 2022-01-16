namespace SPWN.DataTypes;
using Base;
using Basics;
using SPWN.InternalImplementation;
using SPWN.Utilities.Wrapper;
// Unfinished
[SPWNType("@object")]
public class Object : SPWNValueBase
{
    public override string ValueAsString { get; protected set; } = "";
    public Object(SPWNExpr<Object> expr) => ValueAsString = expr.ValueAsString;

    public SPWNCode Set(ObjectKeys Key, SPWNValueBase Value)
        => new SPWNMethodCallBuilder<Object>(ValueAsString, "set")
        .AddParameter("key", Key)
        .AddParameter("value", Value)
        .Build();

    public Object With(ObjectKeys Key, SPWNValueBase Value)
        => new SPWNMethodCallBuilder<Object>(ValueAsString, "with")
        .AddParameter("key", Key)
        .AddParameter("value", Value)
        .Build<Object>();

    public SPWNCode AddGroups(UnionTypes<Group, Array<Group>> Groups)
        => new SPWNMethodCallBuilder<Object>(ValueAsString, "groups")
        .AddParameter("groups", Groups)
        .Build();

    public SPWNCode AddGroupsRange(Array<Group> Groups)
        => AddGroups(Groups);

    public SPWNCode Add()
        => new SPWNMethodCallBuilder<Object>(ValueAsString, "add")
        .Build();
}
