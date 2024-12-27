/*
    Copyright (C) 2024 by Sergey A Kryukov
    https://www.SAKryukov.org
    https://github.com/SAKryukov
*/

namespace SA.GenericNumerics {

    public interface IConverter<NUM> {
        static abstract NUM FromInteger(long i);
        static abstract NUM FromDouble(double d);
    } //interface IConverter

    public struct HalfConverter : IConverter<System.Half> {
        static System.Half IConverter<System.Half>.FromInteger(long i) => (System.Half)i;
        static System.Half IConverter<System.Half>.FromDouble(double d) => (System.Half)d;
    } //HalfConverter

    public struct FloatConverter : IConverter<float> {
        static float IConverter<float>.FromInteger(long i) => i;
        static float IConverter<float>.FromDouble(double d) => (float)d;
    } //HalfConverter

    public struct DoubleConverter : IConverter<double> {
        static double IConverter<double>.FromInteger(long i) => i;
        static double IConverter<double>.FromDouble(double d) => d;
    } //DoubleConverter

}
