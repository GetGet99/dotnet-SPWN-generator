using SPWNCreator;
using SPWNBasics = SPWN.Basics;
using SPWNDataTypes = SPWN.DataTypes;
using SPWNLibraries = SPWN.Libraries;
using static SPWN.Basics.Extensions;
using static SPWN.Basics.SPWNUtils;

Generator.PrintToConsole(
    Codes:
    new SPWNBasics.SPWNCodes
    {
        Comment("Groups of the objects that decide the position of"),
        Comment("our buttons"),
        new SPWNBasics.Variable<SPWNDataTypes.List<SPWNDataTypes.Group>>(
            VariableName: "anchors",
            Value: new SPWNDataTypes.Group[] {
                1, 2, 3, 4, 5, 6
            }
        ).Init(out var anchors),

        NewLine(),
        Comment("Group of the object that indicates which"),
        Comment("button is currently selected"),

        new SPWNBasics.Variable<SPWNDataTypes.Group>(
            VariableName: "selector",
            Value: 7
        ).Init(out var selector),

        NewLine(),

        new SPWNBasics.Variable<SPWNLibraries.Gamescene>(
            VariableName: "gs",
            Value: new SPWNLibraries.Gamescene()
        ).Init(out var gs),

        NewLine(),

        Comment("starts at first button (index 0)"),
        new SPWNBasics.Variable<SPWNDataTypes.Counter>(
            VariableName: "selected",
            Value: new SPWNDataTypes.Counter(0)
        ).Init(out var selected),

        NewLine(),

        gs.ButtonA().OnTriggered(new SPWNDataTypes.MacroAction( new SPWNBasics.SPWNCodes
        {
            Comment("switch"),
            selected.SetAdd(1),
            
            SPWN.Conditions.If(Expr: selected >= anchors.Length.AsValue(),
                Do: selected.SetTo(0).End()
            ),

            Comment("convert selected to a normal number"),
            new SPWNBasics.Variable<SPWNDataTypes.Group>(
                VariableName:"current_anchor",
                Value: anchors[selected.ToConst((0,anchors.Length.AsValue())).AsValue()].AsValue()
            ).Init(out var current_anchor),

            selector.MoveTo(current_anchor)
        }))
    }
);
System.Console.WriteLine("Completed");