namespace SPWNCreator.SPWN.DataTypes;

using InternalImplementation;
using Basics;

public class Module : ISPWNValue
{
    public string ValueAsString { get; set; } = "";
    public Module() { }
    public Module(string ModuleName) => ValueAsString = $"import {ModuleName}";
    public Module(ISPWNExpr<Module> Value) => ValueAsString = Value.CreateCode().AddParenthesis();
}
