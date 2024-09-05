using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var pagos = new[]
{
    new Pago(123123, 123456, 10),
    new Pago(123123, 123456, 20),
    new Pago(123123, 123456, 30),
    new Pago(987987, 98765, 40),
    new Pago(987987, 123456, 50),
};


app.MapGet("/api/pagos", () =>
    {
        var pagosList = pagos.ToList(); 
        return pagosList;
    })
    .WithName("GetPagos")
    .WithOpenApi();

app.MapGet("/api/pagos/{id}", (int id) =>
    {
        var pago = pagos.FirstOrDefault(p => p.Id == id);
        if (pago == null)
        {
            return Results.NotFound();
        }
        return Results.Ok(pago);
    })
    .WithName("GetPagoById")
    .WithOpenApi();

app.MapPost("/api/pagos", (Pago pago) =>
    {
        pagos = pagos.Append(pago).ToArray();
        return Results.Created($"/api/pagos/{pago.Id}", pago);
    })
    .WithName("CreatePago")
    .WithOpenApi();

app.MapGet("/api/tutorial", () =>
    {
        const string link = "https://youtube.com/watch?v=dQw4w9WgXcQ";
        return Results.Ok(link);
    })
    .WithName("GetTutorial")
    .WithOpenApi();

app.MapGet("/api/estado", () =>
    {
        return Results.Text("Mira el codigo de estado", statusCode: 418);
    })
    .WithName("GetEstado")
    .WithOpenApi();


app.Run();
