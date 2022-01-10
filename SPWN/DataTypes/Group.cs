namespace SPWN.DataTypes;

using SPWN.Basics;
using SPWN.InternalImplementation;
using CodeAnalysis = System.Diagnostics.CodeAnalysis;
public class Group : ISPWNValue
{
    public string ValueAsString { get; set; }

    private Group() => ValueAsString = "?g";
    public Group(uint GroupId) => ValueAsString = $"{GroupId}g";
    public Group(ISPWNExpr<Group> Value) => ValueAsString = Value.CreateCode().AddParenthesis();

    public static Group NextFree() => new();
    public static Group FromId(uint GroupId) => new(GroupId);

    public static implicit operator Group(uint value) => new(value);

    
    public ISPWNCode Alpha(Number? Opacity = null, Number? Duration = null) => new StringSPWNCode($"{ValueAsString}.alpha({(Opacity ?? new Number(1)).ValueAsString}, {(Duration ?? new Number(0)).ValueAsString})");

    public ISPWNCode MoveTo(Group g) => new StringSPWNCode($"{ValueAsString}.move_to({g.ValueAsString})");
}
