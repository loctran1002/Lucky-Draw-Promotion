using LuckyDrawPromotion.Data.Entity;
using LuckyDrawPromotion.Services;
using LuckyDrawPromotion.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add my dependencies
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAwardService, AwardService>();
builder.Services.AddTransient<IGiftService, GiftService>();
builder.Services.AddTransient<ISettingService, SettingService>();
builder.Services.AddTransient<IAdminService, AdminService>();
builder.Services.AddTransient<ICampaignService, CampaignService>();
builder.Services.AddTransient<ILogService, LogService>();
builder.Services.AddTransient<IInsCodeService, InsCodeService>();
builder.Services.AddTransient<IRuleService, RuleService>();
builder.Services.AddTransient<ICodeService, CodeService>();

builder.Services.AddControllers();
builder.Services.AddDbContext<PromotionDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
