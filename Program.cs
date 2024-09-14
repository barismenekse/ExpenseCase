using System.Text.Json.Serialization;
using AutoMapper.EquivalencyExpression;
using ExpenseCase.DataAccess;
using ExpenseCase.DataAccess.Context;
using ExpenseCase.DataAccess.Interfaces;
using ExpenseCase.DataAccess.Repositories;
using ExpenseCase.DataAccess.Repositories.Interfaces;
using ExpenseCase.Filters;
using ExpenseCase.Infrastructure.Services;
using ExpenseCase.Infrastructure.Services.Interfaces;
using ExpenseCase.Mapping;
using ExpenseCase.Middlewares;
using ExpenseCase.Services;
using ExpenseCase.Services.Interfaces;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
// Add services to the container.
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
    )
    .AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ExpenseCase API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        }
    );
    c.OperationFilter<AuthenticationRequirementsOperationFilter>();
});
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var connectionString = builder.Configuration.GetConnectionString("ExpenseCase");
builder.Services.AddDbContextPool<MyDbContext>(options =>
    options.UseSqlServer(connectionString, x => x.MigrationsHistoryTable("MigrationsHistory")));
builder.Services.AddAutoMapper((cfg) =>
{
    cfg.AddProfile<MappingProfile>();
    cfg.AddCollectionMappers();
});
builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IAccountService, AccountService>();
builder.Services.AddTransient<ITransactionService, TransactionService>();
builder.Services.AddTransient<IReportService, ReportService>();
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

app.UseJwtAuthenticationMiddleware();
app.UseExceptionHandleMiddleware();

app.Run();