using System.Linq.Expressions;

namespace kc_backend.Utilities
{
    public static class ExpressionExtensions
    {
        public enum CombineOperator
        {
            AND,
            OR,
        }

        public static Expression<Func<T, bool>>? Combine<T>(this IEnumerable<Expression<Func<T, bool>>> expressions, CombineOperator combineOperator = CombineOperator.OR)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            Expression? body = null;

            foreach (Expression<Func<T, bool>> expression in expressions)
            {
                Expression replacedBody = new ReplaceParameterVisitor(expression.Parameters[0], parameter).Visit(expression.Body);

                body = body == null
                    ? replacedBody
                    : combineOperator == CombineOperator.OR
                        ? Expression.OrElse(body, replacedBody)
                        : Expression.AndAlso(body, replacedBody);
            }

            return body is null ? null : Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private class ReplaceParameterVisitor(ParameterExpression oldParameter, ParameterExpression newParameter) : ExpressionVisitor
        {
            private readonly ParameterExpression oldParameter = oldParameter;
            private readonly ParameterExpression newParameter = newParameter;

            protected override Expression VisitParameter(ParameterExpression node) => node == oldParameter ? newParameter : base.VisitParameter(node);
        }
    }
}
