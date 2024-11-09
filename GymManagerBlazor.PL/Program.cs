using FluentValidation;
using GymManagerBlazor.BUS.Mapper;
using GymManagerBlazor.BUS.Models;
using GymManagerBlazor.BUS.Services.Implement;
using GymManagerBlazor.BUS.Services.Interface;
using GymManagerBlazor.BUS.Validators;
using GymManagerBlazor.DAL.DataAccess;
using GymManagerBlazor.DAL.Repository.Implement;
using GymManagerBlazor.DAL.Repository.Interfaces;
using GymManagerBlazor.PL;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddHttpClient<ApiClient>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7026"); 
});
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<IClassRegistrationRepository, ClassRegistrationRepository>();

builder.Services.AddTransient<IValidator<TrainerModel>, TrainerModelValidator>();
builder.Services.AddTransient<IValidator<ClassModel>, ClassModelValidator>();
builder.Services.AddTransient<IValidator<MemberModel>, MemberModelValidator>();
builder.Services.AddTransient<IValidator<ClassRegistrationModel>, ClassRegistrationModelValidator>();


builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IClassRegistrationService, ClassRegistrationService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddMudServices();
await builder.Build().RunAsync();
