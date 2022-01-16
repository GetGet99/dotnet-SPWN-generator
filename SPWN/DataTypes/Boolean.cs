namespace SPWN.DataTypes;

using static SPWN.Basics.Extensions;
using SPWN.InternalImplementation;
using Base;
[SPWNType("@bool")]
public class Boolean : SPWNValueBase
{
    public Boolean(bool Value) => this.ValueAsString = Value ? "true" : "false";

    public Boolean(SPWNExpr<Boolean> Value) => ValueAsString = Value.CreateCode();

    public override string ValueAsString { get; protected set; }
   
}