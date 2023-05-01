using SpotlessAPI.Context;
using SpotlessAPI.Entities.Interfaces;
using SpotlessAPI.Models;

namespace SpotlessAPI.Entities.Implementations;

public class UserEntity : IUserEntity
{
    private readonly EFContext _efContext;

    public UserEntity(EFContext efContext)
    {
        _efContext = efContext;
    }
    public void InsertNewRecord(User recordToBeInserted)
    {
        _efContext.Users.Add(recordToBeInserted);
    }

    public void UpdateRecord(User recordToBeUpdated)
    {
        _efContext.Users.Update(recordToBeUpdated);
    }

    public void DeleteRecord(User recordToBeDeleted)
    {
        _efContext.Users.Remove(recordToBeDeleted);
    }

    public void SaveChanges()
    {
        _efContext.SaveChanges();
    }

    public User GetUserById(int UserId)
    {
        var returnedUser = _efContext.Users.Find(UserId);
        if (returnedUser is null)
        {
            throw new Exception("There is No User With this Id");
        }

        return returnedUser;
    }
}