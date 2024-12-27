/*
    Copyright (C) 2024 by Sergey A Kryukov
    https://www.SAKryukov.org
    https://github.com/SAKryukov
*/

namespace SA.Tests {
    using FloatSpecialization = GenericNumerics.Library<float, GenericNumerics.FloatConverter>;
    using HalfSpecialization = GenericNumerics.Library<System.Half, GenericNumerics.HalfConverter>;
    using DoubleSpecialization = GenericNumerics.Library<double, GenericNumerics.DoubleConverter>;
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
            WriteLine(DoubleSpecialization.SimpsonRule.Integrate(0.4, 8, x => 1/double.Sqrt(1 + x), 40000));            
            WriteLine(DoubleSpecialization.GaussKronrodQuadrature.Integrate(0.4, 8, x => 1/double.Sqrt(1 + x) ));
            WriteLine($"Half x => 1/double.Sqrt(1 + x)");
            WriteLine(HalfSpecialization.SimpsonRule.Integrate((System.Half)0.4, (System.Half)8, x => (System.Half)1/System.Half.Sqrt((System.Half)1 + x), 4000));            
            WriteLine(HalfSpecialization.GaussKronrodQuadrature.Integrate((System.Half)0.4, (System.Half)8, x => (System.Half)1/System.Half.Sqrt((System.Half)1 + x) ));            
            WriteLine($"Float x => 1/double.Sqrt(1 + x)");
            WriteLine(FloatSpecialization.SimpsonRule.Integrate(0.4f, 8, x => 1/float.Sqrt(1f + x), 4000));            
            WriteLine(FloatSpecialization.GaussKronrodQuadrature.Integrate(0.4f, 8, x => 1/float.Sqrt(1 + x) ));
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
