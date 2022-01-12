namespace SPWN.Basics;
using SPWN.InternalImplementation;

public class Variable<T> : ISPWNExpr<T> where T : class, ISPWNValue, ICanBeMutable
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

    public string CreateCode() => Name;
    public SPWNCode GetInitializationCode(bool Mutable = false) => SetNewValue(InitializedValue, Mutable: Mutable);
    public StringSPWNCode SetNewValue(T Value, bool Mutable = false) => new ((Mutable ? "let " : "") + $"{Name} = {Value.ValueAsString}");
}
