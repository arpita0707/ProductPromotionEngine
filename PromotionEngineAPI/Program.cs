using PromotionEngineBL;
using PromotionEngineDAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IProductBL, ProductBL>();
builder.Services.AddScoped<IProductDAL, ProductDAL>();
builder.Services.AddScoped<ICartBL, CartBL>();
builder.Services.AddScoped<IPromotionDAL, PromotionDAL>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
