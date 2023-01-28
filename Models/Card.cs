using Payment.API.Services;
using System.Text.Json.Serialization;

namespace Payment.API.Models;

public record Card
{

    [JsonIgnore]
    public string HolderName { get; set; }

    [JsonIgnore]
    public string CardNumber { get; set; }

    [JsonIgnore]
    public int Month { get; set; }

    [JsonIgnore]
    public int Year { get; set; }

    [JsonIgnore]
    public int Cvv { get; set; }

    [JsonIgnore]
    public User user { get; set; }

    public Card(IFormCollection Form)
    {
        IUserService userService = new UserService();
        this.HolderName = Form["HolderName"].ToString();
        this.CardNumber = Form["CardNumber"].ToString();
        this.Month = Convert.ToInt32(Form["Month"]);
        this.Year = Convert.ToInt32(Form["Year"]);
        this.Cvv = Convert.ToInt32(Form["Cvv"]);
        this.user = userService.GetById(1);
    }

}
