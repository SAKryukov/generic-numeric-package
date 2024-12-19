/*
    Copyright (C) 2024 by Sergey A Kryukov
    https://www.SAKryukov.org
    https://github.com/SAKryukov
*/

namespace GenericNumerics.Package {

    public interface IConverter<NUM> {
        public NUM FromInteger(int self);
        public NUM FromFloat(float self);
        NUM FromHalf(System.Half self);
        double ToDouble(NUM self);
    } //interface IConverter

    public class HalfConverter : IConverter<System.Half> {
        public System.Half FromInteger(int self) => (System.Half)self;
        public System.Half FromFloat(float self) => (System.Half)self;
        public System.Half FromHalf(System.Half self) => self;
        public double ToDouble(System.Half self) => (double)self;
    } //HalfConverter

    public class FloatConverter : IConverter<float> {
        public float FromInteger(int self) => self;
        public float FromFloat(float self) => self;
        public float FromHalf(System.Half self) => (float)self;
        public double ToDouble(float self) => self;
    } //HalfConverter

    public class DoubleConverter : IConverter<double> {
        public double FromInteger(int self) => self;
        public double FromFloat(float self) => self;
        public double FromHalf(System.Half self) => (double)self;
        public double ToDouble(double self) => self;
    } //HalfConverter

    public static class StructuredPackage<NUM, CONVERTER> where NUM :
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
        System.Numerics.INumber<NUM>,
        System.Numerics.ISubtractionOperators<NUM, NUM, NUM>,
        System.Numerics.IUnaryNegationOperators<NUM, NUM>,
        System.Numerics.IUnaryPlusOperators<NUM, NUM>
        where CONVERTER: IConverter<NUM>, new()
    {
    } //StructuredPackage<NUM>

    public static class Package<NUM, CONVERTER> where NUM :
        System.Numerics.IBinaryFloatingPointIeee754<NUM>
        where CONVERTER: IConverter<NUM>, new()
    {
        static CONVERTER converter;
        public static CONVERTER Converter { get {
            converter ??= new();
            return converter;
        }}

        public static class OperatorSample {
            public static NUM Calculate(NUM a, NUM b) =>
               Converter.FromInteger(2) +  a * b / (a + b);
            public static NUM More(NUM a) =>
                -a;
        } //class OperatorSample

        public static class MathFunctions {
            public static NUM Calculate(NUM a, NUM b) =>
                Converter.FromFloat(0.33f) + NUM.Pow(a, b) * NUM.Sqrt(a);
            public static NUM CalculateMore(NUM a, NUM b) =>
                NUM.Log(a, b) * NUM.Exp(a);
        } //class MathFunctions

    } //class Package

}
