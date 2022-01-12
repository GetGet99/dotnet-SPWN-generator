namespace SPWN.DataTypes;
using Basics;
using InternalImplementation;
using static Basics.Extensions;

using BooleanExpr = InternalImplementation.ISPWNExpr<Boolean>;
using StrBooleanExpr = InternalImplementation.StringSPWNExpr<Boolean>;

public abstract class Counter : ISPWNValue, ICanBeMutable, ICanBeConstant
{
    public string ValueAsString { get; private set; }

    protected Counter(Number Source, Number? NumberOfBits = null, Boolean? Reset = null)
        => ValueAsString = new SPWNMethodCallBuilder("counter")
        .AddParameter("source", Source)
        .AddParameter("bits",NumberOfBits)
        .AddParameter("reset",Reset)
        .BuildExpr<Counter>().CreateCode();
    protected Counter(Boolean Source, Number? NumberOfBits = null, Boolean? Reset = null)
        => ValueAsString = new SPWNMethodCallBuilder("counter")
        .AddParameter("source", Source)
        .AddParameter("bits", NumberOfBits)
        .AddParameter("reset", Reset)
        .BuildExpr<Counter>().CreateCode();
    protected Counter(Item Source, Number? NumberOfBits = null, Boolean? Reset = null)
        => ValueAsString = new SPWNMethodCallBuilder("counter")
        .AddParameter("source", Source)
        .AddParameter("bits", NumberOfBits)
        .AddParameter("reset", Reset)
        .BuildExpr<Counter>().CreateCode();

    /**
      * <param name="NumberOfBits">Should NOT be 1</param>
      */
    public static NumberCounter FromNumber(Number Source, Number? NumberOfBits = null, Boolean? Reset = null)
        => new (Source, NumberOfBits, Reset);

    public static BooleanCounter FromBoolean(Boolean Source, Boolean? Reset = null)
        => new (Source, Reset);
    
    /**
      * <param name="NumberOfBits">Should NOT be 1</param>
      */
    public static NumberCounter FromItem(Item Source, Number? NumberOfBits = null, Boolean? Reset = null)
        => new (Source, NumberOfBits, Reset);


    public Counter(ISPWNExpr<Counter> Value) => ValueAsString = Value.CreateCode().AddParenthesis();

    public ISPWNCode Add(Number Num) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("num", Num)
        .Build();

    public ISPWNCode AddTo(Counter Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public ISPWNCode AddTo(Item Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public ISPWNCode AddTo(Array<Counter> Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public ISPWNCode AddTo(Array<Item> Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public ISPWNCode AddToMultifactor(Array<Array<Counter>> Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public ISPWNCode AddToMultifactor(Array<Array<Item>> Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public ISPWNCode Reset() =>
        new SPWNMethodCallBuilder($"{ValueAsString}.reset")
        .Build();

    public ISPWNExpr<Counter> Clone() =>
        new SPWNMethodCallBuilder($"{ValueAsString}.clone").BuildExpr<Counter>();

    public ISPWNCode Assign(Counter Num)
        => new SPWNMethodCallBuilder(ValueAsString, "_assign_")
        .AddParameter("num", Num)
        .Build();
    
    public ISPWNCode SetTo(Counter Num) => Assign(Num);

    //public ISPWNCode SetTo(Number n) => new StringSPWNCode($"{ValueAsString} = {n.ValueAsString}");

    public BooleanExpr IsGreaterThan(Number n) => new StrBooleanExpr($"{ValueAsString} > {n.ValueAsString}");
    public BooleanExpr IsGreaterThanOrEqual(Number n) => new StrBooleanExpr($"{ValueAsString} >= {n.ValueAsString}");
    public BooleanExpr IsLessThan(Number n) => new StrBooleanExpr($"{ValueAsString} < {n.ValueAsString}");
    public BooleanExpr IsLessThanOrEqual(Number n) => new StrBooleanExpr($"{ValueAsString} <= {n.ValueAsString}");

    public static BooleanExpr operator >(Counter c, Number other) => c.IsGreaterThan(other);
    public static BooleanExpr operator >=(Counter c, Number other) => c.IsGreaterThanOrEqual(other);
    public static BooleanExpr operator <(Counter c, Number other) => c.IsLessThan(other);
    public static BooleanExpr operator <=(Counter c, Number other) => c.IsLessThanOrEqual(other);
    public ISPWNExpr<Number> ToConst(Range<Number> r)
    {
        return new StringSPWNExpr<Number>($"{ValueAsString}.to_const({r.ValueAsString})");
    }
    public class BooleanCounter : Counter
    {

        public BooleanCounter(Boolean Source, Boolean? Reset = null) : base(Source, 1, Reset) { }
        public BooleanCounter(ISPWNExpr<Counter> Value) : base(Value)
        {

        }
        public ISPWNCode Assign(Boolean Num)
            => new SPWNMethodCallBuilder(ValueAsString, "_assign_")
            .AddParameter("num", Num)
            .Build();

        public ISPWNCode SetTo(Boolean Num) => Assign(Num);
    }

    public class NumberCounter : Counter
    {
        /**
          * <param name="NumberOfBits">Should NOT be 1</param>
          */
        public NumberCounter(Number Source, Number? NumberOfBits = null, Boolean? Reset = null) : base(Source, NumberOfBits, Reset) { }
        /**
          * <param name="NumberOfBits">Should NOT be 1</param>
          */
        public NumberCounter(Item Source, Number? NumberOfBits = null, Boolean? Reset = null) : base(Source, NumberOfBits, Reset) { }
        public NumberCounter(ISPWNExpr<Counter> Value) : base(Value)
        {

        }

        public ISPWNCode Assign(Number Num)
            => new SPWNMethodCallBuilder(ValueAsString, "_assign_")
            .AddParameter("num", Num)
            .Build();

        public ISPWNCode SetTo(Number Num) => Assign(Num);
    }


}