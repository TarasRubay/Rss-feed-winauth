using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Rss_feed_winauth.DataBaseContext;
using Rss_feed_winauth.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsImplementationPolicy",
              policy =>
              {
                  policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
              });
}
);
builder.Services.AddScoped<FeedRepositories>();
builder.Services.AddDbContext<TableContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConection"));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("MyCorsImplementationPolicy");
app.MapControllers();

app.Run();
