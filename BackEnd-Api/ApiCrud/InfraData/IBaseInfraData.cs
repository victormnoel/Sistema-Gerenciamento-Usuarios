﻿namespace ApiCrud.InfraData
{
    public interface IBaseInfraData
    {
        public void Add<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
