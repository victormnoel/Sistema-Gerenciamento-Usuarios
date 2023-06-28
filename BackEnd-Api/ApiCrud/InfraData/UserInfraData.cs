using ApiCrud.Context;
using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.InfraData
{
    public class UserInfraData : BaseInfraData, IUserInfraData
    {
        private readonly UserContext _context;
        public UserInfraData(UserContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _context.User.Where(x => x.Id == id).FirstAsync();
        }
    }
}
