namespace SPWN.DataTypes;

using TypeInternal;
using InternalImplementation;
using static Utils.Wrapper.Extension;
public class Item : ISPWNValue, IRangeImplemented, IPulseAble, ICanBeConstant, ICanBeMutable
{
    public string ValueAsString { get; set; }

    private Item() => ValueAsString = "?i";
    public Item(uint GroupId) => ValueAsString = $"{GroupId}i";
    public Item(ISPWNExpr<Group> Value) => ValueAsString = Value.CreateCode();

    public static Item NextFree() => new();
    public static Item FromId(uint GroupId) => new(GroupId);

    public static implicit operator Item(uint Value) => new(Value);

    public SPWNCode Add(Number Amount)
        => new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("amount", Amount)
        .Build();

    public Event Count(Number? Number = null)
        => new SPWNMethodCallBuilder($"{ValueAsString}.count")
        .AddParameter("number", Number)
        .Build<Event>();

    public SPWNCode IfIs(Comparisons Comparison,Number Other, TriggerFunction Function)
        => new SPWNMethodCallBuilder($"{ValueAsString}.if_is")
        .AddParameter("comparison", Comparison)
        .AddParameter("other", Other)
        .AddParameter("function", Function)
        .Build();
}