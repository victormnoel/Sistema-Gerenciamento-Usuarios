using ApiCrud.Models;

namespace ApiCrud.InfraData
{
    public interface IUserInfraData : IBaseInfraData
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
    }
}
