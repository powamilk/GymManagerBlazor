using GymManagerBlazor.BUS.Services.Implement;
using GymManagerBlazor.BUS.Services.Interface;
using GymManagerBlazor.DAL.DataAccess;
using GymManagerBlazor.DAL.Repository.Implement;
using GymManagerBlazor.DAL.Repository.Interfaces;
using GymManagerBlazor.PL;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient<ApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7026"); 
});

builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<IClassRegistrationRepository, ClassRegistrationRepository>();


builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IClassRegistrationService, ClassRegistrationService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
