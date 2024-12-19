/*
    Copyright (C) 2024 by Sergey A Kryukov
    https://www.SAKryukov.org
    https://github.com/SAKryukov
*/

namespace SA.GenericNumerics {

    public interface IConverter<NUM> {
        public NUM FromInteger(int self);
        NUM FromHalf(System.Half self);
        public NUM FromFloat(float self);
        public NUM FromDouble(double self);
    } //interface IConverter

    public struct HalfConverter : IConverter<System.Half> {
        public System.Half FromInteger(int self) => (System.Half)self;
        public System.Half FromHalf(System.Half self) => self;
        public System.Half FromFloat(float self) => (System.Half)self;
        public System.Half FromDouble(double self) => (System.Half)self;
    } //HalfConverter

    public struct FloatConverter : IConverter<float> {
        public float FromInteger(int self) => self;
        public float FromHalf(System.Half self) => (float)self;
        public float FromFloat(float self) => self;
        public float FromDouble(double self) => (float)self;
    } //HalfConverter

    public struct DoubleConverter : IConverter<double> {
        public double FromInteger(int self) => self;
        public double FromHalf(System.Half self) => (double)self;
        public double FromFloat(float self) => self;
        public double FromDouble(double self) => self;
    } //HalfConverter

    }
