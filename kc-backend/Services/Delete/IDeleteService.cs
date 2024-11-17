﻿using System.Linq.Expressions;

namespace kc_backend.Services.Delete
{
    public interface IDeleteService<T> where T : class
    {
        /// <summary>
        /// Deletes all entities that match the delete criteria
        /// </summary>
        /// <param name="deleteCriteria">Criteria to match</param>
        /// <param name="validate">
        /// Whether to validate the result of the deletion
        /// If set to true, throws <see cref="Exceptions.NotFoundException"/> if no entities were deleted
        /// </param>
        ///<exception cref="Exceptions.NotFoundException"/>
        Task Delete(Expression<Func<T, bool>> deleteCriteria, bool validate = true);
    }
}
