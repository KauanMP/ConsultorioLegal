using AutoMapper;
using CL.CoreShared.ModelViews;
using CL.Manager.Mappings;
using CL.Manager.Validator;
using CL.WebApi.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureMySqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryWrapper();

builder.Services.AddAutoMapper(typeof(NovoclienteMappingProfile), typeof(AlteraClienteMappingProfile));

builder.Services.AddControllers().AddFluentValidation();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IValidator<NovoCliente>, NovoClienteValidator>();
builder.Services.AddTransient<IValidator<AlteraCliente>, AlteraClienteValidator>();

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
