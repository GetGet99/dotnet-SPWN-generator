﻿namespace SPWN.DataTypes;

public enum EasingTypes
{
    NONE,
    EASE_IN_OUT,
    EASE_IN,
    EASE_OUT,
    ELASTIC_IN_OUT,
    ELASTIC_IN,
    ELASTIC_OUT,
    BOUNCE_IN_OUT,
    BOUNCE_IN,
    BOUNCE_OUT,
    EXPONENTIAL_IN_OUT,
    EXPONENTIAL_IN,
    EXPONENTIAL_OUT,
    SINE_IN_OUT,
    SINE_IN,
    SINE_OUT,
    BACK_IN_OUT,
    BACK_IN,
    BACK_OUT
}

public enum Comparisons
{
    EQUAL_TO,
    LARGER_THAN,
    SMALLER_THAN,
}

public enum Colors
{
    BG,
    GROUND,
    LINE,
    _3DLINE,
    OBJECT,
    GROUND2
}
public static class ObjectIds
{
    [EnumPrefix("obj_ids.triggers")]
    public enum Triggers
    {
        MOVE,
        ROTATE,
        ANIMATE,
        PULSE,
        COUNT,
        ALPHA,
        TOGGLE,
        FOLLOW,
        SPAWN,
        STOP,
        TOUCH,
        INSTANT_COUNT,
        ON_DEATH,
        FOLLOW_PLAYER_Y,
        COLLISION,
        PICKUP,
        BG_EFFECT_ON,
        BG_EFFECT_OFF,
        SHAKE,
        COLOR,
        ENABLE_TRAIL,
        DISABLE_TRAIL,
        HIDE,
        SHOW
    }
    [EnumPrefix("obj_ids.portals")]
    public enum Portals
    {
        GRAVITY_DOWN,
        GRAVITY_UP,
        CUBE,
        SHIP,
        BALL,
        UFO,
        WAVE,
        ROBOT,
        SPIDER,
        MIRROR_ON,
        MIRROR_OFF,
        SIZE_NORMAL,
        SIZE_MINI,
        DUAL_ON,
        DUAL_OFF,
        TELEPORT,
        SPEED_YELLOW,
        SPEED_BLUE,
        SPEED_GREEN,
        SPEED_PINK,
        SPEED_RED
    }
    [EnumPrefix("obj_ids.special")]
    public enum Special
    {
        COLLISION_BLOCK,

        J_BLOCK,
        H_BLOCK,
        D_BLOCK,
        S_BLOCK,

        ITEM_DISPLAY,
        TEXT,

        USER_COIN
    }
}

