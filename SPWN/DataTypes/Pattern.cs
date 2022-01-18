using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPWN.DataTypes;
using Base;
public class Pattern : SPWNValueBase
{
    public override string ValueAsString { get; protected set; } = "";

    public Pattern(TypeIndicator t)
    {
        ValueAsString = t.ValueAsString;
    }
}
