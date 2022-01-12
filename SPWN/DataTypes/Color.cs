namespace SPWN.DataTypes;

using TypeInternal;
using InternalImplementation;
using static Utils.Wrapper.Extension;
public class Color : ISPWNValue, IRangeImplemented, IPulseAble, ICanBeConstant, ICanBeMutable
{
    public string ValueAsString { get; set; }

    private Color() => ValueAsString = "?c";
    public Color(uint GroupId) => ValueAsString = $"{GroupId}c";
    public Color(ISPWNExpr<Group> Value) => ValueAsString = Value.CreateCode();

    public static Color NextFree() => new();
    public static Color FromId(uint GroupId) => new(GroupId);

    public static implicit operator Color(uint Value) => new(Value);

    public SPWNCode Set(Number R, Number G, Number B, Number? Duration = null, Number? Opacity = null, Boolean? Blending = null)
        => new SPWNMethodCallBuilder($"{ValueAsString}.set")
        .AddParameter("r",R)
        .AddParameter("g",G)
        .AddParameter("b",B)
        .AddParameter("duration",Duration)
        .AddParameter("opacity",Opacity)
        .AddParameter("blending",Blending)
        .Build();
}
