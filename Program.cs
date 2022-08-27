using DecoratedUnitOfWork.Data;
using DecoratedUnitOfWork.Decoration;
using DecoratedUnitOfWork.Services.ItemOneServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ItemOneRepository>();
builder.Services.AddScoped<GetAllItems>();


builder.Services.AddScopedWithDecoration<IItemOneService, AddItemOneServiceDecorator, AddItemOneService>();


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
