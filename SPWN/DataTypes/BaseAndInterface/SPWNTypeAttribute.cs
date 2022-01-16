namespace SPWN.DataTypes.Base;

[System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class SPWNTypeAttribute : System.Attribute
{
    public string NativeName { get; }
    public SPWNTypeAttribute(string NativeName)
    {
        if (!NativeName.StartsWith("@")) NativeName = "@" + NativeName;
        this.NativeName = NativeName;
    }
}