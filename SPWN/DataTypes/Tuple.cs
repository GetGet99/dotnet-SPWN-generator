namespace SPWN.DataTypes;
using InternalImplementation;

public class Tuple<Value1> : Array<ISPWNValue>
    where Value1 : class, ISPWNValue
{
    public Tuple(System.Tuple<Value1> Tuple) : base(new ISPWNValue[] { Tuple.Item1 }) { }
    public Tuple(System.ValueTuple<Value1> Tuple) : base(new ISPWNValue[] { Tuple.Item1 }) { }
    public Tuple(Value1 Value1) : base(new ISPWNValue[] { Value1 }) { }
    public Tuple(ISPWNExpr<Tuple<Value1>> Expr) => ValueAsString = Expr.CreateCode();

    public static implicit operator Tuple<Value1>(System.Tuple<Value1> Tuple) => new(Tuple);
    public static implicit operator Tuple<Value1>(System.ValueTuple<Value1> Tuple) => new(Tuple);

    public Value1 Item1 => (Value1)this[0];

    public void Deconstruct(out Value1 a)
    {
        a = Item1;
    }
}
public class Tuple<Value1, Value2> : Array<ISPWNValue>
    where Value1 : class, ISPWNValue
    where Value2 : class, ISPWNValue
{
    public Tuple(System.Tuple<Value1, Value2> Tuple) : base(new ISPWNValue[] { Tuple.Item1, Tuple.Item2 }) { }
    public Tuple((Value1, Value2) Tuple) : base(new ISPWNValue[] { Tuple.Item1, Tuple.Item2 }) { }
    public Tuple(Value1 Value1, Value2 Value2) : base(new ISPWNValue[] { Value1, Value2 }) { }
    public Tuple(ISPWNExpr<Tuple<Value1, Value2>> Expr) => ValueAsString = Expr.CreateCode();

    public static implicit operator Tuple<Value1, Value2>(System.Tuple<Value1, Value2> Tuple) => new(Tuple);
    public static implicit operator Tuple<Value1, Value2>(System.ValueTuple<Value1, Value2> Tuple) => new(Tuple);

    public void Deconstruct(out Value1 a, out Value2 b)
    {
        a = Item1;
        b = Item2;
    }

    public Value1 Item1 => (Value1)this[0];
    public Value2 Item2 => (Value2)this[1];
}

public class Tuple<Value1, Value2, Value3> : Array<ISPWNValue>
    where Value1 : class, ISPWNValue
    where Value2 : class, ISPWNValue
    where Value3 : class, ISPWNValue
{
    public Tuple(System.Tuple<Value1, Value2, Value3> Tuple) : base(new ISPWNValue[] { Tuple.Item1, Tuple.Item2, Tuple.Item3 }) { }
    public Tuple((Value1, Value2, Value3) Tuple) : base(new ISPWNValue[] { Tuple.Item1, Tuple.Item2, Tuple.Item3 }) { }
    public Tuple(Value1 Value1, Value2 Value2, Value3 Value3) : base(new ISPWNValue[] { Value1, Value2, Value3 }) { }
    public Tuple(ISPWNExpr<Tuple<Value1, Value2, Value3>> Expr) => ValueAsString = Expr.CreateCode();

    public Value1 Item1 => (Value1)this[0];
    public Value2 Item2 => (Value2)this[1];
    public Value3 Item3 => (Value3)this[2];

    public void Deconstruct(out Value1 a, out Value2 b, out Value3 c)
    {
        a = Item1;
        b = Item2;
        c = Item3;
    }
}

public class Tuple<Value1, Value2, Value3, Value4> : Array<ISPWNValue>
    where Value1 : class, ISPWNValue
    where Value2 : class, ISPWNValue
    where Value3 : class, ISPWNValue
    where Value4 : class, ISPWNValue
{
    public Tuple(System.Tuple<Value1, Value2, Value3, Value4> Tuple) : base(new ISPWNValue[] { Tuple.Item1, Tuple.Item2, Tuple.Item3, Tuple.Item4 }) { }
    public Tuple((Value1, Value2, Value3, Value4) Tuple) : base(new ISPWNValue[] { Tuple.Item1, Tuple.Item2, Tuple.Item3, Tuple.Item4 }) { }
    public Tuple(Value1 Value1, Value2 Value2, Value3 Value3, Value4 Value4) : base(new ISPWNValue[] { Value1, Value2, Value3, Value4 }) { }
    public Tuple(ISPWNExpr<Tuple<Value1, Value2, Value3, Value4>> Expr) => ValueAsString = Expr.CreateCode();

    public Value1 Item1 => (Value1)this[0];
    public Value2 Item2 => (Value2)this[1];
    public Value3 Item3 => (Value3)this[2];
    public Value4 Item4 => (Value4)this[3];

    public void Deconstruct(out Value1 a, out Value2 b, out Value3 c, out Value4 d)
    {
        a = Item1;
        b = Item2;
        c = Item3;
        d = Item4;
    }
}

public class Tuple<Value1, Value2, Value3, Value4, Value5> : Array<ISPWNValue>
    where Value1 : class, ISPWNValue
    where Value2 : class, ISPWNValue
    where Value3 : class, ISPWNValue
    where Value4 : class, ISPWNValue
    where Value5 : class, ISPWNValue
{
    public Tuple(System.Tuple<Value1, Value2, Value3, Value4, Value5> Tuple) : base(new ISPWNValue[] { Tuple.Item1, Tuple.Item2, Tuple.Item3, Tuple.Item4, Tuple.Item5 }) { }
    public Tuple((Value1, Value2, Value3, Value4, Value5) Tuple) : base(new ISPWNValue[] { Tuple.Item1, Tuple.Item2, Tuple.Item3, Tuple.Item4, Tuple.Item5 }) { }
    public Tuple(Value1 Value1, Value2 Value2, Value3 Value3, Value4 Value4, Value5 Value5) : base(new ISPWNValue[] { Value1, Value2, Value3, Value4, Value5 }) { }
    public Tuple(ISPWNExpr<Tuple<Value1, Value2, Value3, Value4, Value5>> Expr) => ValueAsString = Expr.CreateCode();

    public Value1 Item1 => (Value1)this[0];
    public Value2 Item2 => (Value2)this[1];
    public Value3 Item3 => (Value3)this[2];
    public Value4 Item4 => (Value4)this[3];
    public Value5 Item5 => (Value5)this[4];

    public void Deconstruct(out Value1 a, out Value2 b, out Value3 c, out Value4 d, out Value5 e)
    {
        a = Item1;
        b = Item2;
        c = Item3;
        d = Item4;
        e = Item5;
    }
}