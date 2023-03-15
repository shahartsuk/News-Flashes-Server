using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

var corsBuilder = new CorsPolicyBuilder();
corsBuilder.AllowAnyHeader();
corsBuilder.AllowAnyMethod();
corsBuilder.AllowAnyOrigin();
//corsBuilder.AllowCredentials();
builder.Services.AddCors(options => {
    var frontendurl = configuration.GetValue<string>("frontend_url");
    //options.AddPolicy("AllowAll", corsBuilder.Build());

    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins(frontendurl).AllowAnyMethod().AllowAnyHeader();
    });
});




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
//what we add
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.UseAuthorization();

//app.MapControllers();


app.Run();
