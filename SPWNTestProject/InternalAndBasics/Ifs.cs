namespace SPWNCreator.SPWN;
using SPWN.Basics;
using SPWN.InternalImplementation;
using SPWN.DataTypes;

public static class Conditions
{
    public static ISPWNCode If(ISPWNExpr<Boolean> Expr, SPWNCodes Do, SPWNCodes? Else = null) {
        return new StringSPWNCode($"if {Expr.CreateCode()} {{\n{Do.CreateCodes().IndentOnce()}\n}}" +
            (Else == null ? "" : $" else {{\n{Else.CreateCodes().IndentOnce()}\n}}"));
    }
}