namespace SPWN.DataTypes;

using TypeInternal;
using SPWN.InternalImplementation;
using static Utils.Wrapper.Extension;
public class Group : ISPWNValue, IRangeImplemented, IPulseAble, ICanBeConstant, ICanBeMutable
{
    public string ValueAsString { get; set; }

    private Group() => ValueAsString = "?g";
    public Group(uint GroupId) => ValueAsString = $"{GroupId}g";
    public Group(ISPWNExpr<Group> Value) => ValueAsString = Value.CreateCode();

    public static Group NextFree() => new();
    public static Group FromId(uint GroupId) => new(GroupId);

    public static implicit operator Group(uint Value) => new(Value);

    /**
     * <summary>
     * Implementation of the alpha trigger
     * </summary>
     */
    public SPWNCode Alpha(Number? Opacity = null, Number? Duration = null)
        => new SPWNMethodCallBuilder($"{ValueAsString}.alpha")
        .AddParameter("opacity", Opacity)
        .AddParameter("duration", Duration)
        .Build();

    /**
     * <summary>
     * Implementation of the follow trigger
     * </summary>
     * <param name="Other">Group of object to follow</param>
     * <param name="XMod">Multiplier for the movement on the X-axis (Default: 1)</param>
     * <param name="YMod">Multiplier for the movement on the Y-axis (Default: 1)</param>
     * <param name="Duration">Duration of following (Default: 999)</param>
     */
    public SPWNCode Follow(Group Other, Number? XMod = null, Number? YMod = null, Number? Duration = null)
        => new SPWNMethodCallBuilder($"{ValueAsString}.follow")
        .AddParameter("other", Other)
        .AddParameter("x_mod", XMod)
        .AddParameter("y_mod", YMod)
        .AddParameter("duration", Duration)
        .Build();

    /**
     * <summary>
     * Keeps an object's position proportionally between 2 others
     * </summary>
     * <param name="GroupA">Group of object A to follow</param>
     * <param name="GroupB">Group of object B to follow</param>
     * <param name="Weight">??? (Default: 0.5)</param>
     * <param name="Duration">Duration of following (Default: 999)</param>
     */
    public SPWNCode FollowLerp(Group GroupA, Group GroupB, Number? Weight = null, Number? Duration = null)
        => new SPWNMethodCallBuilder($"{ValueAsString}.follow_lerp")
        .AddParameter("groupA", GroupA)
        .AddParameter("groupB", GroupB)
        .AddParameter("weight", Weight)
        .AddParameter("duration", Duration)
        .Build();
    /**
     * <summary>
     * Implementation of the follow player Y trigger
     * </summary>
     * <param name="Speed">Interpolation factor (?) (Default: 1)</param>
     * <param name="Delay">Delay of movement (Default: 0)</param>
     * <param name="Offset">Offset on the Y-axis (Default: 0)</param>
     * <param name="MaxSpeed">Maximum speed (Default: 0)</param>
     * <param name="Duration">Duration of following (Default: 999)</param>
     */
    public SPWNCode FollowPlayerY(Number? Speed = null, Number? Delay = null, Number? Offset = null, Number? MaxSpeed = null, Number? Duration = null)
        => new SPWNMethodCallBuilder($"{ValueAsString}.follow_lerp")
        .AddParameter("speed", Speed)
        .AddParameter("delay", Delay)
        .AddParameter("offset", Offset)
        .AddParameter("max_speed", MaxSpeed)
        .AddParameter("duration", Duration)
        .Build();
    /**
     * <summary>
     * Lock group to player position
     * </summary>
     * <param name="LockX">Lock to player X (Default = true)</param>
     * <param name="LockY">Lock to player Y (Default = true)</param>
     * <param name="Duration">Duration of lock (Default = 999)</param>
     */
    public SPWNCode LockToPlayer(Boolean? LockX = null, Boolean? LockY = null, Number? Duration = null)
        => new SPWNMethodCallBuilder($"{ValueAsString}.follow_lerp")
        .AddParameter("lock_x", LockX)
        .AddParameter("lock_y", LockY)
        .AddParameter("duration", Duration)
        .Build();
    /**
     * <summary>
     * Implementation of the 'Move target' feature of the move trigger. Remember that both groups can only contain one object.
     * </summary>
     * <param name="Target">Group of the object to move to</param>
     * <param name="Duration">Duration of movement (Default: 0)</param>
     * <param name="XOnly">Will move to the object only on the X-axis (Default: false)</param>
     * <param name="YOnly">Will move to the object only on the y-axis (Default: false)</param>
     * <param name="Easing">Easting type (Default: NONE)</param>
     * <param name="EasingRate">Easting rate (Default: 2)</param>
     */
    public SPWNCode MoveTo(Group Target, Number? Duration = null, Boolean? XOnly = null, Boolean? YOnly = null, EasingTypes? Easing = null, Number? EasingRate = null)
        => new SPWNMethodCallBuilder($"{ValueAsString}.move_to")
        .AddParameter("target", Target)
        .AddParameter("duration", Duration)
        .AddParameter("x_only", XOnly)
        .AddParameter("y_only", YOnly)
        .AddParameter("easing", Easing)
        .AddParameter("easing_rate", EasingRate)
        .Build();


