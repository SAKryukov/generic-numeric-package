/*
    Copyright (C) 2024 by Sergey A Kryukov
    https://www.SAKryukov.org
    https://github.com/SAKryukov
*/

using System.Numerics;

namespace SA.GenericNumerics {

    public interface IConverter<NUM> {
        static abstract NUM FromInteger(int value);
        static abstract NUM FromHalf(System.Half value);
        static abstract NUM FromFloat(float value);
        static abstract NUM FromDouble(double value);
    } //interface IConverter

    public struct HalfConverter : IConverter<System.Half> {
        public static System.Half FromInteger(int value) => (System.Half)value;
        public static System.Half FromHalf(System.Half value) => value;
        public static System.Half FromFloat(float value) => (System.Half)value;
        public static System.Half FromDouble(double value) => (System.Half)value;
    } //HalfConverter

    public struct FloatConverter : IConverter<float> {
        public static float FromInteger(int value) => value;
        public static float FromHalf(System.Half value) => (float)value;
        public static float FromFloat(float value) => value;
        public static float FromDouble(double value) => (float)value;
    } //HalfConverter

    public struct DoubleConverter : IConverter<double> {
        public static double FromInteger(int value) => value;
        public static double FromHalf(System.Half value) => (double)value;
        public static double FromFloat(float value) => value;
        public static double FromDouble(double value) => value;
    } //HalfConverter

}
