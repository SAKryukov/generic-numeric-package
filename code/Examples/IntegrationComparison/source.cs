using System;

namespace SA.GenericNumerics {

    public static partial class Library<NUM, CONVERTER> {

        public delegate NUM SingleArgumentFunction(NUM x);
        public static readonly NUM zero = CONVERTER.FromInteger(0);
        public static readonly NUM one = CONVERTER.FromInteger(1);
        public static readonly NUM two = CONVERTER.FromInteger(2);
        public static readonly NUM four = CONVERTER.FromInteger(4);
        public static readonly NUM six = CONVERTER.FromInteger(6);

        class NodeWeight(double node, double weight, bool single = false) {
            internal double Node { get; } = node;
            internal double Weight { get; } = weight;
            internal bool Single { get; } = single;
        } //internal

        static readonly NodeWeight[] pointsGaussKronrod = [
            // Gauss:
            new (0.949107912342759, 0.129484966168870),
            new (0.741531185599394, 0.279705391489277),
            new (0.405845151377397, 0.381830050505119),
            new (0, 0.417959183673469, single: true),
            // Kronrod:
            new (0.991455371120813, 0.022935322010529),
            new (0.949107912342759, 0.063092092629979),
            new (0.864864423359769, 0.104790010322250),
            new (0.741531185599394, 0.140653259715525),
            new (0.586087235467691, 0.169004726639267),
            new (0.405845151377397, 0.190350578064785),
            new (0.207784955007898, 0.204432940075298),
            new (0, 0.209482141084728, single: true),
        ];

        public static class GaussKronrodQuadrature {
            public static NUM Integrate(NUM from, NUM to, SingleArgumentFunction f) {
                NUM width = to - from;
                NUM sum = zero;
                for (int point = 0; point < pointsGaussKronrod.Length; ++point) {
                    NUM weight = CONVERTER.FromDouble(pointsGaussKronrod[point].Weight) * width / four; //SA???
                    NUM position1 = (-CONVERTER.FromDouble(pointsGaussKronrod[point].Node) + one) * width / two + from;
                    sum += weight * f(position1);
                    if (!pointsGaussKronrod[point].Single) {
                        NUM position2 = (+CONVERTER.FromDouble(pointsGaussKronrod[point].Node) + one) * width / two + from;
                        sum += weight * f(position2);
                    } //if
                } //loop
                return sum;
            } //Integrate
        } //class GaussKronrodQuadrature

        public static class SimpsonRule {
            // 1/3 rule:
            // (b-a)/6 * ( f(a) + 4*f((a+b)/2) + f(b))
            public static NUM Integrate(NUM from, NUM to, SingleArgumentFunction f, int pieces) {
                NUM sum = zero;
                NUM deltaX = (to - from) / CONVERTER.FromInteger(pieces);
                for (int step = 0; step < pieces; ++step) {
                    NUM floatStep = CONVERTER.FromInteger(step);
                    NUM a = from + floatStep * deltaX;
                    NUM b = a + deltaX;
                    sum += deltaX * ( f(a) + four * f((a + b) / two) + f(b)) / six;
                } //loop
                return sum;
            } //Integrate
        } //class SimpsonRule

    } //Library

}
