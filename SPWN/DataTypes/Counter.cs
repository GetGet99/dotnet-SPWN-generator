namespace SPWN.DataTypes;
using Basics;
using InternalImplementation;
using static Utils.Wrapper.Extension;

public class Counter : ISPWNValue, ICanBeMutable, ICanBeConstant
{
    public string ValueAsString { get; private set; }

    protected Counter(Number Source, Number? NumberOfBits = null, Boolean? Reset = null)
        => ValueAsString = new SPWNMethodCallBuilder("counter")
        .AddParameter("source", Source)
        .AddParameter("bits",NumberOfBits)
        .AddParameter("reset",Reset)
        .Build<Counter>().ValueAsString;
    protected Counter(Boolean Source, Number? NumberOfBits = null, Boolean? Reset = null)
        => ValueAsString = new SPWNMethodCallBuilder("counter")
        .AddParameter("source", Source)
        .AddParameter("bits", NumberOfBits)
        .AddParameter("reset", Reset)
        .Build<Counter>().ValueAsString;
    protected Counter(Item Source, Number? NumberOfBits = null, Boolean? Reset = null)
        => ValueAsString = new SPWNMethodCallBuilder("counter")
        .AddParameter("source", Source)
        .AddParameter("bits", NumberOfBits)
        .AddParameter("reset", Reset)
        .Build<Counter>().ValueAsString;

    public Counter(ISPWNExpr<Counter> Value) => ValueAsString = Value.CreateCode();
    protected Counter(string ValueAsString) => this.ValueAsString = ValueAsString;

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


    

    public SPWNCode Add(Number Num) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("num", Num)
        .Build();

    public SPWNCode AddTo(Counter Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public SPWNCode AddTo(Item Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public SPWNCode AddTo(Array<Counter> Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public SPWNCode AddTo(Array<Item> Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public SPWNCode AddToMultifactor(Array<Array<Counter>> Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public SPWNCode AddToMultifactor(Array<Array<Item>> Items) =>
        new SPWNMethodCallBuilder($"{ValueAsString}.add")
        .AddParameter("items", Items)
        .Build();

    public SPWNCode Reset() =>
        new SPWNMethodCallBuilder($"{ValueAsString}.reset")
        .Build();

    public Counter Clone() =>
        new SPWNMethodCallBuilder($"{ValueAsString}.clone").Build<Counter>();

    public SPWNCode Assign(Counter Num)
        => new SPWNMethodCallBuilder(ValueAsString, "_assign_")
        .AddParameter("num", Num)
        .Build();
    
    public SPWNCode SetTo(Counter Num) => Assign(Num);

    //public ISPWNCode SetTo(Number n) => new StringSPWNCode($"{ValueAsString} = {n.ValueAsString}");

    public Boolean IsGreaterThan(Number n) => new SPWNOperatorOverloadBuilder(">" ,this, n).Build<Boolean>();
    public Boolean IsGreaterThanOrEqual(Number n) => new SPWNOperatorOverloadBuilder(">=", this, n).Build<Boolean>();
    public Boolean IsLessThan(Number n) => new SPWNOperatorOverloadBuilder("<", this, n).Build<Boolean>();
    public Boolean IsLessThanOrEqual(Number n) => new SPWNOperatorOverloadBuilder("<=", this, n).Build<Boolean>();

    public static Boolean operator >(Counter c, Number other) => c.IsGreaterThan(other);
    public static Boolean operator >=(Counter c, Number other) => c.IsGreaterThanOrEqual(other);
    public static Boolean operator <(Counter c, Number other) => c.IsLessThan(other);
    public static Boolean operator <=(Counter c, Number other) => c.IsLessThanOrEqual(other);
    public Number ToConst(Range<Number> Range)
        => new SPWNMethodCallBuilder(ValueAsString, "to_const")
        .AddParameter("range", Range)
        .Build<Number>();
    //{
    //    return new StringSPWNExpr<Number>($"{ValueAsString}.to_const({r.ValueAsString})");
    //}
    public class BooleanCounter : Counter
    {

        public BooleanCounter(Boolean Source, Boolean? Reset = null) : base(Source, 1, Reset) { }
        public BooleanCounter(ISPWNExpr<BooleanCounter> Value) : base(Value.CreateCode()) { }
        public SPWNCode Assign(Boolean Num)
            => new SPWNMethodCallBuilder(ValueAsString, "_assign_")
            .AddParameter("num", Num)
            .Build();

        public SPWNCode SetTo(Boolean Num) => Assign(Num);
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
        public NumberCounter(ISPWNExpr<NumberCounter> Value) : base(Value.CreateCode()) { }

        public SPWNCode Assign(Number Num)
            => new SPWNMethodCallBuilder(ValueAsString, "_assign_")
            .AddParameter("num", Num)
            .Build();

        public SPWNCode SetTo(Number Num) => Assign(Num);
    }


}