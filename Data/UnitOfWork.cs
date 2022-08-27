using DecoratedUnitOfWork.Models;

namespace DecoratedUnitOfWork.Data;

public class UnitOfWork : IDisposable
{
    private static IList<ItemOne> changes = new List<ItemOne>();
    private static IDictionary<Guid, ItemOne> items = new Dictionary<Guid, ItemOne>();

    internal int SaveChanges()
    {
        int changesCount = 0;
        foreach (var change in changes)
        {
            items.Add(change.id, change);
            changesCount++;
        }

        return changesCount;
    }

    internal IEnumerable<ItemOne> GetItems()
    {
        return items.Values;
    }

    internal void AddItemOne(ItemOne item)
    {
        changes.Add(item);
    }

    public void Dispose()
    {
        changes.Clear();
    }
}
