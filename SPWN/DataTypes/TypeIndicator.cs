namespace SPWN.DataTypes;
using Base;
using InternalImplementation;

[SPWNType("@type_indicator")]
public class TypeIndicator : SPWNValueBase
{
    public override string ValueAsString { get; protected set; } = "";

    private TypeIndicator(string ValueAsString) => this.ValueAsString = ValueAsString;
    public TypeIndicator(SPWNExpr<TypeIndicator> Expr) => ValueAsString = Expr.ValueAsString;

    public static TypeIndicator GetType<T>() where T : SPWNValueBase
    {
        return GetType(typeof(T));
    }
    public static TypeIndicator GetType(System.Type type)
    {
        foreach (var t in type.GetCustomAttributes(typeof(SPWNTypeAttribute), true))
        {
            if (t.GetType() == typeof(SPWNTypeAttribute))
            {
                if (t is not SPWNTypeAttribute typeT) continue;

                return new TypeIndicator(typeT.NativeName);
            }
        }
        throw new System.ArgumentException($"This type does not have the attribute {typeof(SPWNTypeAttribute).FullName}" +
            $"\nIf you create custom class/type/module, please put [{typeof(SPWNTypeAttribute).FullName}(\"@YOUR_TYPE_NAME\")] on the top", nameof(type));
    }
}
