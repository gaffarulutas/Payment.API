using Payment.API.ComponentModel;
using Payment.API.Models;
using System.Text;
namespace Payment.API.Services;

public interface IBankService
{
    ValueTask<string> ThreeDVerification(Card card);
}

public class BankService : IBankService
{

    public ValueTask<string> ThreeDVerification(Card card)
    {
        return GetBank(card) switch
        {
            EBank.Paycell => Paycell3D(card),
            EBank.Payu => Payu3D(card),
            EBank.GarantiBank => GarantiBank3D(card),
            EBank.UnitedPayment => UnitedPayment3D(card),
            _ => new ValueTask<string>(string.Empty),
        };

    }

    private ValueTask<string> GarantiBank3D(Card card)
    {
        StringBuilder @string = new();
        @string.Append("<form name=\"PayForm\" action=\"@ActionAdres\" method=\"post\">");
        @string.AppendLine("<input type=\"hidden\" name=\"@CardHolderDTO\" value=\"" + card.HolderName + "\">");
        @string.AppendLine("<input type=\"hidden\" name=\"@CardNumberDTO\" value=\"" + card.CardNumber + "\">");
        @string.AppendLine("<input type=\"hidden\" name=\"@YearDTO\"  value=\"" + card.Year + "\">");
        @string.AppendLine("<input type=\"hidden\" name=\"@MontDTO\"  value=\"" + card.Month + "\">");
        @string.AppendLine("<input type=\"hidden\" name=\"@CvvDTO\"  value=\"" + card.Cvv + "\">");
        @string.AppendLine("<script type=\"text/javascript\"> document.forms[\"PayForm\"].submit(); </script>");
        @string = @string.Replace("@ActionAdres", "https://algoritma.io/");
        return new ValueTask<string>(@string.ToString());
    }

    private ValueTask<string> UnitedPayment3D(Card card)
    {
        throw new NotImplementedException();
    }


    private ValueTask<string> Payu3D(Card card)
    {
        throw new NotImplementedException();
    }

    private ValueTask<string> Paycell3D(Card card)
    {
        return new ValueTask<string>(string.Empty);
    }


    static EBank GetBank(Card card)
    {
        return card.user.Country.CountryId switch
        {
            1 => EBank.Paycell,
            2 => EBank.Payu,
            3 => EBank.GarantiBank,
            4 => EBank.UnitedPayment,
            _ => EBank.Iyzico,
        };
    }
}
