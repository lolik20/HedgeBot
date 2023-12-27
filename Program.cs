using HedgeBot.Interfaces;
using HedgeBot.Models;
using HedgeBot.Services;
using QuickFix;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITradeService, TradeService>();
builder.Services.AddTransient<IApplication,TradeService>();
builder.Services.AddSingleton<ITradeFactory, TradeFactory>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
