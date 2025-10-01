using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .Scan(
        selector => selector
            .FromAssemblies(
                HotelBooking.Infrastructure.AssemblyReference.Assembly,
                HotelBooking.Persistence.AssemblyReference.Assembly)
            .AddClasses(false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());

builder.Services.AddMediatR(HotelBooking.Application.AssemblyReference.Assembly);

builder
    .Services
    .AddControllers()
    .AddApplicationPart(HotelBooking.Presentation.AssemblyReference.Assembly);

builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
