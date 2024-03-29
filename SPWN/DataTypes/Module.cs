﻿namespace SPWN.DataTypes;

using InternalImplementation;
using Basics;
using Base;
using Utilities.Wrapper;
using static Utilities.Basics;
[SPWNType("@dictionary")]
public class Module : SPWNValueBase, ICanBeConstant, ICanBeMutable
{
    public override string ValueAsString { get; protected set; } = "";
    public Module() { }
    public Module(string ModuleName) => ValueAsString = $"import {ModuleName}";
    public Module(SPWNExpr<Module> Value) => ValueAsString = Value.CreateCode().AddParenthesis();
}


