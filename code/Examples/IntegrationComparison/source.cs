namespace NumericalIntegration {
    using SA.GenericNumerics;

    public static partial class ExamplePackage<NUM, CONVERTER> where NUM :
        System.Numerics.IBinaryFloatingPointIeee754<NUM>
        where CONVERTER : IConverter<NUM> {}

}
