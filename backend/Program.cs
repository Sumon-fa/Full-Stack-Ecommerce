using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using backend.Db;
using backend.Models;
using backend.DTOs;
using backend.Services;
using backend.Middlware;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
     options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
     options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
{
 options.Password.RequiredLength = 4;
 options.Password.RequireDigit = false;
 options.Password.RequireLowercase = false;
 options.Password.RequireUppercase = false;
 options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<AppDbContext>();

builder.Services
         .AddAuthentication(options =>
            {
             options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
             options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
             options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
             options.TokenValidationParameters = new TokenValidationParameters
             {
              ValidateIssuer = true,
              ValidateAudience = true,
              ValidateLifetime = true,
              ValidIssuer = builder.Configuration["Jwt:Issuer"],
              ValidAudience = builder.Configuration["Jwt:Audience"],
              IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
             };
            }
            );




// Configure Swagger/OpenAPI
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<RouteOptions>(options =>
options.LowercaseUrls = true
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsPolicy", build =>
{
 build.WithOrigins("https://fs133-fullstack.netlify.app").AllowAnyMethod().AllowAnyHeader();
})
);

// Configure services
builder.Services.AddScoped<ICrudService<Product, ProductDTO>, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddTransient<ErrorHandlerMiddleware>();

var app = builder.Build();

// Run in development mode
if (app.Environment.IsDevelopment())
{
 app.UseSwagger();
 app.UseSwaggerUI();
 using (var scope = app.Services.CreateScope())
 {
  var DbContext = scope.ServiceProvider.GetService<AppDbContext>();
  var config = scope.ServiceProvider.GetService<IConfiguration>();
  if (DbContext is not null && config.GetValue<bool>("CreateDbStart", false))
  {
   DbContext.Database.EnsureDeleted();
   DbContext.Database.EnsureCreated();
  }
 }
}

// Configure the app
app.UseHttpsRedirection();


app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseCors("corsPolicy");
app.UseAuthentication();
app.UseAuthorization();

// Map controllers and run the app
app.MapControllers();
app.Run();