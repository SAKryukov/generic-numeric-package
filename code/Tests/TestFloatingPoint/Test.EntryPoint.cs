/*
    Copyright (C) 2024 by Sergey A Kryukov
    https://www.SAKryukov.org
    https://github.com/SAKryukov
*/

namespace SA.Tests {
    using DoubleSpecialization = GenericNumerics.Package<double, GenericNumerics.DoubleConverter>;
    using FloatSpecialization = GenericNumerics.Package<float, GenericNumerics.FloatConverter>;
    using HalfSpecialization = GenericNumerics.Package<System.Half, GenericNumerics.HalfConverter>;
    using DoubleNumericalIntegration = NumericalIntegration.IntegrationPackage<double, GenericNumerics.DoubleConverter>;
    using Complex = System.Numerics.Complex;
    using ComplexSpecialization = GenericNumerics.StructuredPackage<System.Numerics.Complex>;
    using static System.Console;

    class A(int a, int b) {
        internal int AA { get; set; } = a;
        internal int BB { get; set; } = b;
    }

    static class Tests {        
        static double Test1(double a, double b) =>
            DoubleSpecialization.MathFunctions.Calculate(a, b);
        static float Test2(float a, float b) =>
            FloatSpecialization.MathFunctions.CalculateMore(a, b);
        static System.Half Test3(System.Half a, System.Half b) =>
            HalfSpecialization.MathFunctions.CalculateMore(a, b);
        static void Test4() {
            WriteLine(DoubleNumericalIntegration.Simpson.Integral(40000, 1, 2, x => 1 / (x*x + 1)  ));            
        } //Test4

        static void Main() {
            Test4();
            WriteLine(Test1(1, 2));
            WriteLine(Test2(3, 4));
            WriteLine(Test3((System.Half)0.5, (System.Half)0.6));
            WriteLine(ComplexSpecialization.Sample.Calculate(new Complex(1, 2), new Complex(3, 4)));
        } //Main

    } //class Tests

}
