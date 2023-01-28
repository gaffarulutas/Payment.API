using System.ComponentModel;

namespace Payment.API.ComponentModel;

public enum EBank : byte
{
    [Description("GARANTI")]
    GarantiBank = 1,

    [Description("PAYU")]
    Payu = 2,

    [Description("UNITED PAYMENT")]
    UnitedPayment = 3,

    [Description("IYZICO")]
    Iyzico = 4,

    [Description("PAYCELL")]
    Paycell = 5
}
