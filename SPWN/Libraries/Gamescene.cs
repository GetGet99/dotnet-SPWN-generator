namespace SPWN.Libraries;
using InternalImplementation;
using SPWN.DataTypes;
using static SPWN.Basics.Extensions;

public class Gamescene : Module
{

    public Gamescene() : base("gamescene") { }
    public Gamescene(ISPWNExpr<Gamescene> Value) => ValueAsString = Value.CreateCode().AddParenthesis();
    public Event ButtonA() => new ($"{ValueAsString}.button_a()");
    public Event ButtonAEnd() => new($"{ValueAsString}.button_a_end()");
    public Event ButtonB() => new($"{ValueAsString}.button_b()");
    public Event ButtonBEnd() => new($"{ValueAsString}.button_b_end()");

    
}
