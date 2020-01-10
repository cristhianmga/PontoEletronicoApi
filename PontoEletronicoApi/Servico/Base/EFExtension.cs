using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PontoEletronico.Servico.Base
{
    public static class EFExtension
    {
        public static IQueryable<T> WhereEquals<T>(this IQueryable<T> query, string propertyName, dynamic value)
        {
            try
            {
                ParameterExpression parameter = Expression.Parameter(typeof(T), "type");
                MemberExpression property = Expression.Property(parameter, propertyName);
                BinaryExpression expressao = Expression.Equal(property, Expression.Constant(value, value.GetType()));
                Expression<Func<T, bool>> predicate = Expression.Lambda<Func<T, bool>>(expressao, parameter);
                return query.Where(predicate);
            }
            catch (Exception)
            {
                return query;
            }
        }
    }
}
