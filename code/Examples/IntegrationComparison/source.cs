namespace NumericalIntegration {
    using SA.GenericNumerics;

    public static partial class IntegrationPackage<NUM, CONVERTER> where NUM :
        System.Numerics.IBinaryFloatingPointIeee754<NUM>
        where CONVERTER : IConverter<NUM> {

        public delegate NUM SingleArgumentFunction(NUM x);
        public static readonly NUM zero = CONVERTER.FromInteger(0);
        public static readonly NUM two = CONVERTER.FromInteger(2);
        public static readonly NUM four = CONVERTER.FromInteger(4);
        public static readonly NUM six = CONVERTER.FromInteger(6);

        public static class Simpson {
            // 1/3 rule:
            // (b-a)/6 * ( f(a) + 4*f((a+b)/2) + f(b))
            public static NUM Integral(int pieces, NUM from, NUM to, SingleArgumentFunction f) {
                NUM sum = zero;
                NUM deltaX = (to - from) / CONVERTER.FromInteger(pieces);
                for (int step = 0; step < pieces; ++step) {
                    NUM floatStep = CONVERTER.FromInteger(step);
                    NUM a = from + floatStep * deltaX;
                    NUM b = a + deltaX;
                    sum += deltaX * ( f(a) + four * f((a + b) / two) + f(b)) / six;
                } //loop
                return sum;
            } //Integral
        } //class Simpson

    }

}
