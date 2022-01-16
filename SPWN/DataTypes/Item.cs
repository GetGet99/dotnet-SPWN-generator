namespace SPWN.DataTypes;

using InternalImplementation;
using Utils.Wrapper;
using Base;
[SPWNType("@item")]
public class Item : SPWNValueBase, IRangeImplemented, IPulseAble<Item>, ICanBeConstant, ICanBeMutable
{
    public override string ValueAsString { get; protected set; }

    private Item() => ValueAsString = "?i";
    public Item(uint GroupId) => ValueAsString = $"{GroupId}i";
    public Item(SPWNExpr<Group> Value) => ValueAsString = Value.CreateCode();

    public static Item NextFree() => new();
    public static Item FromId(uint GroupId) => new(GroupId);

    public static implicit operator Item(uint Value) => new(Value);

    public SPWNCode Add(Number Amount)
        => new SPWNMethodCallBuilder<Item>($"{ValueAsString}.add")
        .AddParameter("amount", Amount)
        .Build();

    public Event Count(Number? Number = null)
        => new SPWNMethodCallBuilder<Item>($"{ValueAsString}.count")
        .AddParameter("number", Number)
        .Build<Event>();

    public SPWNCode IfIs(Comparisons Comparison,Number Other, TriggerFunction Function)
        => new SPWNMethodCallBuilder<Item>($"{ValueAsString}.if_is")
        .AddParameter("comparison", Comparison)
        .AddParameter("other", Other)
        .AddParameter("function", Function)
        .Build();

    public SPWNCode Pulse(Number R, Number G, Number B, Number? FadeIn = null, Number? Hold = null, Number? FadeOut = null, Boolean? Exclusive = null, Boolean? HSVMode = null, Boolean? SaturationChecked = null, Boolean? BrightnessChecked = null)
        => (this as IPulseAble<Item>).Pulse(R: R, G: G, B: B, FadeIn: FadeIn, Hold: Hold, FadeOut: FadeOut, Exclusive: Exclusive, HSVMode: HSVMode, SaturationChecked: SaturationChecked, BrightnessChecked: BrightnessChecked);
}