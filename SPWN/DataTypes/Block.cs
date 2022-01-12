namespace SPWN.DataTypes;

using Basics;
using InternalImplementation;
using static Basics.Extensions;
class Block : ISPWNValue, IRangeImplemented, IPulseAble, ICanBeConstant, ICanBeMutable
{
    public string ValueAsString { get; set; }

    private Block() => ValueAsString = "?b";
    public Block(uint GroupId) => ValueAsString = $"{GroupId}b";
    public Block(ISPWNExpr<Group> Value) => ValueAsString = Value.CreateCode().AddParenthesis();

    public static Block NextFree() => new();
    public static Block FromId(uint GroupId) => new(GroupId);

    public static implicit operator Block(uint Value) => new(Value);

    public Item CreateTrackerItem(Block Other)
        => new SPWNMethodCallBuilder($"{ValueAsString}.CreateTrackerItem")
        .AddParameter("other", Other)
        .Build<Item>();
}