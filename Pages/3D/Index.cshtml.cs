using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Payment.API.Models;
using Payment.API.Services;
namespace Payment.API.Pages._3D;


[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
[IgnoreAntiforgeryToken]

public class IndexModel : PageModel
{
    private readonly IBankService bankService;
    public string Html3dValidation { get; set; }

    public IndexModel(IBankService bankService)
    {
        this.bankService = bankService;
    }

    public async Task OnPostAsync()
    {
        var response = bankService.ThreeDVerification(new Card(Request.Form));
        Html3dValidation = await response.ConfigureAwait(false);
        ViewData[nameof(Html3dValidation)] = Html3dValidation;
    }

    public void OnGet()
    {
        // await  Response.WriteAsJsonAsync("Hoþgeldin..");
    }


}