    /**
     * <summary>
     * Alias of MoveToXY
     * </summary>
     * <param name="X">X position to move to in units (1 grid square is 30 units) (Default: Null)</param>
     * <param name="Y">Will move to the object only on the X-axis (Default: Null)</param>
     * <param name="Duration">Duration of movement (Default: 0)</param>
     * <param name="Easing">Easting type (Default: NONE)</param>
     * <param name="EasingRate">Easting rate (Default: 2)</param>
     */
    public SPWNCode MoveTo(Number? X = null, Number? Y = null, Number? Duration = null, EasingTypes? Easing = null, Number? EasingRate = null)
        => MoveToXY(X: X, Y: Y, Duration: Duration, Easing: Easing, EasingRate: EasingRate);

    /**
     * <summary>
     * Alias of MoveToXY
     * </summary>
     * <param name="Point">X and Y position to move to in units (1 grid square is 30 units) (Default: Null)</param>
     * <param name="Duration">Duration of movement (Default: 0)</param>
     * <param name="Easing">Easting type (Default: NONE)</param>
     * <param name="EasingRate">Easting rate (Default: 2)</param>
     */
    public SPWNCode MoveTo(System.Drawing.PointF Point, Number? Duration = null, EasingTypes? Easing = null, Number? EasingRate = null)
        => MoveToXY(X: Point.X, Y: Point.Y, Duration: Duration, Easing: Easing, EasingRate: EasingRate);

    /**
     * <summary>
     * Moves group to a specific coordinate
     * </summary>
     * <param name="X">X position to move to in units (1 grid square is 30 units) (Default: Null)</param>
     * <param name="Y">Will move to the object only on the X-axis (Default: Null)</param>
     * <param name="Duration">Duration of movement (Default: 0)</param>
     * <param name="Easing">Easting type (Default: NONE)</param>
     * <param name="EasingRate">Easting rate (Default: 2)</param>
     */
    public SPWNCode MoveToXY(Number? X = null, Number? Y = null, Number? Duration = null, EasingTypes? Easing = null, Number? EasingRate = null)
        => new SPWNMethodCallBuilder($"{ValueAsString}.move_to")
        .AddParameter("x", X)
        .AddParameter("y", Y)
        .AddParameter("duration", Duration)
        .AddParameter("easing", Easing)
        .AddParameter("easing_rate", EasingRate)
        .Build();

