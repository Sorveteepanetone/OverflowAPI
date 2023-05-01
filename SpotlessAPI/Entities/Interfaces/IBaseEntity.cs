namespace SpotlessAPI.Entities.Interfaces;

public interface IBaseEntity<in T>
{
    void InsertNewRecord(T recordToBeInserted);

    void UpdateRecord(T recordToBeUpdated);

    void DeleteRecord(T recordToBeDeleted);
    
    void SaveChanges();
}