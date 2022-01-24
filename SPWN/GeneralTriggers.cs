namespace SPWN.GeneralTriggers;

using InternalImplementation;
using Utilities.Wrapper;
using DataTypes;
using DataTypes.Base;
public static class Game
{
    public static SPWNCode Shake(Number? Strength = null, Number? Interval = null, Number? Duration = null)
    => new SPWNMethodCallBuilder<SPWNValueBase>("shake")
    .AddParameter("strength", Strength)
    .AddParameter("interval", Interval)
    .AddParameter("duration", Duration)
    .Build();

    public static SPWNCode DisableTrail()
        => new SPWNMethodCallBuilder<SPWNValueBase>("disable_trail")
        .Build();

    public static SPWNCode EnableTrail()
        => new SPWNMethodCallBuilder<SPWNValueBase>("enable_trail")
        .Build();

    public static SPWNCode ShowPlayer()
        => new SPWNMethodCallBuilder<SPWNValueBase>("show_player")
        .Build();

    public static SPWNCode HidePlayer()
        => new SPWNMethodCallBuilder<SPWNValueBase>("hide_player")
        .Build();

    public static SPWNCode ToggleBGEffect(Boolean? On = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>("toggle_bg_effect")
        .Build();

    public static SPWNCode ToggleBackgroundEffect(Boolean? On = null)
        => ToggleBGEffect(On: On);
}
public static class Triggers
{
    public static Object Move(Group Group, Number X, Number Y, Number? Duration = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>("move_trigger")
        .AddParameter("group", Group)
        .AddParameter("x", X)
        .AddParameter("y", Y)
        .AddParameter("duration", Duration)
        .Build<Object>();

    public static Object LockToPlayer(Group Group, Number LockX, Number LockY, Number? Duration = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>("lock_to_player_trigger")
        .AddParameter("group", Group)
        .AddParameter("lock_x", LockX)
        .AddParameter("lock_y", LockY)
        .AddParameter("duration", Duration)
        .Build<Object>();

    public static Object ToggleOn(Group Group, Number Opacity, Number? Duration = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>("toggle_on_trigger")
        .AddParameter("group", Group)
        .AddParameter("opacity", Opacity)
        .AddParameter("duration", Duration)
        .Build<Object>();

    public static Object ToggleOff(Group Group, Number Opacity, Number? Duration = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>("toggle_off_trigger")
        .AddParameter("group", Group)
        .AddParameter("opacity", Opacity)
        .AddParameter("duration", Duration)
        .Build<Object>();

    public static Object Rotate(Group Group, Group Center, Number Degrees, Number? Duration = null, EasingTypes Easing = EasingTypes.NONE, Number? EasingRate = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>("rotate_trigger")
        .AddParameter("group", Group)
        .AddParameter("center", Center)
        .AddParameter("degrees", Degrees)
        .AddParameter("duration", Duration)
        .AddParameter("easing", Easing)
        .AddParameter("easing_rate", EasingRate)
        .Build<Object>();

    public static Object Follow(Group Group, Group Other, Number XMod, Number YMod, Number? Duration = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>("lock_to_player_trigger")
        .AddParameter("group", Group)
        .AddParameter("other", Other)
        .AddParameter("x_mod", XMod)
        .AddParameter("y_mod", YMod)
        .AddParameter("duration", Duration)
        .Build<Object>();

    public static Object FollowPlayerY(Group Group, Number? Speed = null, Number? Delay = null, Number? Offset = null, Number? MaxSpeed = null, Number? Duration = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>("follow_player_y_trigger")
        .AddParameter("group", Group)
        .AddParameter("speed", Speed)
        .AddParameter("delay", Delay)
        .AddParameter("offset", Offset)
        .AddParameter("max_speed", MaxSpeed)
        .AddParameter("duration", Duration)
        .Build<Object>();

    public static Object MoveTo(Group Group, Group Target, Number? Duration = null, Boolean? XOnly = null, Boolean? YOnly = null, EasingTypes? Easing = null, Number? EasingRate = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>("move_to")
        .AddParameter("group", Group)
        .AddParameter("target", Target)
        .AddParameter("duration", Duration)
        .AddParameter("x_only", XOnly)
        .AddParameter("y_only", YOnly)
        .AddParameter("easing", Easing)
        .AddParameter("easing_rate", EasingRate)
        .Build<Object>();

    public static Object Pulse(UnionTypes<Group, Color> Target, Number R, Number G, Number B, Number? FadeIn = null, Number? Hold = null, Number? FadeOut = null, Boolean? Exclusive = null, Boolean? HSVMode = null, Boolean? SaturationChecked = null, Boolean? BrightnessChecked = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>("pulse_trigger")
        .AddParameter("target", Target)
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
        .Build<Object>();

    public static Object Color(Color Channel,Number R, Number G, Number B, Number? Duration = null, Number? Opacity = null, Boolean? Blending = null)
        => new SPWNMethodCallBuilder<SPWNValueBase>("color_trigger")
        .AddParameter("channel", Channel)
        .AddParameter("r", R)
        .AddParameter("g", G)
        .AddParameter("b", B)
        .AddParameter("duration", Duration)
        .AddParameter("opacity", Opacity)
        .AddParameter("blending", Blending)
        .Build<Object>();

    public static Object Pickup(Item ItemId, Number Amount)
        => new SPWNMethodCallBuilder<SPWNValueBase>("pickup_trigger")
        .AddParameter("item_id", ItemId)
        .AddParameter("amount", Amount)
        .Build<Object>();

    public static Object Spawn(Group Group, Number Delay)
        => new SPWNMethodCallBuilder<SPWNValueBase>("pickup_trigger")
        .AddParameter("group", Group)
        .AddParameter("delay", Delay)
        .Build<Object>();
}