using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace SharpBlog
{
    public static class Reflect
    {
        public static string GetName<TParameter>(Expression<Func<TParameter, object>> expression)
        {
            return ModelMetadata.FromLambdaExpression(expression, null).PropertyName;
        }
    }
}