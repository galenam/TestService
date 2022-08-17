using System;

public interface IEntityService
{
    bool Add(Entity e);
    Entity Get(Guid guid);
}