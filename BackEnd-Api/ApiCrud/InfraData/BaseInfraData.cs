using ApiCrud.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.InfraData
{
    public class BaseInfraData : IBaseInfraData
    {
        private readonly UserContext _context;
        public BaseInfraData(UserContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
