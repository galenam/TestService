using System;
using System.Collections.Generic;

public class EntityService : IEntityService
{
    static Dictionary<Guid, Entity> _storage = new Dictionary<Guid, Entity>();
    public bool Add(Entity e)
    {
        if (!_storage.ContainsKey(e.Id))
        {
            _storage.Add(e.Id, e);
            return true;
        }
        return false;
    }

    public Entity Get(Guid guid)
    {
        if (_storage.ContainsKey(guid))
        {
            return _storage[guid];
        }
        return null;
    }
}