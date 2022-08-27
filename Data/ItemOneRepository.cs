using DecoratedUnitOfWork.Models;

namespace DecoratedUnitOfWork.Data;

public class ItemOneRepository
{
    private readonly UnitOfWork unitOfWork;

    public ItemOneRepository(UnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public void Add(ItemOne item)
    {
       unitOfWork.AddItemOne(item);
    }

    public IEnumerable<ItemOne> GetItems()
    {
        return unitOfWork.GetItems();
    }
}

