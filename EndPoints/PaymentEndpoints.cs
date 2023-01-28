using Swashbuckle.AspNetCore.Annotations;

namespace Payment.API.EndPoints;

public static class PaymentEndpoints
{
    public static void MapPaymentEndpoints(this WebApplication app)
    {
        app.MapPost("/Payment", Payment).Produces<string>(StatusCodes.Status201Created)
            .Produces<int>((int)StatusCodes.Status404NotFound)
              .WithMetadata(new SwaggerOperationAttribute
              {
                  Summary = "Cretate PAYMENT",
                  Description = "yeni satış başlat",
                  OperationId = "SatisBaslat",
                  Tags = new[] { "satış" }
              })
            .WithName("Payment")
            .WithTags("Payment");
    }

    static IResult Payment()
    {
        string strResult = "html sonuç";
        return Results.Ok(strResult);
    }
}
