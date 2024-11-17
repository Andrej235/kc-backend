using kc_backend.Data;
using kc_backend.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace kc_backend.Services.Update
{
    public class UpdateService<T>(DataContext context) : IUpdateSingleService<T>, IUpdateRangeService<T>, IExecuteUpdateService<T> where T : class
    {
        public async Task Update(T updatedEntity)
        {
            try
            {
                _ = context.Set<T>().Update(updatedEntity);
                _ = await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException("Failed to update", ex);
            }
        }

        public async Task Update(IEnumerable<T> updatedEntities)
        {
            try
            {
                context.Set<T>().UpdateRange(updatedEntities);
                _ = await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException("Failed to update", ex);
            }
        }

        public async Task Update(Expression<Func<T, bool>> updateCriteria, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls) =>
            await context.Set<T>().Where(updateCriteria).ExecuteUpdateAsync(setPropertyCalls);
    }
}
