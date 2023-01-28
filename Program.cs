using Payment.API.Helper;
var builder = WebApplication.CreateBuilder(args);
builder.Services.MapServices();
var app = builder.Build();
app.MapDependency();
