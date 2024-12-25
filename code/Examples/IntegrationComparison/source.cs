namespace NumericalIntegration {
    using SA.GenericNumerics;

        public static class IntegrationComparison<NUM, CONVERTER> where NUM :
            System.Numerics.IBinaryFloatingPointIeee754<NUM>
            where CONVERTER: IConverter<NUM>, new() {

        public abstract class NumericalIntegration {

            public delegate NUM SingleArgumentFunction(NUM x);
            internal static readonly NUM zero = CONVERTER.FromInteger(0);
            internal static readonly NUM two = CONVERTER.FromInteger(2);
            internal static readonly NUM three = CONVERTER.FromInteger(2);
            internal static readonly NUM four = CONVERTER.FromInteger(2);
            internal static readonly NUM half = CONVERTER.FromDouble(0.5);

            public NumericalIntegration(NUM from, NUM to, int steps, SingleArgumentFunction func) {
                fromPoint = from;
                toPoint = to;
                numSteps = steps;
                eps = CONVERTER.FromDouble(0.0005);
                h = (toPoint - fromPoint) / (CONVERTER.FromInteger(numSteps) + CONVERTER.FromInteger(1));
                this.func = func;
            } //NumericalIntegration

            public abstract NUM Integration();

            protected NUM fromPoint;
            protected NUM toPoint;
            protected SingleArgumentFunction func;
            protected int numSteps;
            protected NUM eps;
            protected NUM h;
        } //NumericalIntegration

        public sealed class RectangleRule(NUM from, NUM to, int steps, NumericalIntegration.SingleArgumentFunction func) : NumericalIntegration(from, to, steps, func) {
            public override NUM Integration() {
                NUM a = fromPoint;
                NUM value = func(fromPoint);
                for (int step = 1; step <= numSteps; step++) {
                    a += h;
                    value += func(a);
                } //loop
                return h * value;
            } //Integration
        } //class RectangleRule

        public sealed class MidPointRule(NUM from, NUM to, int steps, NumericalIntegration.SingleArgumentFunction func) : NumericalIntegration(from, to, steps, func) {
            public override NUM Integration() {
                NUM a = fromPoint;
                NUM value = func((two * fromPoint + h) / two);
                for (int step = 1; step <= numSteps; step++) {
                    a += h;
                    value += func((two * a + h) / two);
                } //loop
                return h * value;
            } //Integration
        } //class MidPointRule

        public sealed class TrapezoidRule : NumericalIntegration {
            public TrapezoidRule(NUM from, NUM to, int steps, SingleArgumentFunction func)
                : base(from, to, steps, func) { }
            public override NUM Integration() {
                NUM a = fromPoint;
                NUM value = func(fromPoint) + func(fromPoint + h);
                for (int step = 1; step <= numSteps; step++) {
                    a += h;
                    value += func(a) + func(a + h);
                } //loop
                return half * h * value;
            } //Integration
        } //class TrapezoidRule

        public sealed class SimpsonRule : NumericalIntegration {
            public SimpsonRule(NUM from, NUM to, int steps, SingleArgumentFunction func)
                : base(from, to, steps, func) {
                h = (toPoint - fromPoint) / CONVERTER.FromInteger(numSteps * 2);
            }
            public override NUM Integration() {
                NUM valueEven = zero;
                NUM valueOdd = zero;
                for (int step = 1; step <= numSteps; step++) {
                    valueOdd += func(fromPoint + h * CONVERTER.FromInteger(2 * step - 1));
                    if (step <= numSteps - 1)
                        valueEven += func(fromPoint + h * CONVERTER.FromInteger(2 * step));
                }
                return (func(fromPoint) + func(toPoint) + two * valueEven + four * valueOdd) * (this.h / three);
            } //Integration
        } //class SimpsonRule
    }
}
