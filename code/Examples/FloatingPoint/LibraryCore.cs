namespace SA.GenericNumerics {

    public static partial class Library<NUM, CONVERTER> where NUM :
        System.Numerics.IBinaryFloatingPointIeee754<NUM>
        where CONVERTER : IConverter<NUM> { }

}
