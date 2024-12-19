/*
    Copyright (C) 2024 by Sergey A Kryukov
    https://www.SAKryukov.org
    https://github.com/SAKryukov
*/

namespace Tests {
    using DoubleSpecialization = GenericNumerics.Package.Package<double>;
    using FloatSpecialization = GenericNumerics.Package.Package<float>;
    using HalfSpecialization = GenericNumerics.Package.Package<System.Half>;

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
        } //Main

    } //class Tests

}
