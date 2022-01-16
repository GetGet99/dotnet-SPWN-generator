﻿namespace SPWN.DataTypes;
using SPWN.InternalImplementation;
using Utils.Wrapper;
using Base;

[SPWNType("@number")]
public class Number : SPWNValueBase, IRangeImplemented, ICanBeConstant, ICanBeMutable
{
    public override string ValueAsString { get; protected set; }
    public Number(double Value) => ValueAsString = Value.ToString();
    public Number(SPWNExpr<Number> Value) => ValueAsString = Value.CreateCode();
    public static implicit operator Number(double d) => new(d);

    public Number Constrain(Number Min, Number Max)
        => new SPWNMethodCallBuilder<Number>($"{ValueAsString}.constrain")
        .AddParameter("min", Min)
        .AddParameter("max", Max)
        .Build<Number>();

    public Number Map(Number IStart, Number IStop, Number OStart, Number OStop)
        => new SPWNMethodCallBuilder<Number>($"{ValueAsString}.map")
        .AddParameter("istart", IStart)
        .AddParameter("istop", IStop)
        .AddParameter("ostart", OStart)
        .AddParameter("ostop", OStop)
        .Build<Number>();
}