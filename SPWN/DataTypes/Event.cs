﻿namespace SPWN.DataTypes;
using InternalImplementation;
using static Basics.Extensions;

public class Event : ISPWNValue, ICanBeConstant, ICanBeMutable
{
    public string ValueAsString { get; set; }
    public Event(string Code)
    {
        ValueAsString = Code;
    }
    public ISPWNCode OnTriggered(TriggerFunction Function)
        => new SPWNMethodCallBuilder($"{ValueAsString}.on_triggered")
        .AddParameter("function", Function)
        .Build();
    public ISPWNCode OnTriggered(Color Function)
        => new SPWNMethodCallBuilder($"{ValueAsString}.on_triggered")
        .AddParameter("function", Function)
        .Build();
    public ISPWNCode OnTriggered(Group Function)
        => new SPWNMethodCallBuilder($"{ValueAsString}.on_triggered")
        .AddParameter("function", Function)
        .Build();
    //{
    //    return new StringSPWNCode($"{ValueAsString}.on_triggered({MacroValues.ValueAsString})");
    //}
}