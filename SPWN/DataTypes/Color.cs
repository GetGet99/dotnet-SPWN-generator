namespace SPWN.DataTypes;

using InternalImplementation;
using Utilities.Wrapper;
using Base;
[SPWNType("@color")]
public class Color : SPWNValueBase, IRangeImplemented, IPulseAble<Color>, ICanBeConstant, ICanBeMutable
{
    public override string ValueAsString { get; protected set; }

    private Color() => ValueAsString = "?c";
    public Color(uint GroupId) => ValueAsString = $"{GroupId}c";
    public Color(SPWNExpr<Group> Value) => ValueAsString = Value.CreateCode();

    public static Color NextFree() => new();
    public static Color FromId(uint GroupId) => new(GroupId);

    public static implicit operator Color(uint Value) => new(Value);

    public SPWNCode Set(Number R, Number G, Number B, Number? Duration = null, Number? Opacity = null, Boolean? Blending = null)
        => new SPWNMethodCallBuilder<Block>($"{ValueAsString}.set")
        .AddParameter("r",R)
        .AddParameter("g",G)
        .AddParameter("b",B)
        .AddParameter("duration",Duration)
        .AddParameter("opacity",Opacity)
        .AddParameter("blending",Blending)
        .Build();
    public SPWNCode Pulse(Number R, Number G, Number B, Number? FadeIn = null, Number? Hold = null, Number? FadeOut = null, Boolean? Exclusive = null, Boolean? HSVMode = null, Boolean? SaturationChecked = null, Boolean? BrightnessChecked = null)
        => (this as IPulseAble<Color>).Pulse(R: R, G: G, B: B, FadeIn: FadeIn, Hold: Hold, FadeOut: FadeOut, Exclusive: Exclusive, HSVMode: HSVMode, SaturationChecked: SaturationChecked, BrightnessChecked: BrightnessChecked);
}
