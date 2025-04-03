using Ecom.Apl.Middelware;
using Ecom.infrastructure;
var builder = WebApplication.CreateBuilder(args);
// In your Program.cs or Startup.cs
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CORSPolicy", policyBuilder =>
    {
        policyBuilder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .WithOrigins();
    });
});
builder.Services.AddMemoryCache();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.InfrastructurConfiguration(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CORSPolicy");
app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/Errors/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
