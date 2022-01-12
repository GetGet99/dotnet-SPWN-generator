﻿namespace SPWN;
using SPWN.Basics;
using SPWN.InternalImplementation;
using SPWN.DataTypes;

public static class Conditions
{
    public static SPWNCode If(ISPWNExpr<Boolean> Expr, SPWNCodes Do, SPWNCodes? Else = null) {
        return new StringSPWNCode($"if {Expr.CreateCode()} {{\n{Do.CreateCode().IndentOnce()}\n}}" +
            (Else == null ? "" : $" else {{\n{Else.CreateCode().IndentOnce()}\n}}"));
    }
}