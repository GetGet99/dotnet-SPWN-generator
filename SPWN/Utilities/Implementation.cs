namespace SPWN.Utilities.Implementation;
using SPWN.Basics;
using DataTypes;
using DataTypes.Base;
using SPWN.InternalImplementation;

static class Methods
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class CustomMethodImplementAttribute : System.Attribute
    {
        public string MacroName { get; set; }
        //public Macro? Macro { get; set; }
        public CustomMethodImplementAttribute(string MacroName)
        {
            this.MacroName = MacroName;
        }
    }
    public static SPWNCode Implement(TypeIndicator Type, System.Collections.Generic.Dictionary<string, SPWNValueBase> value) {
        // Reason of doing this: To avoid user to use a run-time dictionary, but also want to use the formatter of SPWN Dictionary
        return new StringSPWNCode($"impl {Type.ValueAsString} {{\n{new Dictionary<SPWNValueBase>(value).ValueAsString}\n}}");
    }
}
/*
public class CustomClass1 : SPWNValue
{
    public override string ValueAsString { get; protected set; } = "CustomClass1";

    readonly Macro CustomMethodMacro = new(new SPWNCodes
    {
        Comment("Just an example macro")
    });

    [CustomMethodImplement(nameof(CustomMethodMacro))]
    public SPWNCode CustomMethod()
        => new SPWNMethodCallBuilder(ValueAsString, nameof(CustomMethod))
        .Build();


    readonly Macro CustomMethodMacro2 = new(new SPWNCodes
    {
        Comment("Just another example macro")
    });

    [CustomMethodImplement(nameof(CustomMethodMacro))]
    public SPWNCode CustomMethod2()
        => new SPWNMethodCallBuilder(ValueAsString, nameof(CustomMethod2))
        .Build();
}
 */