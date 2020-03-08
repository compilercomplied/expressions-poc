using System;
using System.Linq.Expressions;

namespace Expressions_PoC.Filters
{
  public static class Filter
  {

    /// <summary>
    /// Builds an expression using the non-null properties from an incoming object.
    /// </summary>
    public static Expression<Func<T, bool>> ByMatch<T>(T match)
      where T : class
    {

      Expression filter = null;
      ParameterExpression paramExp = Expression.Parameter(typeof(T));

      foreach (var prop in typeof(T).GetProperties())
      {

        var value = prop.GetValue(match);

        if (value == null) continue;

        ConstantExpression comparisonConstant = Expression.Constant(value, prop.PropertyType);
        MemberExpression fieldExp = Expression.Property(paramExp, prop.Name);

        BinaryExpression comparison = Expression.MakeBinary(
            ExpressionType.Equal,
            fieldExp,
            comparisonConstant
          );

        filter = filter == null ? comparison : Expression.AndAlso(filter, comparison);

      }

      return Expression.Lambda<Func<T, bool>>(filter, new ParameterExpression[] { paramExp });

    }

  }

}
