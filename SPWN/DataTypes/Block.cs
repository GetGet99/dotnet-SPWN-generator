namespace SPWN.DataTypes;

using TypeInternal;
using InternalImplementation;
using static Utils.Wrapper.Extension;
class Block : ISPWNValue, IRangeImplemented, IPulseAble, ICanBeConstant, ICanBeMutable
{
    public string ValueAsString { get; set; }

    private Block() => ValueAsString = "?b";
    public Block(uint GroupId) => ValueAsString = $"{GroupId}b";
    public Block(ISPWNExpr<Group> Value) => ValueAsString = Value.CreateCode();

    public static Block NextFree() => new();
    public static Block FromId(uint GroupId) => new(GroupId);

    public static implicit operator Block(uint Value) => new(Value);

    public Item CreateTrackerItem(Block Other)
        => new SPWNMethodCallBuilder($"{ValueAsString}.CreateTrackerItem")
        .AddParameter("other", Other)
        .Build<Item>();
}