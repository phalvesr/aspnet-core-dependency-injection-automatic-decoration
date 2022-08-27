using DecoratedUnitOfWork.Data;
using DecoratedUnitOfWork.Models;

namespace DecoratedUnitOfWork.Services.ItemOneServices;

public class AddItemOneService : IItemOneService
{
    private readonly ItemOneRepository repository;

    public AddItemOneService(ItemOneRepository repository)
    {
        this.repository = repository;
    }

    public void Execute(ItemOne item)
    {
        repository.Add(item);
    }
}
