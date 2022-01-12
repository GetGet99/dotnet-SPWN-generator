namespace SPWN.DataTypes;

using static SPWN.Basics.Extensions;
using SPWN.InternalImplementation;

public class Boolean : ISPWNValue
{
    public Boolean(bool Value) => this.ValueAsString = Value ? "true" : "false";

    public Boolean(ISPWNExpr<Boolean> Value) => ValueAsString = Value.CreateCode();

    public string ValueAsString { get; private set; }
   
}