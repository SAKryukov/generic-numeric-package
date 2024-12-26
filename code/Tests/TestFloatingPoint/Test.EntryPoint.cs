/*
    Copyright (C) 2024 by Sergey A Kryukov
    https://www.SAKryukov.org
    https://github.com/SAKryukov
*/

namespace SA.Tests {
    using DoubleSpecialization = SA.GenericNumerics.Package<double, GenericNumerics.DoubleConverter>;
    using FloatSpecialization = GenericNumerics.Package<float, GenericNumerics.FloatConverter>;
    using HalfSpecialization = GenericNumerics.Package<System.Half, GenericNumerics.HalfConverter>;
    using Complex = System.Numerics.Complex;
    using ComplexSpecialization = GenericNumerics.StructuredPackage<System.Numerics.Complex>;

    using Console = System.Console;

    static class Tests {
        static double Test1(double a, double b) =>
            DoubleSpecialization.MathFunctions.Calculate(a, b);
        static float Test2(float a, float b) =>
            FloatSpecialization.MathFunctions.CalculateMore(a, b);
        static System.Half Test3(System.Half a, System.Half b) =>
            HalfSpecialization.MathFunctions.CalculateMore(a, b);

        static void Main() {
            Console.WriteLine(Test1(1, 2));
            Console.WriteLine(Test2(3, 4));
            Console.WriteLine(Test3((System.Half)0.5, (System.Half)0.6));
            Console.WriteLine(ComplexSpecialization.Sample.Calculate(new Complex(1, 2), new Complex(3, 4)));
        } //Main

    } //class Tests

}
