namespace SPWN.DataTypes;

using Base;
using InternalImplementation;
using Utilities.Wrapper;
[SPWNType("@block")]
class Block : SPWNValueBase, IRangeImplemented, IPulseAble<Block>, ICanBeConstant, ICanBeMutable
{
    public override string ValueAsString { get; protected set; }

    private Block() => ValueAsString = "?b";
    public Block(uint GroupId) => ValueAsString = $"{GroupId}b";
    public Block(SPWNExpr<Group> Value) => ValueAsString = Value.CreateCode();

    public static Block NextFree() => new();
    public static Block FromId(uint GroupId) => new(GroupId);

    public static implicit operator Block(uint Value) => new(Value);

    public Item CreateTrackerItem(Block Other)
        => new SPWNMethodCallBuilder<Block>($"{ValueAsString}.CreateTrackerItem")
        .AddParameter("other", Other)
        .Build<Item>();
    public SPWNCode Pulse(Number R, Number G, Number B, Number? FadeIn = null, Number? Hold = null, Number? FadeOut = null, Boolean? Exclusive = null, Boolean? HSVMode = null, Boolean? SaturationChecked = null, Boolean? BrightnessChecked = null)
        => (this as IPulseAble<Block>).Pulse(R: R, G: G, B: B, FadeIn: FadeIn, Hold: Hold, FadeOut: FadeOut, Exclusive: Exclusive, HSVMode: HSVMode, SaturationChecked: SaturationChecked, BrightnessChecked: BrightnessChecked);
}