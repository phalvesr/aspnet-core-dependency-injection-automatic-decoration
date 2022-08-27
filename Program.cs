using DecoratedUnitOfWork.Data;
using DecoratedUnitOfWork.Decoration;
using DecoratedUnitOfWork.Services.ItemOneServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<ItemOneRepository>();
//builder.Services.AddScoped<AddItemOneService>();
builder.Services.AddScoped<GetAllItems>();

// <TService, TImplementation>
builder.Services.AddScopedWithDecoration<IItemOneService, AddItemOneServiceDecorator, AddItemOneService>();

//builder.Services.AddScoped<IItemOneService>(sp =>
//{
//    var service = sp.GetRequiredService<AddItemOneService>();
//    var unitOfWork = sp.GetRequiredService<UnitOfWork>();

//    return new AddItemOneServiceDecorator(service, unitOfWork);
//});


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
