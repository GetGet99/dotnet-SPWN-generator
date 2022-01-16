namespace SPWN.Basics;

using SPWN.DataTypes.Base;
using SPWN.InternalImplementation;

public class Variable<T> : SPWNExpr<T> where T : SPWNValueBase
{
    public string Name { get; set; }
    public T Value => this.AsValue();
    protected T InitializedValue { get; set; }
    public Variable(T Value, string VariableName)
    {
        if (VariableName is null) throw new System.ArgumentNullException(nameof(VariableName));
        Name = VariableName;
        InitializedValue = Value;
    }

    public override string CreateCode() => Name;
    public SPWNCode GetInitializationCode(bool Mutable = false)
    {
        var code = new StringSPWNCode((Mutable ? "let " : "") + $"{Name} = {Value.ValueAsString}");
        code.AddTypeMentioned<T>();
        return code;
    }
    public SPWNCode SetNewValue(T Value)
    {
        var code = new StringSPWNCode($"{Name} = {Value.ValueAsString}");
        code.AddTypeMentioned<T>();
        return code;
    }
}
