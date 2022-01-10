namespace SPWNCreator.SPWN.Libraries;
using InternalImplementation;
using SPWN.DataTypes;
using static SPWN.Basics.Extensions;

public class Gamescene : Module
{

    public Gamescene() : base("gamescene") { }
    public Gamescene(ISPWNExpr<Gamescene> Value) => ValueAsString = Value.CreateCode().AddParenthesis();
    public GamesceneEvent ButtonA() => new ($"{ValueAsString}.button_a()");
    public GamesceneEvent ButtonAEnd() => new($"{ValueAsString}.button_a_end()");
    public GamesceneEvent ButtonB() => new($"{ValueAsString}.button_b()");
    public GamesceneEvent ButtonBEnd() => new($"{ValueAsString}.button_b_end()");

    public class GamesceneEvent : ISPWNValue
    {
        public string ValueAsString { get; set; }
        public GamesceneEvent(string Code)
        {
            ValueAsString = Code;
        }
        public ISPWNCode OnTriggered(MacroAction MacroValues)
        {
            return new StringSPWNCode($"{ValueAsString}.on_triggered({MacroValues.ValueAsString})");
        }
    }
}
