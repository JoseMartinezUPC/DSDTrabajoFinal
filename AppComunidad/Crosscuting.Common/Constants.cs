namespace Crosscuting.Common
{
    public class Constants
    {
        public enum TipoOperacionEnum
        {
            Amortizacion = 34,
            Aporte = 9,
            CancelacionSBLC = 30,
            Interes = 4,
            InteresPasivo = 26,
            EmisionSBLC= 31,
            PosicionInicial= 21,
            Retiro= 10,
            RetiroC= 12,
            Rescate= 14,
            TraspasoCash= 7,
            TraspasoInstrumento= 8,
            CancelacionCompra= 22,
            CancelacionVenta= 28,
            CancelacionPasivo= 25,
            Distribucion= 13,
            Dividendos= 3,
            DividendosSTK= 23,
            EmisionPasivo= 24,
            FXCompra= 15,
            FXVenta= 16,
            RetornoCapital= 37,
            StockConsolidation= 33,
            StockSplit= 32,
            Vencimiento= 5,
            Venta= 2,
            VentaEx= 17,
            CapitalCall= 6,
            Compra= 1,
            Conversion= 20,
        }
    }

    public enum SEC_UserType
    {
        CLIENT,
        USER
    }

}
