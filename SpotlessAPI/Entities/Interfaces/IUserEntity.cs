using SpotlessAPI.Models;

namespace SpotlessAPI.Entities.Interfaces;

public interface IUserEntity : IBaseEntity<User>
{
    User GetUserById(int UserId);
}
