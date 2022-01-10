namespace SPWN.Basics;
using SPWN.InternalImplementation;

public class Variable<T> : ISPWNVariable, ISPWNExpr<T> where T : ISPWNValue
{
    public string Name { get; set; }
    protected T InitializedValue { get; set; }
    public Variable(T Value, string VariableName)
    {
        if (VariableName is null) throw new System.ArgumentNullException(nameof(VariableName));
        Name = VariableName;
        InitializedValue = Value;
    }

    public string CreateCode() => Name;
    public ISPWNCode GetInitializationCode() => SetNewValue(InitializedValue);
    public StringSPWNCode SetNewValue(T Value) => new ($"{Name} = {Value.ValueAsString}");
}
