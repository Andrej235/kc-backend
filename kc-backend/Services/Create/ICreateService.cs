﻿namespace kc_backend.Services.Create
{
    public interface ICreateService<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adds entity to database
        /// </summary>
        /// <returns>Added entity with its new primary key</returns>
        /// <param name="toAdd">Entity to save in the database</param>
        /// <exception cref="Exceptions.FailedToCreateEntityException"/>
        Task<TEntity> Add(TEntity toAdd);
    }
}
