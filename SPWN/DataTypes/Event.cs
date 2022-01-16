namespace SPWN.DataTypes;
using InternalImplementation;
using Utils.Wrapper;
using Base;
[SPWNType("@event")]
public class Event : SPWNValueBase, ICanBeConstant, ICanBeMutable
{
    public override string ValueAsString { get; protected set; }
    public Event(string Code)
    {
        ValueAsString = Code;
    }
    public SPWNCode OnTriggered(TriggerFunction Function)
        => new SPWNMethodCallBuilder<Event>($"{ValueAsString}.on_triggered")
        .AddParameter("function", Function)
        .Build();
    public SPWNCode OnTriggered(Color Function)
        => new SPWNMethodCallBuilder<Event>($"{ValueAsString}.on_triggered")
        .AddParameter("function", Function)
        .Build();
    public SPWNCode OnTriggered(Group Function)
        => new SPWNMethodCallBuilder<Event>($"{ValueAsString}.on_triggered")
        .AddParameter("function", Function)
        .Build();
    //{
    //    return new StringSPWNCode($"{ValueAsString}.on_triggered({MacroValues.ValueAsString})");
    //}
}