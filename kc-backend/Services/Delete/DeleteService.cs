using kc_backend.Data;
using kc_backend.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace kc_backend.Services.Delete
{
    public class DeleteService<T>(DataContext context) : IDeleteService<T> where T : class
    {
        private readonly DataContext context = context;

        public async Task Delete(Expression<Func<T, bool>> deleteCriteria, bool validate)
        {
            int deletedCount = await context.Set<T>().Where(deleteCriteria).ExecuteDeleteAsync();
            if (validate && deletedCount == 0)
                throw new NotFoundException("Entity not found");
        }
    }
}
