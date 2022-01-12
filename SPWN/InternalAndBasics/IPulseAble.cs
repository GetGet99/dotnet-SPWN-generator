using SPWN.DataTypes;
using SPWN.InternalImplementation;
using static SPWN.Basics.Extensions;

namespace SPWN.Basics;
interface IPulseAble : ISPWNValue
{

    SPWNCode Pulse(Number R, Number G, Number B, Number? FadeIn = null, Number? Hold = null, Number? FadeOut = null, Boolean? Exclusive = null, Boolean? HSVMode = null, Boolean? SaturationChecked = null, Boolean? BrightnessChecked = null)
        => new SPWNMethodCallBuilder($"{ValueAsString}.pulse")
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