    /**
     * <summary>
     * Alias of MoveToXY(Number? X, Number? Y, ...)
     * </summary>
     * <param name="Point">X and Y position to move to in units (1 grid square is 30 units) (Default: Null)</param>
     * <param name="Duration">Duration of movement (Default: 0)</param>
     * <param name="Easing">Easting type (Default: NONE)</param>
     * <param name="EasingRate">Easting rate (Default: 2)</param>
     */
    public SPWNCode MoveToXY(System.Drawing.PointF Point, Number? Duration = null, EasingTypes? Easing = null, Number? EasingRate = null)
        => MoveToXY(X: Point.X, Y: Point.Y, Duration: Duration, Easing: Easing, EasingRate: EasingRate);

    /**
     * <summary>
     * Combines a move trigger with a follow trigger to allow for more precise decimal movement (up to 2 decimal places)
     * </summary>
     * <param name="X">Units to move on the X axis (10 units per grid square)</param>
     * <param name="Y">Units to move on the Y axis (10 units per grid square)</param>
     * <param name="Duration">Duration of movement (Default: 0)</param>
     * <param name="Easing">Easting type (Default: NONE)</param>
     * <param name="EasingRate">Easting rate (Default: 2)</param>
     * <param name="Single">Saves groups and objects if the group only contains one object</param>
     */
    public SPWNCode PreciseMove(Number X, Number Y, Number? Duration = null, EasingTypes? Easing = null, Number? EasingRate = null, Boolean? Single = null)
        => new SPWNMethodCallBuilder($"{ValueAsString}.move_to")
        .AddParameter("x", X)
        .AddParameter("y", Y)
        .AddParameter("duration", Duration)
        .AddParameter("easing", Easing)
        .AddParameter("easing_rate", EasingRate)
        .AddParameter("single", Single)
        .Build();

    /**
     * <summary>
     * Combines a move trigger with a follow trigger to allow for more precise decimal movement (up to 2 decimal places)
     * </summary>
     * <param name="Point">Units to move on the X and Y axis (10 units per grid square)</param>
     * <param name="Duration">Duration of movement (Default: 0)</param>
     * <param name="Easing">Easting type (Default: NONE)</param>
     * <param name="EasingRate">Easting rate (Default: 2)</param>
     * <param name="Single">Saves groups and objects if the group only contains one object</param>
     */
    public SPWNCode PreciseMove(System.Drawing.PointF Point, Number? Duration = null, EasingTypes? Easing = null, Number? EasingRate = null, Boolean? Single = null)
        => PreciseMove(X: Point.X, Y: Point.Y, Duration: Duration, Easing: Easing, EasingRate: EasingRate, Single: Single);

    public SPWNCode Pulse(Number R, Number G, Number B, Number? FadeIn = null, Number? Hold = null, Number? FadeOut = null, Boolean? Exclusive = null, Boolean? HSVMode = null, Boolean? SaturationChecked = null, Boolean? BrightnessChecked = null)
        => (this as IPulseAble).Pulse(R: R, G: G, B: B, FadeIn: FadeIn, Hold: Hold, FadeOut: FadeOut, Exclusive: Exclusive, HSVMode: HSVMode, SaturationChecked: SaturationChecked, BrightnessChecked: BrightnessChecked);

    public SPWNCode Rotate(Group Center, Number Degrees, Number? Duration = null, EasingTypes? Easing = null, Number? EasingRate = null, Boolean? LockObjectRotation = null)
        => new SPWNMethodCallBuilder($"{ValueAsString}.rotate")
        .AddParameter("center", Center)
        .AddParameter("degrees", Degrees)
        .AddParameter("duration", Duration)
        .AddParameter("easing", Easing)
        .AddParameter("easing_rate", EasingRate)
        .AddParameter("lock_object_rotation", LockObjectRotation)
        .Build();

    public SPWNCode Stop()
        => new SPWNMethodCallBuilder($"{ValueAsString}.stop")
        .Build();

    public SPWNCode ToggleOff()
        => new SPWNMethodCallBuilder($"{ValueAsString}.toggle_off")
        .Build();

    public SPWNCode ToggleOn()
        => new SPWNMethodCallBuilder($"{ValueAsString}.toggle_on")
        .Build();
}
