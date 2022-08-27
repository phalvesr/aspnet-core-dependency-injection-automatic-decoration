using DecoratedUnitOfWork.Data;
using DecoratedUnitOfWork.Models;

namespace DecoratedUnitOfWork.Services.ItemOneServices;

public class AddItemOneServiceDecorator : IItemOneService
{
    private readonly IItemOneService service;
    private readonly UnitOfWork unitOfWork;
    private readonly Random rng;

    public AddItemOneServiceDecorator(AddItemOneService service, UnitOfWork unitOfWork)
    {
        this.service = service;
        this.unitOfWork = unitOfWork;
        rng = new Random();
    }

    public void Execute(ItemOne item)
    {

        service.Execute(item);

        if (rng.NextDouble() > .5)
        {
            unitOfWork.SaveChanges();
        }
    }
}

