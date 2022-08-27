using DecoratedUnitOfWork.Data;
using DecoratedUnitOfWork.Models;

namespace DecoratedUnitOfWork.Services.ItemOneServices;

public class GetAllItems
{
    private readonly ItemOneRepository repository;

    public GetAllItems(ItemOneRepository repository)
    {
        this.repository = repository;
    }

    public IEnumerable<ItemOne> GetItems()
    {
        return repository.GetItems();
    }
}

