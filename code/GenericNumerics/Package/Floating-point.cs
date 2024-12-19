/*
    Copyright (C) 2024 by Sergey A Kryukov
    https://www.SAKryukov.org
    https://github.com/SAKryukov
*/

namespace GenericNumerics.Package {

    public static class StructuredPackage<NUM> where NUM :
        System.IEquatable<NUM>,
        System.IParsable<NUM>,
        System.ISpanParsable<NUM>,
        System.IUtf8SpanParsable<NUM>,
        System.Numerics.IAdditionOperators<NUM, NUM, NUM>,
        System.Numerics.IAdditiveIdentity<NUM, NUM>,
        System.Numerics.IDecrementOperators<NUM>,
        System.Numerics.IDivisionOperators<NUM, NUM, NUM>,
        System.Numerics.IEqualityOperators<NUM, NUM, bool>,
        System.Numerics.IIncrementOperators<NUM>,
        System.Numerics.IMultiplicativeIdentity<NUM, NUM>,
        System.Numerics.IMultiplyOperators<NUM, NUM, NUM>,
        System.Numerics.INumberBase<NUM>,
        System.Numerics.ISignedNumber<NUM>,
        System.Numerics.ISubtractionOperators<NUM, NUM, NUM>,
        System.Numerics.IUnaryNegationOperators<NUM, NUM>,
        System.Numerics.IUnaryPlusOperators<NUM, NUM>
    {
    } //StructuredPackage<NUM>

    public static class Package<NUM> where NUM :
        System.IComparable<NUM>,
        System.IEquatable<NUM>,
        System.IParsable<NUM>,
        System.ISpanParsable<NUM>,
        System.IUtf8SpanParsable<NUM>,
        System.Numerics.IAdditionOperators<NUM, NUM, NUM>,
        System.Numerics.IAdditiveIdentity<NUM, NUM>,
        System.Numerics.IBinaryFloatingPointIeee754<NUM>,
        System.Numerics.IBinaryNumber<NUM>,
        System.Numerics.IBitwiseOperators<NUM, NUM, NUM>,
        System.Numerics.IComparisonOperators<NUM, NUM, bool>,
        System.Numerics.IDecrementOperators<NUM>,
        System.Numerics.IDivisionOperators<NUM, NUM, NUM>,
        System.Numerics.IEqualityOperators<NUM, NUM, bool>,
        System.Numerics.IExponentialFunctions<NUM>,
        System.Numerics.IFloatingPoint<NUM>,
        System.Numerics.IFloatingPointConstants<NUM>,
        System.Numerics.IFloatingPointIeee754<NUM>,
        System.Numerics.IHyperbolicFunctions<NUM>,
        System.Numerics.IIncrementOperators<NUM>,
        System.Numerics.ILogarithmicFunctions<NUM>,
        System.Numerics.IMinMaxValue<NUM>,
        System.Numerics.IModulusOperators<NUM, NUM, NUM>,
        System.Numerics.IMultiplicativeIdentity<NUM, NUM>,
        System.Numerics.IMultiplyOperators<NUM, NUM, NUM>,
        System.Numerics.INumber<NUM>,
        System.Numerics.INumberBase<NUM>,
        System.Numerics.IPowerFunctions<NUM>,
        System.Numerics.IRootFunctions<NUM>,
        System.Numerics.ISignedNumber<NUM>,
        System.Numerics.ISubtractionOperators<NUM, NUM, NUM>,
        System.Numerics.ITrigonometricFunctions<NUM>,
        System.Numerics.IUnaryNegationOperators<NUM, NUM>,
        System.Numerics.IUnaryPlusOperators<NUM, NUM>
    {

        public static class OperatorSample {
            public static NUM Calculate(NUM a, NUM b) =>
                (a * b) / (a + b);
            public static NUM More(NUM a) =>
                -a;
        } //class OperatorSample

        public static class MathFunctions {
            public static NUM Calculate(NUM a, NUM b) =>
                NUM.Pow(a, b) * NUM.Sqrt(a);
            public static NUM CalculateMore(NUM a, NUM b) =>
                NUM.Log(a, b) * NUM.Exp(a);
        } //class MathFunctions

    } //class Package

}
