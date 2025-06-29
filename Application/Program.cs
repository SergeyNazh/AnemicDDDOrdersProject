using Application;
using Domain;
using Infrastructure;

WebApplicationBuilder webApplicationBuilder = WebApplication.CreateBuilder();

webApplicationBuilder.Configuration.AddInfrastructure();

webApplicationBuilder.Services.AddControllers();
webApplicationBuilder.Services.AddDomain();
webApplicationBuilder.Services.AddInfrastructure(webApplicationBuilder.Configuration);
webApplicationBuilder.Services.AddApplication();

if (webApplicationBuilder.Environment.IsDevelopment())
{
    webApplicationBuilder.Services.AddSwaggerGen();
}

WebApplication webApplication = webApplicationBuilder.Build();

if (webApplication.Environment.IsDevelopment())
{
    webApplication.UseDeveloperExceptionPage();
}
else
{
    webApplication.UseExceptionHandler();
}
webApplication.UseRouting();
if (webApplication.Environment.IsDevelopment())
{
    webApplication.UseSwagger();
    webApplication.UseSwaggerUI();
}
webApplication.MapControllers();

webApplication.Run();