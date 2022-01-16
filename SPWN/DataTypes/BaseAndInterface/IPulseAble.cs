namespace SPWN.DataTypes.Base;

using DataTypes;
using InternalImplementation;
using Utils.Wrapper;
interface IPulseAble<SPWNType> where SPWNType : SPWNValueBase
{
    string ValueAsString { get; }
    SPWNCode Pulse(Number R, Number G, Number B, Number? FadeIn = null, Number? Hold = null, Number? FadeOut = null, Boolean? Exclusive = null, Boolean? HSVMode = null, Boolean? SaturationChecked = null, Boolean? BrightnessChecked = null)
        => new SPWNMethodCallBuilder<SPWNType>($"{ValueAsString}.pulse")
        .AddParameter("r", R)
        .AddParameter("g", G)
        .AddParameter("b", B)
        .AddParameter("fade_in", FadeIn)
        .AddParameter("hold", Hold)
        .AddParameter("fade_out", FadeOut)
        .AddParameter("exclusive", Exclusive)
        .AddParameter("hsv", HSVMode)
        .AddParameter("s_checked", SaturationChecked)
        .AddParameter("b_checked", BrightnessChecked)
        .Build();
}