public enum ObjectKeys
{
    [KeyType(typeof(Number))]
    OBJ_ID,
    [KeyType(typeof(Number))]
    X,
    [KeyType(typeof(Number))]
    Y,
    [KeyType(typeof(Boolean))]
    HORIZONTAL_FLIP,
    [KeyType(typeof(Boolean))]
    VERTICAL_FLIP,
    [KeyType(typeof(Number))]
    ROTATION,
    [KeyType(typeof(Number))]
    TRIGGER_RED,
    [KeyType(typeof(Number))]
    TRIGGER_GREEN,
    [KeyType(typeof(Number))]
    TRIGGER_BLUE,
    [KeyType(typeof(Number))]
    DURATION,
    [KeyType(typeof(Boolean))]
    TOUCH_TRIGGERED,
    [KeyType(typeof(Boolean))]
    PORTAL_CHECKED,
    [KeyType(typeof(Boolean))]
    PLAYER_COLOR_1,
    [KeyType(typeof(Boolean))]
    PLAYER_COLOR_2,
    [KeyType(typeof(Boolean))]
    BLENDING,
    [KeyType(typeof(Number))]
    EDITOR_LAYER_1,
    [KeyType(typeof(Color))]
    COLOR,
    [KeyType(typeof(Color))]
    COLOR_2,
    [KeyType(typeof(Color))]
    TARGET_COLOR,
    [KeyType(typeof(Number))]
    Z_LAYER,
    [KeyType(typeof(Number))]
    Z_ORDER,
    [KeyType(typeof(Number))]
    MOVE_X,
    [KeyType(typeof(Number))]
    MOVE_Y,
    [KeyType(typeof(Number))]
    EASING,
    [KeyType(typeof(String))]
    TEXT,
    [KeyType(typeof(Number))]
    SCALING,
    [KeyType(typeof(Boolean))]
    GROUP_PARENT,
    [KeyType(typeof(Number))]
    OPACITY,
    [KeyType(typeof(Boolean))]
    HVS_ENABLED,
    [KeyType(typeof(Boolean))]
    COLOR_2_HVS_ENABLED,
    [KeyType(typeof(String))]
    HVS,
    [KeyType(typeof(String))]
    COLOR_2_HVS,
    [KeyType(typeof(Number))]
    FADE_IN,
    [KeyType(typeof(Number))]
    HOLD,
    [KeyType(typeof(Number))]
    FADE_OUT,
    [KeyType(typeof(Boolean))]
    PULSE_HSV,
    [KeyType(typeof(String))]
    COPIED_COLOR_HVS,
    [KeyType(typeof(Color))]
    COPIED_COLOR_ID,
    [KeyType(typeof(Color))]
    [KeyType(typeof(Group))]
    [KeyType(typeof(TriggerFunction))]
    TARGET,
    [KeyType(typeof(Number))]
    TARGET_TYPE,
    [KeyType(typeof(Number))]
    YELLOW_TELEPORTATION_PORTAL_DISTANCE,
    [KeyType(typeof(Boolean))]
    ACTIVATE_GROUP,
    [KeyType(typeof(Group))]
    [KeyType(typeof(Array<Group>))]
    GROUPS,
    [KeyType(typeof(Boolean))]
    LOCK_TO_PLAYER_X,
    [KeyType(typeof(Boolean))]
    LOCK_TO_PLAYER_Y,
    [KeyType(typeof(Boolean))]
    COPY_OPACITY,
    [KeyType(typeof(Number))]
    EDITOR_LAYER_2,
    [KeyType(typeof(Boolean))]
    SPAWN_TRIGGERED,
    [KeyType(typeof(Number))]
    [KeyType(typeof(Number.Epsilon))]
    SPAWN_DURATION,
    [KeyType(typeof(Boolean))]
    DONT_FADE,
    [KeyType(typeof(Boolean))]
    MAIN_ONLY,
    [KeyType(typeof(Boolean))]
    DETAIL_ONLY,
    [KeyType(typeof(Boolean))]
    DONT_ENTER,
    [KeyType(typeof(Number))]
    ROTATE_DEGREES,
    [KeyType(typeof(Number))]
    TIMES_360,
    [KeyType(typeof(Boolean))]
    LOCK_OBJECT_ROTATION,
    [KeyType(typeof(Group))]
    FOLLOW,
    [KeyType(typeof(Group))]
    CENTER,
    [KeyType(typeof(Group))]
    TARGET_POS,
    [KeyType(typeof(Number))]
    X_MOD,
    [KeyType(typeof(Number))]
    Y_MOD,
    [KeyType(typeof(Number))]
    STRENGTH,
    [KeyType(typeof(Number))]
    ANIMATION_ID,
    [KeyType(typeof(Number))]
    COUNT,
    [KeyType(typeof(Number))]
    SUBTRACT_COUNT,
    [KeyType(typeof(Number))]
    PICKUP_MODE,
    [KeyType(typeof(Item))]
    [KeyType(typeof(Block))]
    ITEM,
    [KeyType(typeof(Block))]
    BLOCK_A,
    [KeyType(typeof(Boolean))]
    HOLD_MODE,
    [KeyType(typeof(Number))]
    TOGGLE_MODE,
    [KeyType(typeof(Number))]
    INTERVAL,
    [KeyType(typeof(Number))]
    EASING_RATE,
    [KeyType(typeof(Boolean))]
    EXCLUSIVE,
    [KeyType(typeof(Boolean))]
    MULTI_TRIGGER,
    [KeyType(typeof(Number))]
    COMPARISON,
    [KeyType(typeof(Boolean))]
    DUAL_MODE,
    [KeyType(typeof(Number))]
    SPEED,
    [KeyType(typeof(Number))]
    DELAY,
    [KeyType(typeof(Number))]
    Y_OFFSET,
    [KeyType(typeof(Boolean))]
    ACTIVATE_ON_EXIT,
    [KeyType(typeof(Boolean))]
    DYNAMIC_BLOCK,
    [KeyType(typeof(Block))]
    BLOCK_B,
    [KeyType(typeof(Boolean))]
    GLOW_DISABLED,
    [KeyType(typeof(Number))]
    ROTATION_SPEED,
    [KeyType(typeof(Boolean))]
    DISABLE_ROTATION,
    [KeyType(typeof(Boolean))]
    COUNT_MULTI_ACTIVATE,
    [KeyType(typeof(Boolean))]
    USE_TARGET,
    [KeyType(typeof(Number))]
    TARGET_POS_AXES,
    [KeyType(typeof(Boolean))]
    EDITOR_DISABLE,
    [KeyType(typeof(Boolean))]
    HIGH_DETAIL,
    [KeyType(typeof(Number))]
    MAX_SPEED,
    [KeyType(typeof(Boolean))]
    RANDOMIZE_START,
    [KeyType(typeof(Number))]
    ANIMATION_SPEED,
    [KeyType(typeof(Number))]
    LINKED_GROUP,
    [KeyType(typeof(Boolean))]
    ACTIVE_TRIGGER,
}

[System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = true)]
public class KeyTypeAttribute : System.Attribute
{
    public System.Type Type { get; }
    public KeyTypeAttribute(System.Type Type)
    {
        if (!Type.IsSubclassOf(typeof(Base.SPWNValueBase)))
            throw new System.ArgumentException($"Type must inherit from {nameof(Base.SPWNValueBase)}",nameof(Type));
        this.Type = Type;
    }
}
[System.AttributeUsage(System.AttributeTargets.Enum, AllowMultiple = false)]
public class EnumPrefixAttribute : System.Attribute
{
    public string Prefix { get; }
    public EnumPrefixAttribute(string Prefix)
    {
        this.Prefix = Prefix;
    }
}