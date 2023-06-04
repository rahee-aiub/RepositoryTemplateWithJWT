using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using RecruitmentManagement.Interface;
using RecruitmentManagement.Service;
using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConnectionHelper.DefaultConnection = builder.Configuration.GetConnectionString("DBConnection");

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Get from Tonmoy vai
//builder.Services.AddControllers(options =>
//                    options.Filters.Add<ApiExceptionFilterAttribute>())
//                .AddFluentValidation(x => x.AutomaticValidationEnabled = false)
//                .AddNewtonsoftJson(options =>
//                {
//                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
//                });


//Get from https://stackoverflow.com/questions/38728200/how-to-turn-off-or-handle-camelcasing-in-json-response-asp-net-core/58135043#58135043
builder.Services.AddMvc(setupAction => {
    setupAction.EnableEndpointRouting = false;
}).AddJsonOptions(jsonOptions =>
{
    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
}).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = "http://localhost:5005",
        ValidIssuer = "ABCXYZ",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisisasecretkey@123"))
    };
});


builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Payroll WebAPI", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddScoped<IUserService, UserService>();
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
