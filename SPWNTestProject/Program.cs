using SPWNCreator;
using static SPWN.Basics.Extensions;
using static SPWN.Basics.SPWNUtils;

// Reference: https://spu7nix.net/spwn/#/triggerlanguage/7selectorpanel
Generator.PrintToConsole(
    Codes:
    new SPWN.Basics.SPWNCodes
    {
        Comment("Groups of the objects that decide the position of"),
        Comment("our buttons"),
        new SPWN.Basics.Variable<SPWN.DataTypes.List<SPWN.DataTypes.Group>>(
            VariableName: "anchors",
            Value: new SPWN.DataTypes.Group[] {
                1, 2, 3, 4, 5, 6
            }
        ).Init(out var anchors),

        NewLine(),
        Comment("Group of the object that indicates which"),
        Comment("button is currently selected"),

        new SPWN.Basics.Variable<SPWN.DataTypes.Group>(
            VariableName: "selector",
            Value: 7
        ).Init(out var selector),

        NewLine(),

        new SPWN.Basics.Variable<SPWN.Libraries.Gamescene>(
            VariableName: "gs",
            Value: new SPWN.Libraries.Gamescene()
        ).Init(out var gs),

        NewLine(),

        Comment("starts at first button (index 0)"),
        new SPWN.Basics.Variable<SPWN.DataTypes.Counter>(
            VariableName: "selected",
            Value: new SPWN.DataTypes.Counter(0)
        ).Init(out var selected),

        NewLine(),

        gs.ButtonA().OnTriggered(new SPWN.DataTypes.TriggerFunction( new SPWN.Basics.SPWNCodes
        {
            Comment("switch"),
            selected.SetAdd(1),
            
            SPWN.Conditions.If(Expr: selected >= anchors.Length.AsValue(),
                Do: selected.SetTo(0).End()
            ),

            Comment("convert selected to a normal number"),
            new SPWN.Basics.Variable<SPWN.DataTypes.Group>(
                VariableName:"current_anchor",
                Value: anchors[selected.ToConst(new SPWN.DataTypes.Range<SPWN.DataTypes.Number>(0,anchors.Length.AsValue())).AsValue()].AsValue()
            ).Init(out var current_anchor),

            selector.MoveTo(current_anchor)
        }))
    }
);
System.Console.WriteLine("Completed");