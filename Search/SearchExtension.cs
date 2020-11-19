using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace sibintek.sibmobile.core
{   
    public static class SearchExtension
    {
        public static IQueryable<T> Search<T>(this IQueryable<T> data, string query)
        {
            var pattern = ".*" + query + ".*";

            Expression<Func<T, bool>> lambda = null;

            foreach(var field in GetSearchableFiels<T>())
            {
                lambda = lambda == null 
                    ? CreateRegExPredicate<T>(field, pattern) 
                    : lambda.Or(CreateRegExPredicate<T>(field, pattern));
            }

            if (lambda != null)
            {
                return data.Where(lambda);
            }

            return data;
        }
   
        private static string[] GetSearchableFiels<T>()
        {
            return typeof(T).GetProperties()
                .Where(r => r.PropertyType.FullName == "System.String")
                .Select(r => r.Name)
                .ToArray();
        }
        
        static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2) 
        {    
            ParameterExpression p = expr1.Parameters[0];

            SubstExpressionVisitor visitor = new SubstExpressionVisitor();
            visitor.subst[expr2.Parameters[0]] = p;

            Expression body = Expression.OrElse(expr1.Body, visitor.Visit(expr2.Body));
            return Expression.Lambda<Func<T, bool>>(body, p);
        }
        
        internal class SubstExpressionVisitor : System.Linq.Expressions.ExpressionVisitor 
        {
            public Dictionary<Expression, Expression> subst = new Dictionary<Expression, Expression>();

            protected override Expression VisitParameter(ParameterExpression node) {
                Expression newValue;
                if (subst.TryGetValue(node, out newValue)) {
                    return newValue;
                }
                return node;
            }
        }

        static Expression<Func<T, bool>> CreateRegExPredicate<T>(string field, string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var paramObject = Expression.Parameter(typeof(T), "p");
            var paramMyType = Expression.TypeAs(paramObject, typeof(T));
            var propMyField = Expression.Property(paramMyType, field);
            var constRegex = Expression.Constant(regex);

            var methodInfo = typeof(Regex).GetMethod("IsMatch", new Type[] { typeof(string) });
            var paramsEx = new Expression[] { propMyField };

            var lamdaBody = Expression.Call(constRegex, methodInfo, paramsEx);
            Expression<Func<T, bool>> lamda = Expression.Lambda<Func<T, bool>>(lamdaBody, paramObject);

            return lamda;
        }
    }
}
