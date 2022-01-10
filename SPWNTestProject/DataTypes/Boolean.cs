namespace SPWNCreator.SPWN.DataTypes;

using static SPWNCreator.SPWN.Basics.Extensions;
using SPWNCreator.SPWN.InternalImplementation;

public class Boolean : ISPWNValue
{
    public Boolean(bool Value) => this.ValueAsString = Value ? "true" : "false";

    public Boolean(ISPWNExpr<Boolean> Value) => ValueAsString = Value.CreateCode().AddParenthesis();

    public string ValueAsString { get; private set; }
   
}