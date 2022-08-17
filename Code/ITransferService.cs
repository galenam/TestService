public interface ITransferService {
    Entity Create(string json);
    string Transfer(Entity e);
}