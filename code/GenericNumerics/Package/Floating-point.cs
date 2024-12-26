/*
    Copyright (C) 2024 by Sergey A Kryukov
    https://www.SAKryukov.org
    https://github.com/SAKryukov
*/

namespace SA.GenericNumerics {

    public static class StructuredPackage<NUM> where NUM :
        System.Numerics.IDecrementOperators<NUM>,
        System.Numerics.IIncrementOperators<NUM>,
        System.Numerics.INumberBase<NUM>
    {
        public static class Sample {
            public static NUM Calculate(NUM a, NUM b) => a + b;
            public static NUM CalculateMore(NUM a, NUM b) => a * b;
        } //class Sample
    } //StructuredPackage<NUM>

    public static class Package<NUM, CONVERTER> where NUM :
        System.Numerics.IBinaryFloatingPointIeee754<NUM>
        where CONVERTER: IConverter<NUM>
    {

        public static class OperatorSample {
            public static NUM Calculate(NUM a, NUM b) =>
               CONVERTER.FromInteger(2) +  a * b / (a + b);
            public static NUM CalculateMore(NUM a) =>
                -a;
        } //class OperatorSample

        public static class MathFunctions {
            public static NUM Calculate(NUM a, NUM b) =>
                CONVERTER.FromFloat(0.33f) + NUM.Pow(a, b) * NUM.Sqrt(a);
            public static NUM CalculateMore(NUM a, NUM b) =>
                NUM.Log(a, b) * NUM.Exp(a);
        } //class MathFunctions

    } //class Package

}
