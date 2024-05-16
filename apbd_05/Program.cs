using apbd_05.context;
using apbd_05.repository;
using apbd_05.service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ITripRepository, StandardTripRepository>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<Apbd05Context, Apbd05Context>();
builder.Services.AddScoped<TripContext, TripContext>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientRepository, StandardClientRepository>();
builder.Services.AddScoped<IClientTripService, ClientTripService>();
builder.Services.AddScoped<IClientTripRepository, StandardClientTripRepository>();
builder.Services.AddScoped<ClientTripContext, ClientTripContext>();
builder.Services.AddScoped<ClientContext, ClientContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();