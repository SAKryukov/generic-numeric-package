/*
    Copyright (C) 2024 by Sergey A Kryukov
    https://www.SAKryukov.org
    https://github.com/SAKryukov
*/

namespace SA.GenericNumerics {

    public interface IConverter<NUM> {
        static abstract NUM FromInteger(int value);
        static abstract NUM FromDouble(double value);
    } //interface IConverter

    public struct HalfConverter : IConverter<System.Half> {
        static System.Half IConverter<System.Half>.FromInteger(int value) => (System.Half)value;
        static System.Half IConverter<System.Half>.FromDouble(double value) => (System.Half)value;
    } //HalfConverter

    public struct FloatConverter : IConverter<float> {
        static float IConverter<float>.FromInteger(int value) => value;
        static float IConverter<float>.FromDouble(double value) => (float)value;
    } //HalfConverter

    public struct DoubleConverter : IConverter<double> {
        static double IConverter<double>.FromInteger(int value) => value;
        static double IConverter<double>.FromDouble(double value) => value;
    } //DoubleConverter

}
