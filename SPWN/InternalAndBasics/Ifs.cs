namespace SPWN;
using SPWN.Basics;
using SPWN.InternalImplementation;
using SPWN.DataTypes;

public static class Conditions
{
    public static SPWNCode If(Boolean Boolean, SPWNCodes Do, SPWNCodes? Else = null) {
        return new StringSPWNCode($"if {Boolean.ValueAsString} {{\n{Do.CreateCode().IndentOnce()}\n}}" +
            (Else == null ? "" : $" else {{\n{Else.CreateCode().IndentOnce()}\n}}"));
    }
}